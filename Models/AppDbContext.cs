// Models/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace E7Kont.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Folders
            modelBuilder.Entity<Folder>().HasData(
                new Folder { Id = 1, Name = "Hverdagshandling" },
                new Folder { Id = 2, Name = "Ukeshandling" },
                new Folder { Id = 3, Name = "SkalHandles" }
            );



            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, Title = "HandlelisteMandag", Content = "Egg, melk og torskerogn", IsArchived = true, FolderId = 1 },
                new Note { Id = 2, Title = "HandlelisteTirsdag", Content = "Syltetøy, brød, majones, tomat og ost", IsArchived = false, FolderId = 1 },
                new Note { Id = 3, Title = "HandlelisteFredag", Content = "Jordbær, strå, sukker og laurbær", IsArchived = true, FolderId = 1 },
                new Note { Id = 4, Title = "HandlelisteNesteLørdag", Content = "Melis, krabber, Veuve Cliquot og røde roser", IsArchived = true, FolderId = 3 },
                new Note { Id = 5, Title = "HandlelisteKalender", Content = "Kuli, Porche, Toyota, kråke og syvende sans", IsArchived = true, FolderId = 2 }
            );
        }
    }
}