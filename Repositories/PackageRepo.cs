using DiazFrontDeskApp.Data;
using DiazFrontDeskApp.Interfaces;
using DiazFrontDeskApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiazFrontDeskApp.Repositories
{
    public class PackageRepo : IPackage
    {
        private readonly AppDbContext _context;

        public PackageRepo(AppDbContext context)
        {
            _context = context;
        }

        public Package Create(Package package)
        {
            package.CreatedAt = DateTime.Now;
            package.UpdatedAt = DateTime.Now;

            _context.Packages.Add(package);
            _context.SaveChanges();
            return package;
        }

        public Package Edit(Package package)
        {
            package.UpdatedAt = DateTime.Now;
            _context.Packages.Attach(package);
            _context.Entry(package).State = EntityState.Modified;
            _context.SaveChanges();
            return package;
        }

        public Package GetItem(int id)
        {
            var package = _context.Packages
                .Include(p => p.PackageArea)
                .Include(p => p.PackageStatus)
                .Include(p => p.User)
                .FirstOrDefault(m => m.PackageId == id);
            return package;
        }

        public IEnumerable<Package> GetItems()
        {
            var packages = _context.Packages.Include(p => p.PackageArea).Include(p => p.PackageStatus).Include(p => p.User).ToList();
            return packages;
        }
    }
}
