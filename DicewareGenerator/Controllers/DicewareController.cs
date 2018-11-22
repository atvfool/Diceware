using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DicewareGenerator.Models;

namespace DicewareGenerator.Controllers
{
    public class DicewareController : Controller
    {

        // GET: Diceware
        public IActionResult Diceware()
        {
            return View();
        }

    }
}
