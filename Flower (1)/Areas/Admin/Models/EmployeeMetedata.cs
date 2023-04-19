using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Flower.Areas.Admin.Models
{
    public class EmployeeMetedata
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Username { get; set; }
        //dat dieu kien cho password
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})")]
        [Required]

        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Range(18, 100)]
        public int Age { get; set; }
    }
    [ModelMetadataType(typeof(EmployeeMetedata))]
    public partial class Employee
    {

    }
}

