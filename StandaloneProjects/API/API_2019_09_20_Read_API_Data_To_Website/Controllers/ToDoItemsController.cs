using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace API_2019_09_20_Read_API_Data_To_Website.Controllers
{
    public class ToDoItemsController : Controller
    {
        static List<ToDoList> todoitems = new List<ToDoList>();
        static string url = "https://localhost:44300/api/ToDoLists";
        // GET: ToDoItems
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var fullToDoList = client.GetStringAsync(url);
                todoitems = JsonConvert.DeserializeObject<List<ToDoList>>(fullToDoList.Result);

            }
            return View(todoitems);
        }



        // GET: ToDoItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItems/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}