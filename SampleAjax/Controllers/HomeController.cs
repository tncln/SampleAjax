using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleAjax.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleAjax.Controllers
{
    public class HomeController : Controller
    {
        private List<Kullanici> kullanicilar;
        private readonly ILogger<HomeController> _logger;

       
        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            Thread.Sleep(10000);
            var jsonkullanici = JsonConvert.SerializeObject(kullanicilar);
            return Json(jsonkullanici);
        }
        public IActionResult GetById(int id)
        {
            var bulunanKullanici = KullaniciIslem.GetirId(id);
            var jsonKullanici = JsonConvert.SerializeObject(bulunanKullanici);
            return Json(jsonKullanici);
        }
        [HttpPost]
        public IActionResult Ekle(Kullanici kullanici)
        {
            KullaniciIslem.Ekle(kullanici);
            var jsonKullanici = JsonConvert.SerializeObject(kullanici);
            return Json(jsonKullanici);

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
