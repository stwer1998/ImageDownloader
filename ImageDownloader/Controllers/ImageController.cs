using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using ImageDownloader.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ImageDownloader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IHostingEnvironment appEnvironment;
        public ImageController(IHostingEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }
        [HttpGet]
        public string Download()
        {
            return "Ok";
        }

        [HttpPost]
        public string Download([FromQuery]string[] links)
        {
            string result = string.Empty;

            foreach (var item in links)
            {
                result += DownLoadFile(item);
            }

            return result;
        }


        private string DownLoadFile(string src)
        {
            var link = new ImageModel(src);
            string path = "/images/" + link.NameImage;
            var a = appEnvironment.WebRootPath + "\\" + link.NameImage;
            try
            {
                using (var wc = new WebClient() )
                {
                    wc.DownloadFile(link.Link, a);
                }
                return link.Link + " Downloaded  ";
            }
            catch (Exception e)
            {
                return link.Link + " Something wrong ";
            }
        }

    }
}