using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CourtAuthIdentityServer.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            // Display a custom login view
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
    }

   

public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool RememberLogin { get; set; } = false;

        public string ReturnUrl { get; set; }
    }
}
