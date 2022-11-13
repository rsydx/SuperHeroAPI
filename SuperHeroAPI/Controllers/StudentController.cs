using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student> {
                new Student {
                    Id=1,
                    Name= "Spiderman",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                },
                new Student {
                    Id=2,
                    Name= "Ironman",
                    FirstName="Tony",
                    LastName="Stark",
                    Place="Long Island"
                }
         };
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {

            return Ok(students);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student == null)
                return BadRequest("Student not found.");
            return Ok(student);

        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Student>> GetName(string name)
        {
            var student = students.Find(s => s.FirstName == name);
            if (student == null)
                return BadRequest("Student not found.");
            return Ok(student);

        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            students.Add(student);
            return Ok(students);

        }
        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student request)
        {
            var student = students.Find(s => s.Id == request.Id);
            if (student == null)
                return BadRequest("Hero not found.");

            student.Name = request.Name;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Place = request.Place;
            return Ok(students);


        }
    }
}
