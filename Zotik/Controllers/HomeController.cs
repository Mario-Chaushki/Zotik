﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zotik.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.Title = "Начална страница";
            return View();
        }

        public IActionResult Products()
        {
            ViewBag.Title = "Продукти";
            return View();
        }
    }
}