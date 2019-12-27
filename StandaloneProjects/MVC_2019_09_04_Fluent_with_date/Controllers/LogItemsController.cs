using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_2019_09_04_Fluent_with_date;

namespace MVC_2019_09_04_Fluent_with_date.Controllers
{
    public class LogItemsController : Controller
    {
        private readonly LogItemDbContext _context;

        public LogItemsController(LogItemDbContext context)
        {
            _context = context;
        }

        // GET: LogItems
        public async Task<IActionResult> Index()
        {
            var logItemDbContext = _context.LogItems.Include(l => l.Category);
            return View(await logItemDbContext.ToListAsync());
        }

        // GET: LogItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logItem = await _context.LogItems
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.LogItemId == id);
            if (logItem == null)
            {
                return NotFound();
            }

            return View(logItem);
        }

        // GET: LogItems/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: LogItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogItemId,LogItemDescription,LogItemPoints,CategoryId")] LogItem logItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", logItem.CategoryId);
            return View(logItem);
        }

        // GET: LogItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logItem = await _context.LogItems.FindAsync(id);
            if (logItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", logItem.CategoryId);
            return View(logItem);
        }

        // POST: LogItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogItemId,LogItemDescription,LogItemPoints,CategoryId")] LogItem logItem)
        {
            if (id != logItem.LogItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogItemExists(logItem.LogItemId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", logItem.CategoryId);
            return View(logItem);
        }

        // GET: LogItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logItem = await _context.LogItems
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.LogItemId == id);
            if (logItem == null)
            {
                return NotFound();
            }

            return View(logItem);
        }

        // POST: LogItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logItem = await _context.LogItems.FindAsync(id);
            _context.LogItems.Remove(logItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogItemExists(int id)
        {
            return _context.LogItems.Any(e => e.LogItemId == id);
        }
    }
}
