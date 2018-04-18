using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarApp.Models;

namespace SeminarApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Translate(String translateWord)
        {
            Console.WriteLine(translateWord);
            return View();
        }

    }
}
