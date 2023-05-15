using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokStart.DAL;
using PustokStart.Models;

namespace PustokStart.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AuthorController : Controller
    {
        private readonly PustokContext _context;

        public AuthorController(PustokContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.Include(x=>x.Books).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string fullName) 
        {
            Author author = new Author()
            {
                FullName = fullName,
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("index");
            
        }
    }
}
