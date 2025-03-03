using System.Collections.Generic;
using System.Linq;
using E7Kont.Models;
using E7Kont.Repositories;

public class FolderService : IFolderService
{
    
    private readonly IFolderRepository _folderRepository;

    
    public FolderService(IFolderRepository folderRepository)
    {
        _folderRepository = folderRepository;
    }

    
    public IEnumerable<Folder> GetFolders()
    {
        return _folderRepository.GetAllFolders().ToList();
    }

    
    public Folder? GetFolderById(int id)
    {
        return _folderRepository.GetFolderById(id);
    }

  
    public void AddFolder(Folder folder)
    {
        _folderRepository.AddFolder(folder);
    }

    
    public void UpdateFolder(int id, Folder updatedFolder)
    {
        // CHANGE: Added ID mismatch check for safety
        if (updatedFolder.Id != id) throw new ArgumentException("Folder ID mismatch");
        _folderRepository.UpdateFolder(updatedFolder);
    }

    
    public void DeleteFolder(int id)
    {
        _folderRepository.DeleteFolder(id);
    }
}