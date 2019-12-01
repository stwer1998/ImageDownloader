using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDownloader.Models
{
    public class ImageModel
    {
        [Key]
        [Required]
        public string Link { get; set; }

        public string NameImage { get; set; }

        public string PathImage { get; set; }

        public string Format { get; set; }

        public ImageModel(string link)
        {
            var url = new Uri(link);
            Link = url.Scheme+ "://" + url.Host + url.PathAndQuery;
            NameImage = url.Segments[url.Segments.Length - 1];
            if (!NameImage.Contains('.'))
            {
                NameImage += ".jpeg";
                Format = ".jpeg";
            }
            else 
            {
                var fo = NameImage.Split(".");
                Format ="."+fo[fo.Length-1];
            }
        }

        public ImageModel()
        {

        }
    }
}
