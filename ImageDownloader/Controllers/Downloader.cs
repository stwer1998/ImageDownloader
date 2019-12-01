using ImageDownloader.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ImageDownloader.Controllers
{
    public class Downloader
    {
        private IWebHostEnvironment appEnvironment;
        private DataRepository db;
        public Downloader(IWebHostEnvironment appEnvironment, DataRepository db)
        {
            this.appEnvironment = appEnvironment;
            this.db = db;
        }
        /// <summary>
        /// Скачивание изображений
        /// </summary>
        /// <param name="links"></param>
        /// <returns></returns>
        public string Download(string[] links) 
        {
            string result = string.Empty;

            foreach (var item in links)
            {
                result += DownLoadFile(item);
            }

            return result;
        }
        /// <summary>
        /// Скачивание изображении
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private string DownLoadFile(string src)
        {
            if (db.ChackFileUrl(src))
            {
                var image = new ImageModel(src);
                image.PathImage = Shorter() + image.Format;
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile(image.Link, appEnvironment.WebRootPath + "\\" + image.PathImage);
                    }
                    db.AddImage(image);
                    return image.Link + " Downloaded  ";
                }
                catch (Exception e)
                {
                    return image.Link + " Something wrong ";
                }
            }
            else return src + "  We have this image  ";
        }
        /// <summary>
        /// Метод будет подбирать имя для файла
        /// </summary>
        /// <returns></returns>
        private string Shorter()
        {//создает короткую имя пока не найдет не использованного
            string result = GetUniqueKey(3);
            while (!db.CheckFileName(result))
            {
                result = GetUniqueKey(3);
            }
            return result;
        }
        /// <summary>
        /// Генератор случайных строк для имени файла
        /// </summary>
        /// <param name="size">число символов</param>
        /// <returns></returns>
        private string GetUniqueKey(int size)
        {//генератор случайных строк
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}
