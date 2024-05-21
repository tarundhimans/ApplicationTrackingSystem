using ApplicationTrackingSystem.Data;
using ApplicationTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Areas.Applicant.Controllers
{
    [Area("Applicant")]
    public class JobPostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobPostController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var jobPosts = _context.JobPosts.ToList();
            ViewBag.CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");
            return View(jobPosts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobPost jobPost)
        {
           
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    // Handle the case where user is not authenticated
                    return Unauthorized();
                }

                jobPost.CreatedBy = userId;
                jobPost.CreatedAt = DateTime.Now;

                _context.JobPosts.Add(jobPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            return View(jobPost);
        }
    }
}
