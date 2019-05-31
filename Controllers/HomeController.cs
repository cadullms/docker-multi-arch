using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using multi_arch.Models;
using System.Runtime.InteropServices;

namespace multi_arch.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var appLabel = _config.GetValue<string>("appLabel");
            var osArch = RuntimeInformation.OSArchitecture.ToString();
            var os = RuntimeInformation.OSDescription.ToString();
            var arch = RuntimeInformation.ProcessArchitecture.ToString();
            ViewData["Message"] = $"This is app '{appLabel}' on [Process Architecture: {arch}, OSArchitecture: {osArch}, OSDescription: {os}].";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
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
    }
}
