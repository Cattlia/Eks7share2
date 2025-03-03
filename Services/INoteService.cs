using E7Kont.Models;


namespace E7Kont.Services;

public interface INoteService
{
    IEnumerable<Note> GetNotes();
    Note? GetNoteById(int id);
    void AddNote(Note note);
    void UpdateNote(int id, Note note);
    void DeleteNote(int id);
}
