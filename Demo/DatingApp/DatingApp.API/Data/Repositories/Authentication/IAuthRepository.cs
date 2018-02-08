using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data.Repositories.Authentication
{
    /// <summary>
    /// User authentication
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="user">User data</param>
        /// <param name="password">Password</param>
        /// <returns>Task of registered user</returns>
        Task<User> Register(User user, string password);
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        /// <returns>Task of registered user</returns>
        Task<User> Login(string username, string password);
        /// <summary>
        /// Check if user exists
        /// </summary>
        /// <param name="username">User name</param>
        /// <returns><Tru if user is registered, otherwise false/returns>
        Task<bool> UserExists(string username);
     }
}