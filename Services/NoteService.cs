using E7Kont.Services;
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

    public IEnumerable<Note> GetNotes() => _NoteRepository.GetAllNotes().ToList();

    public Note? GetNoteById(int id) => _NoteRepository.GetNoteById(id);

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