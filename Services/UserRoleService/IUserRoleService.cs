namespace ApiaryManagementSystem.Services.UserRoleService
{
    public interface IUserRoleService
    {
        Task<List<string>> GetUserRolesAsync(int userId);
    }
}
