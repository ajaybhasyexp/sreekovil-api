using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Common;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sreekovil.Business
{
    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : IUserService
    {
        #region Private members

        /// <summary>
        /// The repository for user related data methods.
        /// </summary>
        private IUserRepository _userRepository { get; set; }

        /// <summary>
        /// The app settings object.
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        /// <summary>
        /// Constructor for user service.
        /// </summary>
        /// <param name="userRepository">User repository to inject.</param>
        /// <param name="appSettings">The app setting to inject.</param>
        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// The authenticate method to validate user and issue claims.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user object with token.</returns>
        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetUser(username, password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.GivenName,user.Email),
                    //new Claim(ClaimTypes.Role,user.UserRoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        /// <summary>
        /// Gets a single user entity according to the identifier.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>A user entity.</returns>
        public User Get(int id) => _userRepository.Get(id);

        /// <summary>
        /// Gets all the users.
        /// </summary>
        /// <returns>A list of users.</returns>
        public List<User> GetAll() => _userRepository.GetAll();

        public List<User> GetAll(int branchId) => _userRepository.GetAll(branchId);

        /// <summary>
        /// Saves the user entity.
        /// </summary>
        /// <param name="user">The entity to save or update.</param>
        /// <returns>the saved entity.</returns>
        public User Save(User user) => _userRepository.Save(user);

        /// <summary>
        /// Deletes the user entity.
        /// </summary>
        /// <param name="user">The user entity to delete.</param>
        public void Delete(User user) => _userRepository.Delete(user);
    }
}
