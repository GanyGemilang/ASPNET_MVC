using ASP.Net_MVC.Context;
using ASP.Net_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        MyContext myContext = new MyContext();
        // GET: Departments
        public ActionResult Index()
        {
            var result = myContext.Departments.ToList();
            return View(result);
        }

        public ActionResult Edit(int Id)
        {
            var result = myContext.Departments.Find(Id);
            if (result != null)
            {
                return View(result);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string name, DateTimeOffset createdOn)
        {
            var department = new Department(id, name, createdOn);
            myContext.Entry(department).State = EntityState.Modified;
            var result = myContext.SaveChanges();

            if(result > 0)
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}