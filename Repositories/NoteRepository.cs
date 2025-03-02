
using E7Kont.Models;
using Microsoft.EntityFrameworkCore;


namespace E7Kont.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = GetNoteById(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

        public IQueryable<Note> GetAllNotes() => _context.Notes
                    .Include(n => n.Folder);
        

        public Note GetNoteById(int id)
        {
            return _context.Notes
                    .Include(n => n.Folder)
                    .FirstOrDefault(n => n.Id == id) ?? new Note();
        }

        public void UpdateNote(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }
    }
}