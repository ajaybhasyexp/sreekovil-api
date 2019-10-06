using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Business.Abstractions
{
    /// <summary>
    /// The user business service class.
    /// </summary>
    public interface IUserService
    {
        User Authenticate(string username, string password);

        /// <summary>
        /// Gets all the user from DB.
        /// </summary>
        /// <returns></returns>
        List<User> GetAll();

        /// <summary>
        /// Gets all the user based on the temple.
        /// </summary>
        /// <param name="templeId">The temple Id</param>
        /// <returns>A list of users based on the temple.</returns>
        List<User> GetAll(int templeId);

        /// <summary>
        /// Save a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The saved user.</returns>
        User Save(User user);

        /// <summary>
        /// Gets a single user entity according to the identifier.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>A user entity.</returns>
        User Get(int id);

        /// <summary>
        /// Deletes the user entity.
        /// </summary>
        /// <param name="user">The entity to delete</param>
        void Delete(User user);
    }
}
