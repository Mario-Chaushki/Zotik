using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zotik.Models;

namespace Zotik.Controllers
{
    public class HomeController : Controller
    {
        private readonly PadsContext context;

        public HomeController(PadsContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Начална страница";
            return View();
        }

        public IActionResult Products()
        {
            ViewBag.Title = "Продукти";

            var pads = context.Pad.ToList(); ////Your model that you want to pass
            return View(pads);
        }
    }
}