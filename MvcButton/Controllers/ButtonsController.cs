using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcButton.Data;
using MvcButton.Models;

namespace MvcButton.Controllers
{
    public class ButtonsController : Controller
    {
        private readonly MvcButtonContext _context;

        public ButtonsController(MvcButtonContext context)
        {
            _context = context;
        }

        // GET: Buttons
        public async Task<IActionResult> Index(string searchString)
        {
            var buttons = from b in _context.Button
                         select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                buttons = buttons.Where(s => s.Brand.Contains(searchString));
            }

            return View(await buttons.ToListAsync());
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        // GET: Buttons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var button = await _context.Button
                .FirstOrDefaultAsync(m => m.Id == id);
            if (button == null)
            {
                return NotFound();
            }

            return View(button);
        }

        // GET: Buttons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buttons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Colour,Shape,Price")] Button button)
        {
            if (ModelState.IsValid)
            {
                _context.Add(button);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(button);
        }

        // GET: Buttons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var button = await _context.Button.FindAsync(id);
            if (button == null)
            {
                return NotFound();
            }
            return View(button);
        }

        // POST: Buttons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Colour,Shape,Price")] Button button)
        {
            if (id != button.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(button);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ButtonExists(button.Id))
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
            return View(button);
        }

        // GET: Buttons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var button = await _context.Button
                .FirstOrDefaultAsync(m => m.Id == id);
            if (button == null)
            {
                return NotFound();
            }

            return View(button);
        }

        // POST: Buttons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var button = await _context.Button.FindAsync(id);
            _context.Button.Remove(button);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ButtonExists(int id)
        {
            return _context.Button.Any(e => e.Id == id);
        }
    }
}
