using Microsoft.AspNetCore.Mvc;

namespace ApplicationTrackingSystem.Areas.Customer
{
    [Area("Customer")]
    public class JobPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
