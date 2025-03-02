using E7Kont.Models;

public interface INoteService
{
    IEnumerable<Note> GetNote(); 
    Note GetNoteById(int id);
    void AddNote(Note note);
    void UpdateNote(int id, Note note);
    void DeleteNote(int id);
}