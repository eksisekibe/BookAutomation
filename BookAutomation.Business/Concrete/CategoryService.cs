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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(CategoryDTO dto)
        {
            var entity = _mapper.Map<Category>(dto);
            if (Validation(entity))
            {
                await _categoryRepository.CreateAsync(entity);
                dto.Id = entity.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("Category is not found - Kategori bulunamadı");
            await _categoryRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<List<CategoryRO>> GetAllAsync()
        {
            var entities = await _categoryRepository.GetAllAsync();
            return ToResponseObject(entities);
        }

        public async Task<CategoryRO> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("Category is not found - Kategori bulunamadı");
            return ToResponseObject(entity);
        }

        public async Task<List<CategoryRO>> GetNameAsync(string name)
        {
            var entities = await _categoryRepository.GetNameAsync(name);
            return this.ToResponseObject(entities);
        }

        //public async Task<List<CategoryRO>> GetSubcategoriesAsync(int parentId)
        //{
        //    var entities = await _categoryRepository.GetSubcategoriesAsync(parentId);
        //    return this.ToResponseObject(entities);
        //}

        public CategoryRO ToResponseObject(Category entity)
        {
            return _mapper.Map<CategoryRO>(entity);
        }

        public List<CategoryRO> ToResponseObject(List<Category> entity)
        {
            return _mapper.Map<List<CategoryRO>>(entity);

        }

        public async Task<bool> UpdateAsync(int id, CategoryDTO dto)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity is null)
                throw new ItemNotFoundException("Category is not found - Kategori bulunamadı");
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
                await _categoryRepository.UpdateAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Validation(Category entity)
        {
            return true;
        }
    }
}
