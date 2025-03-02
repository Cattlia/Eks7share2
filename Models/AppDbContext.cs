using Microsoft.EntityFrameworkCore;


namespace E7Kont.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Folder> Folders { get; set; }
    }
}