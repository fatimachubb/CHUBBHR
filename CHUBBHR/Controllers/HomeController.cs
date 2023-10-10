using CHUBBHR.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using System;

namespace CHUBBHR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<ExampleClass> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<ExampleClass> localizer)
        {
            _logger = logger;
            _localizer = localizer;
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }

    public class ExampleClass
    {
        private readonly IStringLocalizer<ExampleClass> _localizer;

        public ExampleClass(IStringLocalizer<ExampleClass> localizer)
        {
            _localizer = localizer;
        }

        public string GetLocalizedString()
        {
            return _localizer["MyLocalizedStringKey"];
        }
    }
}
