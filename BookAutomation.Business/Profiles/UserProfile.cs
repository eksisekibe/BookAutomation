using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
using BookAutomation.Entity.Concrete;

namespace BookAutomation.Business.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserRO>();
            CreateMap<UserDTO, User>();

        }
    }
}
