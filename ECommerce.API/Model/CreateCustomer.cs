using ECommerce.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Model
{
    public class CreateCustomer
    {
        [Required(ErrorMessage ="Customer first name is required")]
        public string? CustomerFirstName { get; set; }
        [Required(ErrorMessage ="Customer last name is required")]
        public string? CustomerlastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage ="Confirm password")]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
