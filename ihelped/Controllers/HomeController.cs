using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ihelped.Models;

namespace ihelped.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Coins()
        {
            return View();
        }

        public IActionResult Allotment()
        {
            return View();
        }

        public IActionResult Referral()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
