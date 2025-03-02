
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E7Kont.Models;

public class Note

{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tittel er påkrevd!")]
    [StringLength(100, ErrorMessage = "Tittelen kan ikke være lengre enn 100, eller mindre enn 3 tegn!", MinimumLength = 3)]
    public string? Title { get; set; }

    [StringLength(1000, ErrorMessage = "Antall tegn i innholdet kan ikke overstige 1000 tegn!")]
    public string? Content { get; set; }

    public bool IsArchived { get; set; } = false;

    [ForeignKey("Folder")]
    public int? FolderId { get; set; }

    public Folder? Folder { get; set; }


}