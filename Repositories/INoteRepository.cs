
using System.Reflection.Metadata;
using E7Kont.Models;
using Microsoft.EntityFrameworkCore;

namespace E7Kont.Repositories
{
    public interface INoteRepository
    {
        IQueryable<Note> GetAllNotes();

        Note GetNoteById(int id);
        void AddNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(int id);
    }
}

