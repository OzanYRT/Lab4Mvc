using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4Cities.Data;
using Lab4Cities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4Cities.Controllers
{
    public class ProvincesController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ProvincesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Provinces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provinces.ToListAsync());
        }

        // GET: Provinces/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var province = await _context.Provinces
                .Include(p => p.Cities)
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // GET: Provinces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Province province)
        {
            if (ModelState.IsValid)
            {
                _context.Add(province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(province);
        }

        // GET: Provinces/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var province = await _context.Provinces.FindAsync(id);
            
            if (province == null)
            {
                return NotFound();
            }
            
            return View(province);
        }

        // POST: Provinces/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Province province)
        {
            if (id != province.ProvinceCode)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(province);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinceExists(province.ProvinceCode))
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
            
            return View(province);
        }

        private bool ProvinceExists(string id)
        {
            return _context.Provinces.Any(e => e.ProvinceCode == id);
        }

        // GET: Provinces/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            
            if (province == null)
            {
                return NotFound();
            }
            
            return View(province);
        }

        // POST: Provinces/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var province = await _context.Provinces.FindAsync(id);
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}