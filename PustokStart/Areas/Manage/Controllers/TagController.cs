using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokStart.DAL;
using PustokStart.Models;
using PustokStart.ViewModels;

namespace PustokStart.Areas.Manage.Controllers
{
    [Area("manage")]
    public class TagController : Controller
    {
        private readonly PustokContext _context;
        public TagController(PustokContext context)
        {
            _context = context;
           
        }

        public IActionResult Index(int page = 1)
        {
            var query =
                _context.Tags.AsQueryable();
            return View(PaginatedList<Tag>.Create(query, page, 1));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tag tag)
        {
         Tag tags = new Tag();
          tags.Name=tag.Name;

            if (tag.Name != null)
            {
                _context.Tags.Add(tags);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
