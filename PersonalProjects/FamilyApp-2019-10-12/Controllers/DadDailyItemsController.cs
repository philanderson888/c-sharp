using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FamilyApp_2019_10_12;

namespace MVC_Core_FamilyApp_2019_10_12_Sqlite.Controllers
{
    public class DadDailyItemsController : Controller
    {
        private readonly FamilyDbContext _context;

        public DadDailyItemsController(FamilyDbContext context)
        {
            _context = context;
        }

        // GET: DadDailyItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadDailyItems.ToListAsync());
        }

        // GET: DadDailyItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadDailyItem = await _context.DadDailyItems
                .FirstOrDefaultAsync(m => m.DadDailyItemId == id);
            if (dadDailyItem == null)
            {
                return NotFound();
            }

            return View(dadDailyItem);
        }

        // GET: DadDailyItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DadDailyItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DadDailyItemId,TodaysDate,UpOnTime,GetEarlyTrain,CallPhilip550,CallChrista550,WorkAtFinsburyPark,HitTheGym")] DadDailyItem dadDailyItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadDailyItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadDailyItem);
        }

        // GET: DadDailyItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadDailyItem = await _context.DadDailyItems.FindAsync(id);
            if (dadDailyItem == null)
            {
                return NotFound();
            }
            return View(dadDailyItem);
        }

        // POST: DadDailyItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DadDailyItemId,TodaysDate,UpOnTime,GetEarlyTrain,CallPhilip550,CallChrista550,WorkAtFinsburyPark,HitTheGym")] DadDailyItem dadDailyItem)
        {
            if (id != dadDailyItem.DadDailyItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadDailyItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadDailyItemExists(dadDailyItem.DadDailyItemId))
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
            return View(dadDailyItem);
        }

        // GET: DadDailyItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadDailyItem = await _context.DadDailyItems
                .FirstOrDefaultAsync(m => m.DadDailyItemId == id);
            if (dadDailyItem == null)
            {
                return NotFound();
            }

            return View(dadDailyItem);
        }

        // POST: DadDailyItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadDailyItem = await _context.DadDailyItems.FindAsync(id);
            _context.DadDailyItems.Remove(dadDailyItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadDailyItemExists(int id)
        {
            return _context.DadDailyItems.Any(e => e.DadDailyItemId == id);
        }
    }
}
