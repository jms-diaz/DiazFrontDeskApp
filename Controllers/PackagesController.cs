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
using DiazFrontDeskApp.Repositories;

namespace DiazFrontDeskApp.Controllers
{
    public class PackagesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPackage _packageRepo;

        public PackagesController(AppDbContext context, IPackage packageRepo)
        {
            _context = context;
            _packageRepo = packageRepo;
        }

        // GET: Packages
        public IActionResult Index()
        {
            var packages = _packageRepo.GetItems();
            return View(packages);
        }


        // GET: Packages/Create
        public IActionResult Create()
        {
            ViewData["PackageAreaId"] = new SelectList(_context.PackageAreas, "PackageAreaId", "PackageAreaType");
            ViewData["PackageStatusId"] = new SelectList(_context.PackageStatus, "PackageStatusId", "PackageStatusName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PackageId,Description,StoredAt,RetrievedAt,UpdatedAt,CreatedAt,UserId,PackageAreaId,PackageStatusId")] Package package)
        {

            // Get the relevant PackageArea based on the PackageAreaId
            PackageArea packageArea = _context.PackageAreas
                .FirstOrDefault(pa => pa.PackageAreaId == package.PackageAreaId);

            if (packageArea == null)
            {
                return NotFound();
            }

            if (packageArea.CurrentCapacity >= packageArea.MaxCapacity)
            {
                ViewBag.Message = "The package cannot be added because the area is full.";
                return View(package);
            } else
            {
                // The area is not full, add the package and update the CurrentCapacity
                packageArea.CurrentCapacity++;

                if (ModelState.IsValid)
                {
                    _packageRepo.Create(package);
                    return RedirectToAction(nameof(Index));
                }

            }

            ViewData["PackageAreaId"] = new SelectList(_context.PackageAreas, "PackageAreaId", "PackageAreaType", package.PackageAreaId);
            ViewData["PackageStatusId"] = new SelectList(_context.PackageStatus, "PackageStatusId", "PackageStatusName", package.PackageStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullNam", package.UserId);
            return View(package);
        }

        // GET: Packages/Edit/5
        public IActionResult Edit(int id)
        {
            var package = _packageRepo.GetItem(id);
            if (package == null) return NotFound();
            ViewData["PackageAreaId"] = new SelectList(_context.PackageAreas, "PackageAreaId", "PackageAreaType", package.PackageAreaId);
            ViewData["PackageStatusId"] = new SelectList(_context.PackageStatus, "PackageStatusId", "PackageStatusName", package.PackageStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", package.UserId);
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageId,Description,StoredAt,RetrievedAt,UpdatedAt,CreatedAt,UserId,PackageAreaId,PackageStatusId")] Package package)
        {
            if (id != package.PackageId) return NotFound();

            if (package.PackageStatusId == 2)
            {
                // Get the relevant PackageArea based on the PackageAreaId
                PackageArea packageArea = _context.PackageAreas
                    .FirstOrDefault(pa => pa.PackageAreaId == package.PackageAreaId);

                // Check if the current capacity is greater than zero before decrementing
                if (packageArea != null && packageArea.CurrentCapacity > 0)
                {
                    packageArea.CurrentCapacity--;
                    package.RetrievedAt = DateTime.Now;
                }
            }

            if (ModelState.IsValid)
            {
                _packageRepo.Edit(package);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackageAreaId"] = new SelectList(_context.PackageAreas, "PackageAreaId", "PackageAreaType", package.PackageAreaId);
            ViewData["PackageStatusId"] = new SelectList(_context.PackageStatus, "PackageStatusId", "PackageStatusName", package.PackageStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", package.UserId);
            return View(package);
        }
    }
}
