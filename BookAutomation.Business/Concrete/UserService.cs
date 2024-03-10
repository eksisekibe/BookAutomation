using AutoMapper;
using BookAutomation.Business.Abstract;
using BookAutomation.Business.DTOs;
using BookAutomation.Business.Exeptions;
using BookAutomation.Business.ROs;
using BookAutomation.Data.Abstract;
using BookAutomation.Data.Concrete;
using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(UserDTO dto)
        {
            var entity = _mapper.Map<User>(dto);
            if (Validation(entity))
            {
                await _userRepository.CreateAsync(entity);
                dto.Id = entity.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("User is not found - Kullanıcı bulunamadı");
            await _userRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<List<UserRO>> GetAllAsync()
        {
            var entities = await _userRepository.GetAllAsync();
            return ToResponseObject(entities);
        }

        public async Task<List<UserRO>> GetByFirstNameAsync(string firstName)
        {
            var entities = await _userRepository.GetByFirstNameAsync(firstName);
            return this.ToResponseObject(entities);
        }

        public async Task<UserRO> GetByIdAsync(int id)
        {
           var entity = await _userRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("User is not found - Kullanıcı bulunamadı");
            return ToResponseObject(entity);
        }

        public async Task<List<UserRO>> GetByLastNameAsync(string lastName)
        {
            var entities = await _userRepository.GetByLastNameAsync(lastName);
            if (entities is null)
                throw new ItemNotFoundException("User is not found - Kullanıcı bulunamadı");
            return this.ToResponseObject(entities);
        }

        public async Task<UserRO> GetByUserNameAsync(string userName)
        {
            var entities = await _userRepository.GetByUserNameAsync(userName);
            return this.ToResponseObject(entities);
        }

        public UserRO ToResponseObject(User entity)
        {
            return _mapper.Map<UserRO>(entity);
        }

        public List<UserRO> ToResponseObject(List<User> entity)
        {
            return _mapper.Map<List<UserRO>>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UserDTO dto)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("User is not found - Kullanıcı bulunamadı");
            var updateEntity = _mapper.Map<User>(dto);
            // ---------------------Dynamic Update----------------------------
            foreach (var prop in typeof(User).GetProperties())
            {
                if (prop.Name != "Id")
                {
                    var editedAttribute = prop.GetValue(updateEntity);
                    // check updated edited attribute is null
                    if (editedAttribute == null)
                        continue;
                    prop.SetValue(entity, editedAttribute);
                }

            }
            //-------------------------------------------

            if (Validation(entity))
            {
                await _userRepository.UpdateAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Validation(User entity)
        {
            return true;
        }
    }
}
