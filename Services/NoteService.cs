
using E7Kont.Models;
using E7Kont.Repositories;
using Serilog;

public class NoteService : INoteService
{
    private readonly INoteRepository _NoteRepository;

    public NoteService(INoteRepository NoteRepository)
    {
        _NoteRepository = NoteRepository;
    }

    public IEnumerable<Note> GetNote() => _NoteRepository.GetAllNotes().ToList();

    public Note GetNoteById(int id) => _NoteRepository.GetNoteById(id);

    public void AddNote(Note note) 
    {
        if(note == null) return;
        _NoteRepository.AddNote(note);
        Log.Information($"Note {note.Title} added");

    }

    public void UpdateNote(int id, Note updatedNote)
    {
        var note = GetNoteById(id);
        if (note == null) return;

        _NoteRepository.UpdateNote(note);
        Log.Information($"Lappen {note.Title} er oppdatert.");
        
        
    }
    
     public void DeleteNote(int id)
     {
        _NoteRepository.DeleteNote(id);
     }


}

/*

tatt fra: public void UpdateNote(int id, Note updatedNote)
        note.Title = updatedNote.Title;
        note.Content = updatedNote.Content;
        note.IsArchived = updatedNote.IsArchived;
        note.FolderId = updatedNote.FolderId;




private static readonly List<Note> Note = new ()
        {
            new Note {Id = 1, Title = "HandlelisteMandag", Content = "Egg, melk og torskerogn", IsArchived = true, FolderId = 1},

            new Note {Id = 2, Title = "HandlelisteTirsdag", Content = "Syltetøy, brød, majones, tomat og ost", IsArchived = false},

            new Note {Id = 3, Title = "HandlelisteFredag", Content = "Jordbær, strå, sukker og laurbær", IsArchived = true, FolderId = 1},

            new Note {Id = 4, Title = "HandlelisteNesteLørdag", Content = "Melis, krabber, Veuve Cliquot og røde roser", IsArchived = true, FolderId = 3},

            new Note {Id = 5, Title = "HandlelisteKalender", Content = "Kuli, Porche, Toyota, kråke og syvende sans", IsArchived = true, FolderId = 2}
        };

*/