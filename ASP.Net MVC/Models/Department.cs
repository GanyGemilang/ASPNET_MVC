using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.Net_MVC.Models
{
    public class Department
    {
        public Department() { }
        public Department(int id, string name, DateTimeOffset createdOn, int divisionId)
        {
            Id = id;
            Name = name;
            CreatedOn = createdOn;
            Division_Id = divisionId;

        }


        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }

        public int Division_Id { get; private set; }
        [ForeignKey("Division_Id")]
        public Division Division { get; set; }
    }
}