using Crud_with_ADO_in_core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_with_ADO_in_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EmployeeDataAccess dataAccess;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dataAccess = new EmployeeDataAccess();
        }

        public IActionResult Index()
        {
            var emps = dataAccess.GetEmployees();
            return View(emps);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {

            if (ModelState.IsValid == true)
            {
                EmployeeDataAccess dataAccess = new EmployeeDataAccess();
                bool check = dataAccess.AddEmployee(emp);
                if (check == true)
                {
                    TempData["ImsertMessage"] = "Data inserted successfully";
                    ModelState.Clear();
                    RedirectToAction("Index");
                }
            }
            return View("Index");



        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
