using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly List<string> _departments = new List<string> { "CS", "IT", "AI", "IS" };

        public StudentsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentsApi
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        // GET: api/StudentsApi/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound(new { message = $"Student with Id {id} was not found." });
            }
            return Ok(student);
        }

        // POST: api/StudentsApi
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (string.IsNullOrEmpty(student.Department) || !_departments.Contains(student.Department))
            {
                ModelState.AddModelError("Department", "Department must be one of the following: CS, IT, AI, IS");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT: api/StudentsApi/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest(new { message = "Id in URL does not match Id in body." });
            }

            var existing = _context.Students.Find(id);
            if (existing == null)
            {
                return NotFound(new { message = $"Student with Id {id} was not found." });
            }

            if (string.IsNullOrEmpty(student.Department) || !_departments.Contains(student.Department))
            {
                ModelState.AddModelError("Department", "Department must be one of the following: CS, IT, AI, IS");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Age = student.Age;
            existing.Department = student.Department;

            _context.SaveChanges();

            return Ok(existing);
        }

        // DELETE: api/StudentsApi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound(new { message = $"Student with Id {id} was not found." });
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok(new { message = $"Student with Id {id} deleted successfully." });
        }
    }
}
