using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
using BookAutomation.Entity.Concrete;

namespace BookAutomation.Business.Profiles
{
    public class BookProfile : AutoMapper.Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookRO>();
            CreateMap<BookDTO, Book>();

        }
    }
}
