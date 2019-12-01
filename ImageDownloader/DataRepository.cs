using ImageDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDownloader
{
    public class DataRepository
    {
        private MyDbContext db;
        public DataRepository(MyDbContext db)
        {
            this.db = db;
        }

        public void AddImage(ImageModel imageModel) 
        {
            db.ImageModels.Add(imageModel);
            db.SaveChanges();
        }

        public bool CheckFileName(string name) 
        {
            var image = db.ImageModels.FirstOrDefault(x => x.PathImage == name);
            if (image!=null&&image.PathImage == name)
            {
                return false;
            }
            else return true;
        }

        public bool ChackFileUrl(string link) 
        {
            var image = db.ImageModels.FirstOrDefault(x => x.Link == link);
            if (image !=null&&image.Link == link)
            {
                return false;
            }
            else return true;
        }

        public List<ImageModel> GetAllImage() 
        {
            return db.ImageModels.ToList();
        }
    }
}
