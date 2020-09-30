using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DicewareGenerator.Models;

namespace DicewareGenerator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DicewareModel model)
        {
            Diceware.Diceware dw = new Diceware.Diceware(model.SelectedWordList, model.PasswordLength, model.PasswordDelimitter==null?string.Empty : model.PasswordDelimitter);
            model.GeneratedPassword = dw.GetPassword();


            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Diceware()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
