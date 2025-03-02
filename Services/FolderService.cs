using System.Collections.Generic;
using System.Linq;
using E7Kont.Models;

public class FolderService : IFolderService
{
    private static readonly List<Folder> Folders = new()
    {
        new Folder { Id = 1, Name = "Hverdagshandling", Notes = new List<Note>() },
        new Folder { Id = 2, Name = "Ukeshandling", Notes = new List<Note>() },
        new Folder { Id = 3, Name = "SkalHandles", Notes = new List<Note>() }
    };

    public IEnumerable<Folder> GetFolders() => Folders;

    public Folder GetFolderById(int id) => Folders.FirstOrDefault(f => f.Id == id) ?? new Folder();

    public void AddFolder(Folder folder)
    {
        folder.Id = Folders.Max(f => f.Id) + 1;
        Folders.Add(folder);
    }

    public void UpdateFolder(int id, Folder updatedFolder)
    {
        var folder = GetFolderById(id);
        if (folder == null) return;

        folder.Name = updatedFolder.Name;
        folder.Notes = updatedFolder.Notes; 
    }

    public void DeleteFolder(int id)
    {
        var folder = GetFolderById(id);
        if (folder != null) Folders.Remove(folder);
    }
}