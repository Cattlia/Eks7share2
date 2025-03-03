// Controllers/NotesController.cs
using E7Kont.Models;
using E7Kont.Services;
using Microsoft.AspNetCore.Mvc;

namespace E7Kont.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var notes = _noteService.GetNotes();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var note = _noteService.GetNoteById(id);
            if (note == null) return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Note note)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _noteService.AddNote(note);
            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Note note)
        {
            if (!ModelState.IsValid || id != note.Id) return BadRequest();
            _noteService.UpdateNote(id, note);
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.DeleteNote(id);
            return NoContent();
        }
    }
}