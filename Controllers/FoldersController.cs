// Controllers/FoldersController.cs
using E7Kont.Models;
using E7Kont.Services;
using Microsoft.AspNetCore.Mvc;

namespace E7Kont.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FoldersController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var folders = _folderService.GetFolders();
            return Ok(folders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var folder = _folderService.GetFolderById(id);
            if (folder == null) return NotFound();
            return Ok(folder);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Folder folder)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _folderService.AddFolder(folder);
            return CreatedAtAction(nameof(GetById), new { id = folder.Id }, folder);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Folder folder)
        {
            if (!ModelState.IsValid || id != folder.Id) return BadRequest();
            _folderService.UpdateFolder(id, folder);
            return Ok(folder);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _folderService.DeleteFolder(id);
            return NoContent();
        }
    }
}