using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.Net_MVC.Models
{
    public class Employee
    {
        public Employee() { }

        public Employee(int id, string firstName, string lastName, DateTimeOffset birthDate, int departmentId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Department_Id = departmentId;
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }

        public int Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public Department Department { get; set; }
    }
}