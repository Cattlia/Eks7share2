using E7Kont.Models;
using Microsoft.AspNetCore.Mvc;

namespace E7Kont.Controllers

{   
    [ApiController, Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        
        private readonly INoteService _NoteService;

        public NotesController(INoteService NoteService)
        {
            _NoteService = NoteService;
        }

        //GET: api/Note
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetNote()
        {
            var Note = _NoteService.GetNote();
            return Ok(Note);
        }

        // GET: api/Note/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Note>> GetNote(int id)
        {
            var note = _NoteService.GetNoteById(id);
            if (note == null)
            {
                NotFound();
            }
            return Ok(note);
        }
    
        [HttpPost]
        public ActionResult<Note> CreateNote(Note newNote)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            _NoteService.AddNote(newNote);
            return CreatedAtAction(nameof(GetNote), new {id = newNote.Id}, newNote);
        }

        //PUT: api/Note/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNote(int id, Note updatedNote)
        {
            var existingNote = _NoteService.GetNoteById(id);
            if(existingNote == null)
            {
                return NotFound();
            }
            
            _NoteService.UpdateNote(id, updatedNote);

            return NoContent();
        }


        //DELETE:
        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            _NoteService.DeleteNote(id);
            return NoContent();
        }



    }
}

   


   