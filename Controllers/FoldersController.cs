using E7Kont.Models;
using Microsoft.AspNetCore.Mvc;

namespace E7Kont.Controllers

{   
    [ApiController, Route("api/[controller]")]
    public class FoldersController : ControllerBase
    {
        
        private readonly IFolderService _folderService;

        public FoldersController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        //GET: api/Folder
        [HttpGet]
        public ActionResult<IEnumerable<Folder>> GetFolder()
        {
            var folders = _folderService.GetFolders();
            return Ok(folders);
        }

        // GET: api/Folder/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Folder>> GetFolder(int id)
        {
            var Folder = _folderService.GetFolderById(id);
            if (Folder == null)
            {
                NotFound();
            }
            return Ok(Folder);
        }
    
        [HttpPost]
        public ActionResult<Folder> CreateFolder(Folder newFolder)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            _folderService.AddFolder(newFolder);
            return CreatedAtAction(nameof(GetFolder), new {id = newFolder.Id}, newFolder);
        }

        //PUT: api/Folder/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFolder(int id, Folder updatedFolder)
        {
            var existingFolder = _folderService.GetFolderById(id);
            if(existingFolder == null)
            {
                return NotFound();
            }
            
            _folderService.UpdateFolder(id, updatedFolder);

            return NoContent();
        }


        //DELETE:
        [HttpDelete("{id}")]
        public ActionResult DeleteFolder(int id)
        {
            _folderService.DeleteFolder(id);
            return NoContent();
        }



    }
}

   


   