#nullable disable
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Models;

namespace Trello.Controllers
{
    public class CartoesController : Controller
    {
        private readonly Connection _context;

        public CartoesController(Connection context)
        {
            _context = context;
        }

        // GET: Cartoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Cartoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // GET: Cartoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Time,Description,ID,Status")] Cards cards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cards);
        }

        // GET: Cartoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }
            return View(cards);
        }

        // POST: Cartoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Time,Description,ID,Status")] Cards cards)
        {
            if (id != cards.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardsExists(cards.ID))
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
            return View(cards);
        }

        // GET: Cartoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // POST: Cartoes/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cards = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(cards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardsExists(int id)
        {
            return _context.Cards.Any(e => e.ID == id);
        }
    }
}
