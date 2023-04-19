using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Flower.Models
{
    public class AccountMetaData
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Username { get; set; }
        //[RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})")]
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
       

    }
    [ModelMetadataType(typeof(AccountMetaData))]
    public partial class Account
    {

    }
}
