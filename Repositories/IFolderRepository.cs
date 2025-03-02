/*
using System.Reflection.Metadata;
using E7Kont.Models;

public class FolderContext : DbContext
{
    public  FolderContext(DbContextOptions<FolderContext> options) : base(options) {}

    public DbSet<Folder> Folder { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>(EntityHandle =>
        {
            entity.ToTable("Folder");
            entity.Property(f => f.Id).HasColumnName("Id");
            entity.Property(f => f.Name).HasColumnName("Name");
            entity.Property(f => f.List<string>).HasColumnName("List<string>");
            
                      
            
        });
        
    }
}




{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength (50, MinimumLength = 3)]
    public string? Name { get; set; }
    public List<string> Note { get; set; } = new List<string>();
}
*/