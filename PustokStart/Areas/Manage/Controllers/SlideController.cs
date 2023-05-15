using Microsoft.AspNetCore.Mvc;
using PustokStart.DAL;
using PustokStart.Models;
using PustokStart.ViewModels;

namespace PustokStart.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SlideController : Controller
    {
        private readonly PustokContext _context;

        public SlideController(PustokContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {

            var query =
                _context.Slides.AsQueryable();
            return View(PaginatedList<Slide>.Create(query, page, 3));

        }
    }
}
