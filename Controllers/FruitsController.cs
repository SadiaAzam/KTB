using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KTB.Data;
using KTB.Models;
using Microsoft.AspNetCore.Authorization;

namespace KTB.Controllers
{
    public class FruitsController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public FruitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fruits
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewData["VendorsofFruits"]= await _context.VendorsofFruits.ToListAsync();
            ViewData["Vendors"] = await _context.Vendor.ToListAsync();
            var applicationDbContext = _context.Fruit.Include(b => b.Employees);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> FruitList()
        {
            return View(await _context.Fruit.ToListAsync());
        }
        public IActionResult SearchForm()
        {
            return View();
        }
        public async Task<IActionResult> SearchResult(string Tital)
        {
            return View("Index", await _context.Fruit.Where(a=>a.Tital.Contains(Tital)).ToListAsync());
        }
        // GET: Fruits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit
                .FirstOrDefaultAsync(m => m.id == id);
            if (fruit == null)
            {
                return NotFound();
            }

            return View(fruit);
        }

        // GET: Fruits/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Employee_Id"] = new SelectList(_context.Employee, "Employee_Id", "Employee_Name");
            ViewData["VendorId"] = new SelectList(_context.Employee, "Vendor_Id", "Vendor_Name");
            return View();
        }

        // POST: Fruits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Tital,URL,Price,Employee_Id")] Fruit fruit,List<int>Vendors
            )
        {
            if (ModelState.IsValid)
            {
                _context.Add(fruit);
                await _context.SaveChangesAsync();
                List<VendorsofFruits> vendorsofFruits = new List<VendorsofFruits>();
                foreach(int vendor in Vendors)
                {
                    vendorsofFruits.Add(new VendorsofFruits { VendorId = vendor, FruitId = fruit.id });
                }
                _context.VendorsofFruits.AddRange(vendorsofFruits);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee_Id"] = new SelectList(_context.Employee, "Employee_Id", "Employee_Id", fruit.Employee_Id);
            return View(fruit);
        }

        // GET: Fruits/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit.FindAsync(id);
            if (fruit == null)
            {
                return NotFound();
            }
            IList<VendorsofFruits> vendorsofFruits = await _context.VendorsofFruits.Where<VendorsofFruits>(a => a.FruitId == fruit.id).ToListAsync();
            IList<int> listAuthors = new List<int>();
            foreach (VendorsofFruits vendorsofFruit in vendorsofFruits)
            {
                listAuthors.Add(vendorsofFruits.VendorId);
            }
            // var authors = await _context.Author.Where(a=>a.Id.Equals(listAuthors)).ToListAsync();



            ViewData["Employee_Id"] = new SelectList(_context.Employee, "Employee_Id", "Employee_Name", fruit.Employee_Id);
            ViewData["VendorId"] = new MultiSelectList(_context.Vendor, "Vendor_Id", "Vendor_Name", listAuthors.ToArray());
            return View(fruit);
        }

        // POST: Fruits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Tital,URL,Price,Employee,Vendors")] Fruit fruit)
        {
            if (id != fruit.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fruit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FruitExists(fruit.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fruit);
        }

        // GET: Fruits/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit
                .FirstOrDefaultAsync(m => m.id == id);
            if (fruit == null)
            {
                return NotFound();
            }

            return View(fruit);
        }

        // POST: Fruits/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fruit = await _context.Fruit.FindAsync(id);
            _context.Fruit.Remove(fruit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FruitExists(int id)
        {
            return _context.Fruit.Any(e => e.id == id);
        }
    }
}
