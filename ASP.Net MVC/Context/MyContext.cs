using ASP.Net_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.Net_MVC.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection") { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}