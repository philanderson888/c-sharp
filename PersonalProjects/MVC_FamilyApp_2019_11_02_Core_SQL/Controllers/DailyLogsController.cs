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
            foreach (var item in dataSet)
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
            #region GetAndDisplayGymStats
            int madeGymLast7Days = dataSetLast7Days.Where(log => log.MadeGym == true).Count();
            int madeGymLast14Days = dataSetLast14Days.Where(log => log.MadeGym == true).Count();
            int madeGymLast30Days = dataSet.Where(log => log.MadeGym == true).Count();
            ViewBag.madeGymLast7Days = madeGymLast7Days;
            ViewBag.madeGymLast14Days = madeGymLast14Days;
            ViewBag.madeGymLast30Days = madeGymLast30Days;
            ViewBag.percentageGymLast7Days = (int)(madeGymLast7Days / 7.0 * 100);
            ViewBag.percentageGymLast14Days = (int)(madeGymLast14Days / 14.0 * 100);
            ViewBag.percentageGymLast30Days = (int)(madeGymLast30Days / 30.0 * 100);
            #endregion GetAndDisplayGymStats
            #region GetAndDisplayAllTimeStats
            dataSet = await _context.DailyLogs.OrderByDescending(log => log.LogDate).ToListAsync();
            int totalCountOfAllStatsFromTheBeginning = dataSet.Where(log => log.UpOnTime == true).Count();
            ViewBag.allTimePercentageSuccess = (int)(totalCountOfAllStatsFromTheBeginning / (double)dataSet.Count() * 100);
            #endregion
            #region displayRandomThoughtsAndIdeas
            var ThoughtsAndIdeas = new List<String>();
            ThoughtsAndIdeas.Add("Buy One Spreadshirt This Week 10 Jan");
            ThoughtsAndIdeas.Add("Change my GamerID To BattlePhil");
            ThoughtsAndIdeas.Add("Don't set the snooze button at all");
            ThoughtsAndIdeas.Add("Set a deadline to QUIT WORKING every day");
            ThoughtsAndIdeas.Add("Most efficient use of time - praying on Stair Master and Running Machine");
            ThoughtsAndIdeas.Add("Family Peace 'sh' with my finger and wait 10 seconds.  Have peace in the meetings.  Never argue in front of the group");
            ThoughtsAndIdeas.Add("If you promise to speak no words then I will promise to keep the meeting below 5 minutes");
            ThoughtsAndIdeas.Add("Present the 'worst ever' presentation of the gospel in order to lose the 'fear of perfection'   Why don't you set out to present the 'worst' ever presentation of the Gospel?  Then you can't complain if it's bad!  I think you'll do really good actually at presenting really well so don't be afraid of perfection - aim for the worst possible presentation of the Gospel and you will achieve far higher.");
            ThoughtsAndIdeas.Add("Get out of work early!");
            ThoughtsAndIdeas.Add("Tell people who ask - 'God told me to get up early and pray before I go to the gym so I do that for 40 minutes from 430 to 510am'");
            ThoughtsAndIdeas.Add("Pray for Kate at the gym - small, quiet and friendly");
            ThoughtsAndIdeas.Add("I can communicate with Jonathan via video on YouTube to Email");
            ThoughtsAndIdeas.Add("Remove all the coats from all the hooks and replace them");
            ThoughtsAndIdeas.Add("I can communicate with Mark via phone voicemail also Skype voicemail also email - lots of ways");
            ThoughtsAndIdeas.Add("I can communicate with Michael via phone, leave voicemail on Sunday morning, email and letter");
            ThoughtsAndIdeas.Add("Idea for all kids - have a single number which is the combined score on my database!");
            ThoughtsAndIdeas.Add("Weekly - Write down everything in my tub");
            ThoughtsAndIdeas.Add("Weekly - Write down all emails/texts/whatsapp");
            ThoughtsAndIdeas.Add("Weekly - Write down all todo items");

            ViewBag.ThoughtsAndIdeasList = ThoughtsAndIdeas;

            #endregion displayRandomThoughtsAndIdeas
            #region Mess Around With Passwords And The Password Hash
            string Base64HashStraightFromDatabase = user.PasswordHash;
            byte[] passwordHashRawByteArray = Convert.FromBase64String(Base64HashStraightFromDatabase);
            string passwordStringFromRawByteArray = string.Join(',', passwordHashRawByteArray);
            ViewBag.Base64HashStraightFromDatabase = Base64HashStraightFromDatabase;
            ViewBag.passwordStringFromRawByteArray = passwordStringFromRawByteArray;
            #endregion
            #region Now Split The Byte Array Apart
            ViewBag.ByteZero = passwordHashRawByteArray[0].ToString();
            ViewBag.ByteFour = passwordHashRawByteArray[4].ToString();
            ViewBag.Iterations = "";
            #endregion
            return View(dataSet);
        }
        #endregion
        #region View - One Log
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
        #endregion View - One Log
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
        public async Task<IActionResult> Create([Bind("DailyLogId,LogDate,Comments,UpOnTime,StayedUp,MadeGym,PrWthFam,PrWthZ,CrsPryPhoto,PhilPryPhoto,CrsDeskPhoto,NbrSns,NbrGrps,GymCardio,GymWeights,GymSprints,GymChest,GymBack,GymLegs,GymBicep,GymTricep,GymShoulders,GymClass,GymDips,GymPullUps,GymPushUps,NmbrPrtnScps,SnkCln,WlkRndOffc,ScrptrOfThDy,ScrptrOfThDyChrst,ScrptrOfThDyPhlp,ScrptrOfThDyJms,ScrptrOfThDyJhn,ScrptrOfThDyHnnh")] DailyLog dailyLog)
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
        public async Task<IActionResult> Edit(int id, [Bind("DailyLogId,LogDate,Comments,UpOnTime,StayedUp,MadeGym,PrWthFam,PrWthZ,CrsPryPhoto,PhilPryPhoto,CrsDeskPhoto,NbrSns,NbrGrps,GymCardio,GymWeights,GymSprints,GymChest,GymBack,GymLegs,GymBicep,GymTricep,GymShoulders,GymClass,GymDips,GymPullUps,GymPushUps,NmbrPrtnScps,SnkCln,WlkRndOffc,ScrptrOfThDy,ScrptrOfThDyChrst,ScrptrOfThDyPhlp,ScrptrOfThDyJms,ScrptrOfThDyJhn,ScrptrOfThDyHnnh")] DailyLog dailyLog)
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
