using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
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

        public IActionResult QRcode(URLView vm)
        {
            ViewData["showMsg"] = vm.urlview();
            return View();
        }

        public IActionResult ReadTxt()
        {
            return View();
        }

        public IActionResult check(string button)
        {
            var path = "./test.txt";
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
            DBmanager dbmanager = new DBmanager();
            List<MS_PRODUCT> ms_products = dbmanager.GetPRODUCTs();
            ViewBag.ms_product = ms_products;
            return View();
        }
        public IActionResult MSSQL_Create_Product()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MSSQL_Create_Product(MS_PRODUCT mS_PRODUCT)
        {
            DBmanager dbmanager = new DBmanager();
            dbmanager.Create(mS_PRODUCT);
            return RedirectToAction("MSSQL");
        }

        public IActionResult MSSQL_Edit(int id)
        {
            DBmanager dBmanager = new DBmanager();
            MS_PRODUCT mS_PRODUCT = dBmanager.GetID(id);
            return View(mS_PRODUCT);
        }

        [HttpPost]
        public IActionResult MSSQL_Edit(MS_PRODUCT mS_PRODUCT)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.UpdateProduct(mS_PRODUCT);
            return RedirectToAction("MSSQL");
        }

        public IActionResult MSSQL_DELETE(int id)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.DeleteProduct(id);
            return RedirectToAction("MSSQL");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
