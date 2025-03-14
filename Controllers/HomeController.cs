using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using VaultManagerV1.Models;

namespace VaultManagerV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly VaultDbContext _context;

        public HomeController(ILogger<HomeController> logger, VaultDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vault()
        {
            var allVaults = _context.Vaults.ToList();  // Get all vaults
            var totalVaults = allVaults.Count();       // Count the vaults

            ViewData["TotalVaults"] = totalVaults;     // Pass the count to the view

            return View(allVaults);
        }

        public IActionResult CreateEditVault(int? id)
        {
            if (id == null)
            {
                // Creating a new vault
                return View(new Vault());
            }

            // Editing an existing vault
            var vaultInDb = _context.Vaults.SingleOrDefault(v => v.Id == id);
            if (vaultInDb == null)
            {
                return NotFound();
            }

            return View(vaultInDb);
        }

        public IActionResult DeleteVault(int id)
        {
            var vaultinDb = _context.Vaults.SingleOrDefault(vaults => vaults.Id == id);
            _context.Vaults.Remove(vaultinDb);
            _context.SaveChanges();
            return RedirectToAction("Vault");
        }

        public IActionResult VaultForm(Vault model)
        {
            if (model.Id == 0)
            {
                // Creating a new vault
                _context.Vaults.Add(model);
            }
            else
            {
                // Editing an existing vault
                var vaultInDb = _context.Vaults.SingleOrDefault(v => v.Id == model.Id);
                if (vaultInDb == null)
                {
                    return NotFound();
                }

                vaultInDb.Name = model.Name;
                vaultInDb.Location = model.Location;
                _context.Vaults.Update(vaultInDb);  // Explicitly updating the entity
            }

            _context.SaveChanges();
            return RedirectToAction("Vault");
        }

        public IActionResult Dwellers()
        {
            return View();
        }

        public IActionResult CreateEditDweller(int? id)
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
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
