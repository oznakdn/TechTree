using Microsoft.AspNetCore.Mvc;
using TechTree.Application.Dtos.CategoryDtos;
using TechTree.Application.Services;

namespace TechTree.Presentation.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAll();
            return View(result);
        }

        public async Task<IActionResult>Details(int id)
        {
            var result = await _categoryService.Get(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public IActionResult Add()
        {
            return View(new CreateCategoryDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Add(CreateCategoryDto createCategoryDto)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.Add(createCategoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createCategoryDto);
        }

        public async Task<IActionResult>Update(int id)
        {
            var category = await _categoryService.Get(id);
            var updateCategoryDto = new UpdateCategoryDto
            {
                Title=category.Category.Title,
                Description=category.Category.Description,
                ThumbnailImagePath=category.Category.ThumbnailImagePath
            };

            return View(updateCategoryDto);
            
        }

        [HttpPost]
        public async Task<IActionResult>Update(UpdateCategoryDto updateCategoryDto)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.Update(updateCategoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateCategoryDto);
        }
    }
}
