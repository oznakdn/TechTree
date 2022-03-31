using Microsoft.AspNetCore.Mvc;

namespace TechTree.Presentation.Mvc.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
