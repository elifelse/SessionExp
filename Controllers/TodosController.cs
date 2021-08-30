using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionExp.Extensions;
using SessionExp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionExp.Controllers
{
    public class TodosController : Controller
    {
        public IActionResult Index()
        {
            List<Todo> todos = HttpContext.Session.Get<List<Todo>>("todos");
            return View();
        }

        [HttpPost]
        public IActionResult Index(Todo todo)
        {
            if (ModelState.IsValid)
            {
                List<Todo> todos = HttpContext.Session.Get<List<Todo>>("todos");
                todos.Add(todo);
                HttpContext.Session.Set("todos", todos);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
