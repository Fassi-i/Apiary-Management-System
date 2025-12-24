using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Services.UserRoleService;
using ApiaryManagementSystem.Services.UserService;

namespace ApiaryManagementSystem.Extensions
{
    public class RoleClaimsTransformation : IClaimsTransformation
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRoleService _roleService;
        private readonly IUserService _userService;

        public RoleClaimsTransformation(ApplicationDbContext context, IUserRoleService roleService, IUserService userService)
        {
            _context = context;
            _roleService = roleService;
            _userService = userService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;

            if (identity == null || !identity.IsAuthenticated)
                return principal;

            var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                return principal;

            var roles = await _roleService.GetUserRolesAsync(userId);

            foreach (var role in roles)
            {
                if (!identity.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == role))
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return principal;
        }
    }
}
