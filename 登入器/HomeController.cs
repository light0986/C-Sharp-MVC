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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private DatabaseContext db;

        public HomeController(DatabaseContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(IFormCollection post)
        {
            string account = post["ACCOUNT"];
            string password = post["PASSWORD"];
            DBconnAcc dBconnAcc = new DBconnAcc();
            //驗證密碼
            if (dBconnAcc.CheckUserData(account, password))
            {

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("Name",account,options);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg = "登入失敗...";
                return View();
            }
        }

        public IActionResult Logout()
        {
            if(Request.Cookies["Name"] !=null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Delete("Name");
            }
            return RedirectToAction("Index");
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

        public IActionResult CreatAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatAccount(MS_ACCOUNT mS_ACCOUNT)
        {
            DBconnAcc dBconnAcc = new DBconnAcc();
            dBconnAcc.CreateAcc(mS_ACCOUNT);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
