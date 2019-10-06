using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Data.Abstractions.Repositories
{
    /// <summary>
    /// The interface for user related repository methods.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {

        /// <summary>
        /// Gets the user object by username and password.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A user object.</returns>
        User GetUser(string userName, string password);

        /// <summary>
        /// Gets all the users based on the temple.
        /// </summary>
        /// <param name="templeId">The id of the temple to filter the user.</param>
        /// <returns>A list of all users.</returns>
        List<User> GetAll(int templeId);

    }
}
