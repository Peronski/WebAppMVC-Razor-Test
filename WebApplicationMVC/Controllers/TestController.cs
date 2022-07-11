using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class TestController : Controller
    {
        private static List<TestViewModel> _aphorism = new List<TestViewModel>();

        public IActionResult Index()
        {
            return View(_aphorism);
        }

        public IActionResult Create()
        {
            TestViewModel model = new TestViewModel();
            return View(model);
        }

        public IActionResult CreateAphorism(TestViewModel testViewModel)
        {
            _aphorism.Add(testViewModel);
            return View(nameof(Index), _aphorism);
        }
    }
}
