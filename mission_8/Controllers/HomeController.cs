﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission_8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission_8.Controllers
{
    public class HomeController : Controller
    {
        private TaskApplicationContext TaskContext { get; set; }

        public HomeController(TaskApplicationContext Task)
        {
            TaskContext = Task;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                TaskContext.Add(ar);
                TaskContext.SaveChanges();

                return RedirectToAction("Index", ar);
            }
            else // If Invalid
            {

                return View(ar);
            }

        }
    }
}
