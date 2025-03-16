using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        // Dwellers
        public IActionResult Dwellers()
        {
            var dwellers = _context.Dwellers.Include(d => d.Vault).ToList(); // Load dwellers with their Vaults
            ViewBag.Vaults = _context.Vaults.ToList(); // Pass Vaults to ViewBag for the dropdown

            return View(dwellers);
        }

        public IActionResult CreateEditDweller(int? id)
        {
            // Ensure ViewBag.Vaults is always set
            ViewBag.Vaults = new SelectList(_context.Vaults, "Id", "Name");

            Dweller dweller;

            if (id == null)
            {
                // If we're creating a new Dweller, initialize a blank one
                dweller = new Dweller();
            }
            else
            {
                // If editing, find the Dweller and include its Vault
                dweller = _context.Dwellers.Include(d => d.Vault).FirstOrDefault(d => d.Id == id);
                if (dweller == null)
                {
                    return NotFound();
                }
            }

            return View(dweller);
        }

        [HttpPost]
        public IActionResult SaveDweller(Dweller model)
        {
            if (model.Id == 0)
            {
                _context.Dwellers.Add(model); // Add new dweller
            }
            else
            {
                var existingDweller = _context.Dwellers.Find(model.Id);
                if (existingDweller != null)
                {
                    existingDweller.Name = model.Name;
                    existingDweller.Role = model.Role;
                    existingDweller.VaultId = model.VaultId;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Dwellers"); // Redirect to Dwellers page, not Vaults
        }

        public IActionResult DeleteDweller(int id)
        {
            var dwellerinDb = _context.Dwellers.FirstOrDefault(vaults => vaults.Id == id);
            _context.Dwellers.Remove(dwellerinDb);
            _context.SaveChanges();
            return RedirectToAction("Dwellers");
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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
