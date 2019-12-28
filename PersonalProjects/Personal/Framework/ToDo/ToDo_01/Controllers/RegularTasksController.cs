using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDo_01;

namespace ToDo_01.Controllers
{
    public class RegularTasksController : Controller
    {
        private ToDoEntities1 db = new ToDoEntities1();

        // GET: RegularTasks
        public async Task<ActionResult> Index()
        {
            var regularTasks = db.RegularTasks.Include(r => r.Category).Include(r => r.User);
            return View(await regularTasks.ToListAsync());
        }

        // GET: RegularTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegularTask regularTask = await db.RegularTasks.FindAsync(id);
            if (regularTask == null)
            {
                return HttpNotFound();
            }
            return View(regularTask);
        }

        // GET: RegularTasks/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: RegularTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RegularTaskID,CategoryID,Description,Done,UserID,DateDone")] RegularTask regularTask)
        {
            if (ModelState.IsValid)
            {
                db.RegularTasks.Add(regularTask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1", regularTask.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", regularTask.UserID);
            return View(regularTask);
        }

        // GET: RegularTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegularTask regularTask = await db.RegularTasks.FindAsync(id);
            if (regularTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1", regularTask.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", regularTask.UserID);
            return View(regularTask);
        }

        // POST: RegularTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RegularTaskID,CategoryID,Description,Done,UserID,DateDone")] RegularTask regularTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regularTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1", regularTask.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", regularTask.UserID);
            return View(regularTask);
        }

        // GET: RegularTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegularTask regularTask = await db.RegularTasks.FindAsync(id);
            if (regularTask == null)
            {
                return HttpNotFound();
            }
            return View(regularTask);
        }

        // POST: RegularTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RegularTask regularTask = await db.RegularTasks.FindAsync(id);
            db.RegularTasks.Remove(regularTask);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
