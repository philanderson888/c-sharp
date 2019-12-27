#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_FamilyApp_2019_11_02_Core_SQL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Internal;
using Microsoft.AspNetCore.Http;
using EntityFramework.Toolkit;
using System.Web.Providers.Entities;
#endregion
namespace MVC_FamilyApp_2019_11_02_Core_SQL.Controllers
{
    public class DailyLogsController : Controller
    {
        #region Private Fields - Database And User
        private readonly FamilyDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        #endregion
        #region Constructor - Get Database And Current Logged-In User Details
        public DailyLogsController(FamilyDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        #endregion
        #region View - All Logs
        [Authorize]
        public async Task<IActionResult> Index()
        {
            #region GetLoggedInUserDetails
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.username = user.UserName;
            ViewBag.emailConfirmed = user.EmailConfirmed;
            ViewBag.isAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;
            ViewBag.AuthenticationType = User.Identity.AuthenticationType;
            
            #endregion
            #region GetAndDisplayStatsForLast30Days
            List<DailyLog> dataSet = await _context.DailyLogs.Take(30).OrderByDescending(dl => dl.LogDate).ToListAsync();
            int upOnTimeInLast30Days = dataSet.Where(log => log.UpOnTime == true).Count();
            int percentageUpOnTimeInLast30Days = (int)(upOnTimeInLast30Days / 30.0 * 100);
            ViewBag.upOnTimeInLast30Days = upOnTimeInLast30Days;
            ViewBag.percentageUpOnTimeInLast30Days = percentageUpOnTimeInLast30Days;
            ViewBag.above70PercentUpOnTimeInLast30Days = (percentageUpOnTimeInLast30Days >= 70);
            #endregion
            #region DisplayRunOfRecentForm
            int countOfRecentFormMissingOnlyMaximumOneDay = 0;
            bool missedOneDay = false;
            foreach(var item in dataSet)
            {
                // count number of times getting up successfully with max one day break
                if (item.UpOnTime == true) countOfRecentFormMissingOnlyMaximumOneDay++;
                else
                {
                    if (missedOneDay) break; // cannot miss 2 days!
                    else missedOneDay = true;
                }
            }
            ViewBag.countofRecentFormMissingOnlyMaximumOneDay = countOfRecentFormMissingOnlyMaximumOneDay;
            #endregion DisplayRunOfRecentForm
            #region Get AndDisplayStatsForLast7Days
            List<DailyLog> dataSetLast7Days = dataSet.Take(7).ToList();
            int countUpOnTimeInLast7Days = dataSetLast7Days.Where(log => log.UpOnTime == true).Count();
            ViewBag.countUpOnTimeInLast7Days = countUpOnTimeInLast7Days;
            ViewBag.percentageUpOnTimeInLast7Days = (int)(countUpOnTimeInLast7Days / 7.0 * 100);
            #endregion
            #region GetAndDisplayStatsForLast14Days
            List<DailyLog> dataSetLast14Days = dataSet.Take(14).ToList();
            int countUpOnTimeInLast14Days = dataSetLast14Days.Where(log => log.UpOnTime == true).Count();
            ViewBag.countUpOnTimeInLast14Days = countUpOnTimeInLast14Days;
            ViewBag.percentageUpOnTimeInLast14Days = (int)(countUpOnTimeInLast14Days / 14.0 * 100);
            #endregion
            #region Temporary Extra Code To Put In Lines For Data Input
            dataSet = await _context.DailyLogs.OrderByDescending(log=>log.LogDate).ToListAsync();
            int totalCountOfAllStatsFromTheBeginning = dataSet.Where(log => log.UpOnTime == true).Count();
            ViewBag.allTimePercentageSuccess = (int)(totalCountOfAllStatsFromTheBeginning / (double)dataSet.Count() * 100);
            #endregion
            return View(dataSet);
        }
        #endregion
        #region View - One Log
        // GET: DailyLogs/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyLog = await _context.DailyLogs
                .FirstOrDefaultAsync(m => m.DailyLogId == id);
            if (dailyLog == null)
            {
                return NotFound();
            }

            return View(dailyLog);
        }
        #endregion
        #region Insert - One Log
        // GET: DailyLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyLogId,LogDate,Comments,UpOnTime,StayedUp,MadeGym,PrWthFam,PrWthZ,CrsPryPhoto,PhilPryPhoto,CrsDeskPhoto,NbrSns")] DailyLog dailyLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyLog);
        }
        #endregion
        #region Edit One Log
        // GET: DailyLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyLog = await _context.DailyLogs.FindAsync(id);
            if (dailyLog == null)
            {
                return NotFound();
            }
            return View(dailyLog);
        }

        // POST: DailyLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyLogId,LogDate,Comments,UpOnTime,StayedUp,MadeGym,PrWthFam,PrWthZ,CrsPryPhoto,PhilPryPhoto,CrsDeskPhoto,NbrSns")] DailyLog dailyLog)
        {
            if (id != dailyLog.DailyLogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyLogExists(dailyLog.DailyLogId))
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
            return View(dailyLog);
        }
        #endregion
        #region Delete One Log
        // GET: DailyLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyLog = await _context.DailyLogs
                .FirstOrDefaultAsync(m => m.DailyLogId == id);
            if (dailyLog == null)
            {
                return NotFound();
            }

            return View(dailyLog);
        }

        // POST: DailyLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyLog = await _context.DailyLogs.FindAsync(id);
            _context.DailyLogs.Remove(dailyLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Does A Log Exist
        private bool DailyLogExists(int id)
        {
            return _context.DailyLogs.Any(e => e.DailyLogId == id);
        }
        #endregion
    }
}
