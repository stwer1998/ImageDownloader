using ImageDownloader.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageDownloader
{
    public class MyDbContext:DbContext
    {
        public DbSet<ImageModel> ImageModels { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
