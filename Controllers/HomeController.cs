using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionExp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SessionExp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("ad", kisi.Ad);

                // ad'ı session'da bir liste içine ekle
                string kisilerJson = HttpContext.Session.GetString("kisiler");

                // eğer liste henüz oluşmamışsa
                if (string.IsNullOrEmpty(kisilerJson))
                {
                    kisilerJson = JsonSerializer.Serialize(new List<Kisi>());
                    HttpContext.Session.SetString("kisiler", kisilerJson);
                }

                List<Kisi> kisiler = JsonSerializer.Deserialize<List<Kisi>>(kisilerJson);
                kisiler.Add(kisi);
                HttpContext.Session.SetString("kisiler", JsonSerializer.Serialize(kisiler));

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Unut()
        {
            HttpContext.Session.Clear(); // uygulamadaki session datasını siler ancak session cookie'sini kaldırmaz
            return RedirectToAction(nameof(Index));
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
