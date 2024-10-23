using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo_App_Backend.Data;
using Todo_App_Backend.Models;
using Todo_App_Backend.Models.Entities;

namespace Todo_App_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public NotesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var allNotes = dbContext.Notes.ToList();

            return Ok(allNotes);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetNoteById(Guid id)
        {
            var note = dbContext.Notes.Find(id);
            if (note is null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpPost]
        public IActionResult AddNotes(AddNotesDto addNotes)
        {
            var notes = new Notes()
            {
                Description = addNotes.Description,
            };
            dbContext.Notes.Add(notes);
            dbContext.SaveChanges();
            return Ok(notes);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateNotes(Guid id, EditNotesDto editNotes)
        {
            var note = dbContext.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            note.Description = editNotes.Description;
            dbContext.Notes.Update(note);
            dbContext.SaveChanges();
            return Ok(note);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteNoteById(Guid id)
        {
            var note = dbContext.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            dbContext.Notes.Remove(note);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
