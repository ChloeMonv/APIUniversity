using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiUniversity.Models;

namespace ApiTodo.Controllers;

[ApiController]
[Route("api/Enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly UniversityContext _context;

    public EnrollmentController(UniversityContext context)
    {
        _context = context;
    }



    // GET: api/todo/2
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedEnrollmentDTO>> GetEnrollments(int id)
    {
        // Find todo and related list
        // SingleAsync() throws an exception if no todo is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var enrollment = await _context.Enrollment.Include(x=>x.Student).Include(x => x.Course).SingleOrDefaultAsync(t => t.Id == id);

        if (enrollment == null) return NotFound();

        return new DetailedEnrollmentDTO(enrollment);
    }

    // POST: api/todo
    [HttpPost]
    public async Task<ActionResult<DetailedEnrollmentDTO>> PostEnrollment(EnrollmentDTO enrollmentDTO)
    {
        Enrollment enrollment = new(enrollmentDTO);
        
        _context.Enrollment.Add(enrollment);
        await _context.SaveChangesAsync();


       // Enrollment.Course = _context.Course.First(c => c.Id => c.Id)

        return CreatedAtAction(nameof(GetEnrollments), new { id = enrollment.Id }, new DetailedEnrollmentDTO(enrollment));
    }

    // // PUT: api/todo/2
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutStudent(int id, StudentDTO studentDTO)
    // {
    //     if (id != studentDTO.Id) return BadRequest();

    //     Student student = new(studentDTO);  
    //     _context.Entry(student).State = EntityState.Modified;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!_context.Student.Any(m => m.Id == id))
    //             return NotFound();
    //         else
    //             throw;
    //     }

    //     return NoContent();
    // }

    // // DELETE: api/todo/2
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteStudent(int id)
    // {
    //     var student = await _context.Student.FindAsync(id);

    //     if (student == null)
    //         return NotFound();

    //     _context.Student.Remove(student);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }
}