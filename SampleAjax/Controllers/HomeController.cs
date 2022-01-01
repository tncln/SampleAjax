using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleAjax.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAjax.Controllers
{
    public class HomeController : Controller
    {
        private List<Kullanici> kullanicilar;
        private readonly ILogger<HomeController> _logger;

       
        public HomeController(ILogger<HomeController> logger)
        {
            kullanicilar = new List<Kullanici> {
            new Kullanici{ Ad="test", Id=1},
            new Kullanici{ Ad="test2", Id=2},
            new Kullanici { Ad = "test3", Id = 3 },
            new Kullanici { Ad = "test4", Id = 4 },
            };
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var jsonkullanici = JsonConvert.SerializeObject(kullanicilar);
            return Json(jsonkullanici);
        }
        public IActionResult GetById(int id)
        {
            var jsonkullanici = JsonConvert.SerializeObject(kullanicilar.Where(x => x.Id == id));
            return Json(jsonkullanici);
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
