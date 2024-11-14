using CourtAuthIdentityServer.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace CourtAuthIdentityServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error(string errorId)
        {
            var message = await _interaction.GetErrorContextAsync(errorId);
            return View(message);
        }

    }

  
}
