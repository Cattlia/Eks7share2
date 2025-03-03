// Repositories/FolderRepository.cs
using E7Kont.Models;
using Microsoft.EntityFrameworkCore;

namespace E7Kont.Repositories
{
    public interface IFolderRepository
    {
        IQueryable<Folder> GetAllFolders();
        Folder? GetFolderById(int id);
        void AddFolder(Folder folder);
        void UpdateFolder(Folder folder);
        void DeleteFolder(int id);
    }

    public class FolderRepository : IFolderRepository
    {
        private readonly AppDbContext _context;

        public FolderRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Folder> GetAllFolders()
        {
            return _context.Folders.Include(f => f.Notes);
        }

        public Folder? GetFolderById(int id)
        {
            return _context.Folders.Include(f => f.Notes).FirstOrDefault(f => f.Id == id);
        }

        public void AddFolder(Folder folder)
        {
            _context.Folders.Add(folder);
            _context.SaveChanges();
        }

        public void UpdateFolder(Folder folder)
        {
            var existing = _context.Folders.Find(folder.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(folder);
                _context.SaveChanges();
            }
        }

        public void DeleteFolder(int id)
        {
            var folder = _context.Folders.Find(id);
            if (folder != null)
            {
                _context.Folders.Remove(folder);
                _context.SaveChanges();
            }
        }
    }
}