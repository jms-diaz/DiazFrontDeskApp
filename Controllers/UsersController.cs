using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiazFrontDeskApp.Data;
using DiazFrontDeskApp.Models;
using DiazFrontDeskApp.Interfaces;
using System.Drawing.Drawing2D;

namespace DiazFrontDeskApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _userRepo;

        public UsersController(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: Users
        public IActionResult Index()
        {
            var users = _userRepo.GetItems();
            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Create(user);
                return RedirectToAction(nameof(Index));
            }

            return View(user);

        }

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _userRepo.GetItem(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,FirstName,LastName")] User user)
        {
            if (id != user.UserId) return NotFound();

            if (ModelState.IsValid)
            {
                _userRepo.Edit(user);
                return RedirectToAction(nameof(Index));
            }

            return View(user);

        }

    }
}
