using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CategoryDto> Get(int id)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == id);
            var categoryDto = new CategoryDto();
            categoryDto.Category = category;
            return categoryDto;
        }

        public async Task<CategoriesDto> GetAll()
        {
            var categories = await _unitOfWork.Category.GetAllAsync();
            var categoriesDto = new CategoriesDto();
            categoriesDto.Categories = categories.ToList();
            return categoriesDto;
            
        }

        public async Task Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == updateCategoryDto.Id);
            category = _mapper.Map<Category>(updateCategoryDto);
            _unitOfWork.Category.Update(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
