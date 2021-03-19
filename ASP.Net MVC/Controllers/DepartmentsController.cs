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

        public ActionResult Create()
        {
            ViewBag.Division_Id = new SelectList(myContext.Divisions, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, DateTimeOffset createdOn, int Division_Id)
        {
            var department = new Department(0, name, createdOn, Division_Id);
            myContext.Departments.Add(department);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var result = myContext.Departments.Find(Id);
            if (result != null)
            {
                ViewBag.Division_Id = new SelectList(myContext.Divisions, "Id", "Name");
                return View(result);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string name, DateTimeOffset createdOn, int Division_Id)
        {
            var department = new Department(id, name, createdOn, Division_Id);
            myContext.Entry(department).State = EntityState.Modified;
            var result = myContext.SaveChanges();

            if(result > 0)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var department = myContext.Departments.Find(id);
            if (department != null)
            {
                myContext.Departments.Remove(department);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}