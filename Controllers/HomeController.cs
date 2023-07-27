using DiazFrontDeskApp.Data;
using DiazFrontDeskApp.Models;
using DiazFrontDeskApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiazFrontDeskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve data for the ViewModel
            List<Package> packages = _context.Packages.ToList();
            List<PackageArea> packageAreas = _context.PackageAreas.ToList();
            List<User> users = _context.Users.ToList();

            // Create the ViewModel and populate it with the data
            UserPackageViewModel viewModel = new UserPackageViewModel
            {
                Packages = packages,
                PackageAreas = packageAreas,
                Users = users
            };

            // Pass the ViewModel to the view
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}