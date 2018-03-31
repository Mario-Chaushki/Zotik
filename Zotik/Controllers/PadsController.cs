﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zotik.Models;

namespace Zotik.Controllers
{
    public class PadsController : Controller
    {
        private readonly ZotikContext _context;

        public PadsController(ZotikContext context)
        {
            _context = context;
        }

        // GET: Pads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pad.ToListAsync());
        }

        // GET: Pads/Details/5
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

        // GET: Pads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,Material")] Pad pad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pad);
        }

        // GET: Pads/Edit/5
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

        // POST: Pads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,Material")] Pad pad)
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

        // GET: Pads/Delete/5
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

        // POST: Pads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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