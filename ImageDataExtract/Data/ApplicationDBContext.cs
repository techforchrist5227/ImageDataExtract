using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ImageDataExtract.Models;

namespace ImageDataExtract.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<ImageData> imageDatas { get; set; }
    }
}
