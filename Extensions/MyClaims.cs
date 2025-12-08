using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace ApiaryManagementSystem.Extensions
{
    public static class MyClaims
    {
        public static async Task AddUpdate(this ClaimsPrincipal user, HttpContext context, string type, string value)
        {
            var claims = user.Claims
                .Where(c => c.Type != type)
                .ToList();

            claims.Add(new Claim(type, value));

            await context.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, "Cookies")
                )
            );
        }

        public static async Task Remove(this ClaimsPrincipal user, HttpContext context, string type)
        {
            var claims = user.Claims
                .Where(c => c.Type != type)
                .ToList();

            await context.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, "Cookies")
                )
            );
        }

        public static string Get(this ClaimsPrincipal user, string type)
        {
            return user.FindFirst(type)?.Value;
        }

        public static int GetInt(this ClaimsPrincipal user, string type)
        {
            var value = user.Get(type);
            return int.TryParse(value, out int result) ? result : 0;
        }
    }
}
