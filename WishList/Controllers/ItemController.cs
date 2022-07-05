using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(nameof(Index), _context.Items.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(nameof(Create));
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            var match = _context.Items.FirstOrDefault(i => i.Id == Id);
            if (match is null) return RedirectToAction(nameof(Index));

            _context.Items.Remove(match);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

