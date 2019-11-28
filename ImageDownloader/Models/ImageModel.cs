using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDownloader.Models
{
    public class ImageModel
    {
        public string Link { get; set; }

        public string NameImage { get; set; }

        public ImageModel(string link)
        {
            var url = new Uri(link);
            Link = url.Scheme+ "://" + url.Host + url.PathAndQuery;
            NameImage = url.Segments[url.Segments.Length - 1];
            if (!NameImage.Contains('.')) 
            {
                NameImage += ".jpeg";
            }
        }
    }
}
