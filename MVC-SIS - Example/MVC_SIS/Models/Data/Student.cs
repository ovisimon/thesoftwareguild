using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public Student()
        {
            Address = new Address();
            Courses = new List<Course>();
            Major = new Major();
        }

        public int StudentId { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public decimal GPA { get; set; }

        public Address Address { get; set; }
        
        public Major Major { get; set; }
        
        public List<Course> Courses { get; set; }
    }
}