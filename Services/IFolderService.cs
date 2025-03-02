using E7Kont.Models;


public interface IFolderService
{
    IEnumerable<Folder> GetFolders(); 
    Folder GetFolderById(int id);
    void AddFolder(Folder folder);
    void UpdateFolder(int id, Folder folder);
    void DeleteFolder(int id);
}


