using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AidCare6.Data;
using AidCare6.Models;

namespace AidCare6.Views
{
    public class eventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public eventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: events
        public async Task<IActionResult> Index()
        {
            return View(await _context.events.ToListAsync());
        }

        // GET: events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.events
                .FirstOrDefaultAsync(m => m.eventsID == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("eventsID,eventsLocation,eventsDateTime")] events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        // GET: events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("eventsID,eventsLocation,eventsDateTime")] events events)
        {
            if (id != events.eventsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!eventsExists(events.eventsID))
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
            return View(events);
        }

        // GET: events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.events
                .FirstOrDefaultAsync(m => m.eventsID == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // POST: events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.events.FindAsync(id);
            _context.events.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool eventsExists(int id)
        {
            return _context.events.Any(e => e.eventsID == id);
        }
    }
}
