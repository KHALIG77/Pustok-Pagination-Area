using Microsoft.AspNetCore.Mvc;
using PustokStart.DAL;
using PustokStart.Models;
using PustokStart.ViewModels;

namespace PustokStart.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenreController : Controller
    {
       
        private readonly PustokContext _context;

        public GenreController(PustokContext context)
        {
           _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index(int page=1)
        {
            var query =
                  _context.Genres.AsQueryable();
            return View(PaginatedList<Genre>.Create(query, page, 1));
        }
        [HttpPost]
        public IActionResult Create(Genre genres) 
        {
            Genre genre = new Genre();
            if (genres.Name != null)
            {
                genre.Name=genres.Name;
                _context.Genres.Add(genre);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
