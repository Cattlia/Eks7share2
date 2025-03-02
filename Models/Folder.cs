
using System.ComponentModel.DataAnnotations;

namespace E7Kont.Models;

    public class Folder
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mappen må ha et navn!")]
        [StringLength(50, ErrorMessage = "Mappenavnet kan ikke være lengre enn 50 eller mindre enn 3 tegn!", MinimumLength = 3)]
        public string? Name { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();
    }
