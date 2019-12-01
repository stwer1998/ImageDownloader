using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using ImageDownloader.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ImageDownloader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        Downloader dw;
        public ImageController(IWebHostEnvironment appEnvironment,Downloader dw)
        {
            this.dw = dw;
        }

        [HttpPost]
        public string Download([FromQuery] string[] links)
        {
            return dw.Download(links);
        }

    }
}