using CodeFirstApproach12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CodeFirstApproach12.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;
    
        public UserController(UserContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }


        //Add or Insert Data 
        public IActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,City")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public IActionResult Edit(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
                return View(_context.Users.Find(id));
        }

        // POST: Employee/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,City")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id == 0)
                    _context.Add(user);
                else
                    _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    


    }
}