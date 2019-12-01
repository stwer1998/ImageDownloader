using System;
using System.ComponentModel.DataAnnotations;

namespace ImageDownloader.Models
{
    public class ImageModel
    {
        /// <summary>
        /// Ссылка на изображение(источник)
        /// </summary>
        [Key]
        [Required]
        public string Link { get; set; }
        /// <summary>
        /// Наименование изображение
        /// </summary>
        public string NameImage { get; set; }
        /// <summary>
        /// Расположение файла не сервере
        /// </summary>
        public string PathImage { get; set; }
        /// <summary>
        /// Формат изображение
        /// </summary>
        public string Format { get; set; }

        public ImageModel(string link)
        {//не все ссылки содержат формат файла если его нет по умолчанию зделаем jpeg
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
