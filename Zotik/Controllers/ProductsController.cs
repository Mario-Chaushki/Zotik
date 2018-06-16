using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zotik.Models;

namespace Zotik.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PadsContext _context;

        public ProductsController(PadsContext context)
        {
            _context = context;
        }

        // GET: Products
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Продукти";
            return View(await _context.Pad.ToListAsync());
        }

        // GET: Products/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pad = await _context.Pad
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pad == null)
            {
                return NotFound();
            }

            return View(pad);
        }

        // GET: Products/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,Material,ImageName")] Pad pad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pad);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pad = await _context.Pad.SingleOrDefaultAsync(m => m.Id == id);
            if (pad == null)
            {
                return NotFound();
            }
            return View(pad);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,Material,ImageName")] Pad pad)
        {
            if (id != pad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadExists(pad.Id))
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
            return View(pad);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pad = await _context.Pad
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pad == null)
            {
                return NotFound();
            }

            return View(pad);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pad = await _context.Pad.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pad.Remove(pad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadExists(int id)
        {
            return _context.Pad.Any(e => e.Id == id);
        }
    }
}
