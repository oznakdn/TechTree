using Microsoft.AspNetCore.Mvc;
using TechTree.Application.Dtos.CategoryItemDtos;
using TechTree.Application.Services;

namespace TechTree.Presentation.Mvc.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryItemController : Controller
    {
        private readonly ICategoryItemService _categoryItemService;
        private readonly IMediaTypeService _mediaTypeService;
        private readonly ICategoryService _categoryService;

        public CategoryItemController(ICategoryItemService categoryItemService, IMediaTypeService mediaTypeService, ICategoryService categoryService)
        {
            _categoryItemService = categoryItemService;
            _mediaTypeService = mediaTypeService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int Id)
        {
            ViewBag.categoryId = Id;
            var categoryItems = await _categoryItemService.GetAll(Id);
            if(categoryItems.Count()<1)
            {
                return RedirectToAction(nameof(Add), "CategoryItem", new {Id});
            }

            return View(categoryItems);
        }

        public async Task<IActionResult>Details(int Id)
        {
            var categoryItem = await _categoryItemService.Get(Id);
            return View(categoryItem);

        }

        public async Task<IActionResult> Add(int Id)
        {
            ViewBag.mediaTypes = await _mediaTypeService.GetAll();
            return View(new CreateCategoryItemDto { CategoryId = Id });
        }


        [HttpPost]
        public async Task<IActionResult>Add(CreateCategoryItemDto createCategoryItemDto )
        {
            if (ModelState.IsValid)
            {

                await _categoryItemService.Add(createCategoryItemDto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.mediaTypes = await _mediaTypeService.GetAll();
            return View(createCategoryItemDto.CategoryId = ViewBag.categoryId);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var categoryItem =await _categoryItemService.Get(Id);
            var updateCategoryItemDto = new UpdateCategoryItemDto
            {
                Title = categoryItem.Title,
                ItemReleasedDate = categoryItem.ItemReleasedDate,
                MediaTypeId = categoryItem.MediaTypeId,
                CategoryId = categoryItem.CategoryId
            };
            ViewBag.categories = await _categoryService.GetAll();
            ViewBag.mediaTypes = await _mediaTypeService.GetAll();
            return View(updateCategoryItemDto);
        }

        [HttpPost]
        public async Task<IActionResult>Update(UpdateCategoryItemDto updateCategoryItemDto)
        {
            ViewBag.categoryId = updateCategoryItemDto.CategoryId;
            if(ModelState.IsValid)
            {
                ViewBag.mediaTypes = await _mediaTypeService.GetAll();
                await _categoryItemService.Update(updateCategoryItemDto);
                return RedirectToAction(nameof(Index),"CategoryItem",new { ViewBag.categoryId });
            }

            ViewBag.categories = await _categoryService.GetAll();
            ViewBag.mediaTypes = await _mediaTypeService.GetAll();
            return View(updateCategoryItemDto);
        }
    }
}
