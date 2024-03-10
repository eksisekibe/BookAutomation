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
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPrincipal _principal;
        private IMapper _mapper;

        public BookService(IBookRepository bookRepository, IUserRepository userRepository, IMapper mapper, IPrincipal principal)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _principal = principal;
        }
        public async Task<bool> CreateAsync(BookDTO dto)
        {
            var entity = _mapper.Map<Book>(dto);
            if (Validation(entity))
            {
                entity.LastModifiedBy = _principal.Identity.Name;
                await _bookRepository.CreateAsync(entity);
                dto.Id = entity.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("Book is not found - Kitap bulunamadı");
            await _bookRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<List<BookRO>> GetAllAsync()
        {
            var entities = await _bookRepository.GetAllAsync();
            return ToResponseObject(entities);
        }

        public async Task<List<BookRO>> GetByAuthorAsync(string author)
        {
            var entities = await _bookRepository.GetByAuthorAsync(author);
            return this.ToResponseObject(entities);
        }

        public async Task<List<BookRO>> GetByGenreAsync(string genre)
        {
            var entities = await _bookRepository.GetByGenreAsync(genre);
            return this.ToResponseObject(entities);
        }

        public async Task<BookRO> GetByIdAsync(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("Book is not found - Kitap bulunamadı");
            return ToResponseObject(entity);
        }

        public async Task<List<BookRO>> GetByNameAsync(string name)
        {
            var entities = await _bookRepository.GetByNameAsync(name);
            return this.ToResponseObject(entities);
        }
        /*
        public async Task<string> GetLastModifiedUserNameAsync(int bookId)
        {
            var lastModifiedBy = await _bookRepository.GetLastModifiedByAsync(bookId);

            if (lastModifiedBy != null)
            {
                var user = await _userRepository.GetByIdAsync(lastModifiedBy.Id);

                if (user != null)
                {
                    return $"{user.FirstName} {user.LastName}";
                }
            }

            return "Bilinmiyor";
        }
        */
        public BookRO ToResponseObject(Book entity)
        {
            return _mapper.Map<BookRO>(entity);
        }

        public List<BookRO> ToResponseObject(List<Book> entity)
        {
            return _mapper.Map<List<BookRO>>(entity);
        }

        public async Task<bool> UpdateAsync(int id, BookDTO dto)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("Book is not found - Kitap bulunamadı");
            var updateEntity = _mapper.Map<Book>(dto);
            // ---------------------Dynamic Update----------------------------
            foreach (var prop in typeof(Book).GetProperties())
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
                entity.LastModifiedBy = _principal.Identity.Name;
                await _bookRepository.UpdateAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Validation(Book entity)
        {
            return true;
        }
    }
}
