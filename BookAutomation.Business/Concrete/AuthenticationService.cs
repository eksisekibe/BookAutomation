using AutoMapper;
using BookAutomation.Business.Abstract;
using BookAutomation.Business.DTOs;
using BookAutomation.Business.Extensions;
using BookAutomation.Business.ROs;
using BookAutomation.Business.Utils.JWT.Abstract;
using BookAutomation.Data.Abstract;
using BookAutomation.Entity.Concrete;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookAutomation.Business.Concrete
{
    /// <summary>
    /// Manages Authentication Operations
    /// </summary>
    public class AuthenticationService : IAuthorizationService
    {
        public IUserRepository _userRepository;
        public ITokenHelper _tokenHelper;
        private IMapper _mapper;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public AuthenticationService(IUserRepository userRepository, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        /// <summary>
        /// Manages Login Operations
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        public async Task<LoginRO> Login(LoginDTO loginDTO)
        {
            // Get by User According to username
            var user =await this._userRepository.GetByUserNameAsync(loginDTO.Username);

            if (user == null)
            {
                throw new UnauthenticatedException("No user found in the system registered with this username");

            }
            if(user.Password != loginDTO.Password) 
            {
                throw new UnauthenticatedException("Password is wrong");
            }

            return new LoginRO
            {
                User = ToResponseObject(user),
                Token = new TokenRO
                {
                    JWT = _tokenHelper.CreateToken(user)
                }
            };
        }

        public UserRO ToResponseObject(User entity)
        {
            return _mapper.Map<UserRO>(entity);
        }
    }
}
