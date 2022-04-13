using Microsoft.AspNetCore.Mvc;

namespace TechTree.Presentation.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
