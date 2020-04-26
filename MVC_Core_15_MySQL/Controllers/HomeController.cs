using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Core_15_MySQL.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_15_MySQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BookmarkDbContext _db;

        public HomeController(ILogger<HomeController> logger, BookmarkDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var connectionString = "datasource=philanderson888-bookmarks-database-instance-1.cn3xrn5siaes.eu-west-2.rds.amazonaws.com;port=3306;username=databaseadmin;password=Pa$$w0rdPa$$w0rd";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                System.Diagnostics.Trace.WriteLine("connection is " + connection.State);

                

                string sqlstring = "CREATE TABLE BOOKMARKS (BookmarkId INT NOT NULL PRIMARY KEY IDENTITY, BookmarkName VARCHAR(50),BookmarkUrl VARCHAR(150))";
                sqlstring = "SELECT table_name FROM information_schema.tables";
                using (var sqlcommand = new MySqlCommand(sqlstring, connection))
                {
                    var sqlreader = sqlcommand.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        string table_name = sqlreader["table_name"].ToString();
                        System.Diagnostics.Trace.WriteLine("table name is " + table_name);
                    }
                }



                sqlstring = "USE bookmarks_database; select * from bookmarks";
                using (var sqlcommand= new MySqlCommand(sqlstring, connection))
                {
                    var sqlreader = sqlcommand.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        string bookmarkname = sqlreader["BookmarkName"].ToString();
                        string bookmarkurl = sqlreader["BookmarkUrl"].ToString();
                        Trace.WriteLine(bookmarkname);
                        Trace.WriteLine(bookmarkurl);

                    }
                }



         


            }
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
