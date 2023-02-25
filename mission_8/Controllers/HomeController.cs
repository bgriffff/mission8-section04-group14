using Microsoft.AspNetCore.Mvc;
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
        private TaskInfoContext TaskContext { get; set; }

        public HomeController(TaskInfoContext Task)
        {
            TaskContext = Task;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskResponse ar)
        {
            if (ModelState.IsValid)
            {
                TaskContext.Add(ar);
                TaskContext.SaveChanges();

                return RedirectToAction("Index", ar);
            }
            else // If Invalid
            {
                //ViewBag.Categories = TaskContext.Categories.ToList();
                return View(ar);
            }

        }

        [HttpGet]
        public IActionResult TaskList()
        {
            var application = TaskContext.Responses
                //.Include(x => x.Category)
                .ToList();

            return View(application);
        }


        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            //ViewBag.Categories = TaskContext.Categories.ToList();

            //find the single record
            var task = TaskContext.Responses.Single(x => x.TaskId == taskid);

            return View("AddTask", task);
        }

        [HttpPost]
        public IActionResult EditTask(TaskResponse edit)
        {
            if (ModelState.IsValid)
            {
                TaskContext.Update(edit);
                TaskContext.SaveChanges();

                // need to send them to the action. not the view
                return RedirectToAction("TaskList");
            }
            else
            {
                //ViewBag.Categories = TaskContext.Categories.ToList();
                return View("AddTask", edit);
            }

        }

        //Delete Movies
        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            //ViewBag.Categories = TaskContext.Categories.ToList();

            //find the single record
            var task = TaskContext.Responses.Single(x => x.TaskId == taskid);


            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteTask(TaskResponse delete, int taskid)
        {

            var task = TaskContext.Responses.Single(x => x.TaskId == taskid);
            TaskContext.Remove(delete);
            TaskContext.SaveChanges();

            // need to send them to the action. not the view
            return RedirectToAction("TaskList");
        }
    }
}
