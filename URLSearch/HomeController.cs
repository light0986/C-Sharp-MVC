using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC01.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace MVC01.Controllers
{

    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private DatabaseContext db;

        //public HomeController(ILogger<HomeController> logger)
        //{    _logger = logger;  }

        public HomeController(DatabaseContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy(){return View();}

        public ActionResult Privacy(URLView vm)
        {
            ViewData["showMsg"] = vm.urlview();

            return View(vm);
        }

        public IActionResult ReadTxt()
        {
            return View();
        }

        public IActionResult check(string button)
        {
            var path = "/Users/light0986/Documents/c#/MVC01/file/test.txt";
            StreamReader reader = new StreamReader(path);
            var input = reader.ReadLine();
            if (button == "first")
            {
                TempData["puttonval"] = input;
             }
            return RedirectToAction("ReadTxt");
        }

        public IActionResult SQLite()
        {
            ViewBag.products = db.Product.ToList();
            return View();
        }

        public IActionResult MSSQL()
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
