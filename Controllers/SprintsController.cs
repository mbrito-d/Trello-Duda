#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trello_Duda.Models;

namespace Trello_Duda.Controllers
{
    public class SprintsController : Controller
    {
        private readonly Connection _context;

        public SprintsController(Connection context)
        {
            _context = context;
        }

        // GET: Sprints
        public async Task<IActionResult> Index()
        {
            return View(await _context.SprintsInfo.ToListAsync());
        }

        // GET: Sprints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprintsInfo = await _context.SprintsInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sprintsInfo == null)
            {
                return NotFound();
            }

            return View(sprintsInfo);
        }

        // GET: Sprints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sprints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ID")] SprintsInfo sprintsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprintsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprintsInfo);
        }

        // GET: Sprints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprintsInfo = await _context.SprintsInfo.FindAsync(id);
            if (sprintsInfo == null)
            {
                return NotFound();
            }
            return View(sprintsInfo);
        }

        // POST: Sprints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ID")] SprintsInfo sprintsInfo)
        {
            if (id != sprintsInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprintsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprintsInfoExists(sprintsInfo.ID))
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
            return View(sprintsInfo);
        }

        // GET: Sprints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprintsInfo = await _context.SprintsInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sprintsInfo == null)
            {
                return NotFound();
            }

            return View(sprintsInfo);
        }

        // POST: Sprints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sprintsInfo = await _context.SprintsInfo.FindAsync(id);
            _context.SprintsInfo.Remove(sprintsInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprintsInfoExists(int id)
        {
            return _context.SprintsInfo.Any(e => e.ID == id);
        }
    }
}
