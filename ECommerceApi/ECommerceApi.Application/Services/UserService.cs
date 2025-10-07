using ECommerceApi.Application.Interfaces;

namespace ECommerceApi.Application.Services
{
    public class UserService : IUserService
    {
        public string GetUserName(int userId)
        {
            return $"User_{userId}";
        }
    }
}
