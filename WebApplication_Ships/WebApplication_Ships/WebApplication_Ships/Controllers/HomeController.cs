using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Ships.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Ships.Controllers
{
    public class HomeController : Controller
    {
        private ShipsContext db;

        public HomeController(ShipsContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Ships.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ship ship)
        {
            db.Ships.Add(ship);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Ship ship = await db.Ships.FirstOrDefaultAsync(p => p.Id == id);
                if (ship != null)
                return View(ship);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Ship ship = await db.Ships.FirstOrDefaultAsync(p => p.Id == id);
                if (ship != null)
                    return View(ship);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ship ship)
        {
            db.Ships.Update(ship);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Ship ship = await db.Ships.FirstOrDefaultAsync(p => p.Id == id);
                if (ship != null)
                    return View(ship);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Ship ship = await db.Ships.FirstOrDefaultAsync(p => p.Id == id);
                if (ship != null)
                {
                    db.Ships.Remove(ship);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}