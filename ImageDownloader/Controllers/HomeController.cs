using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImageDownloader.Models;

namespace ImageDownloader.Controllers
{
    public class HomeController : Controller
    {
        private DataRepository db;
        private Downloader dw;
        public HomeController(DataRepository db,Downloader dw)
        {
            this.db = db;
            this.dw = dw;
        }

        public IActionResult Index()
        {
            return View(db.GetAllImage());
        }

        public IActionResult AddImage() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(string[] links)
        {
            return View("Result", dw.Download(links));
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
