using ImageDownloader.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImageDownloader
{
    public class DataRepository
    {
        private MyDbContext db;
        public DataRepository(MyDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Добавить новый элемент
        /// </summary>
        /// <param name="imageModel"></param>
        public void AddImage(ImageModel imageModel) 
        {
            db.ImageModels.Add(imageModel);
            db.SaveChanges();
        }
        /// <summary>
        /// Проверяет не занет ли имя файла
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckFileName(string name) 
        {
            var image = db.ImageModels.FirstOrDefault(x => x.PathImage == name);
            if (image!=null&&image.PathImage == name)
            {
                return false;
            }
            else return true;
        }
        /// <summary>
        /// Проверяет не скачен ли файл раньше
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public bool ChackFileUrl(string link) 
        {
            var image = db.ImageModels.FirstOrDefault(x => x.Link == link);
            if (image !=null&&image.Link == link)
            {
                return false;
            }
            else return true;
        }
        /// <summary>
        /// Вернет все элементы
        /// </summary>
        /// <returns></returns>
        public List<ImageModel> GetAllImage() 
        {
            return db.ImageModels.ToList();
        }
    }
}
