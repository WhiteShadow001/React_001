using Microsoft.AspNetCore.Mvc;
using SDCApiLearning.Data;
using SDCApiLearning.Repo;

namespace SDCApiLearning.Controllers
{
    [Route("student")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllStudent")]
        public IActionResult GetStudentList(int id = 0)
        {
            StudentContext con = new StudentContext();
            var data = con.GetStudentDatasFromDB(id);

            return Ok(data);
        }

        [HttpGet]
        [Route("GetAllGender")]
        public IActionResult GetGenderList()
        {
            StudentContext con = new StudentContext();
            var data = con.GetGenderFromDB();

            return Ok(data);
        }


        [HttpGet]
        [Route("GetAllSubject")]
        public IActionResult GetSubjectList()
        {
            StudentContext con = new StudentContext();
            var data = con.GetSubjectFromDB();

            return Ok(data);
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] StudentData data)
        {

            StudentContext s = new StudentContext();
            s.InsertIntoStudent(data);
            return Ok(data);
        }

        [HttpGet]
        [Route("Update")]
        public IActionResult Update()
        {
            var data = new StudentData
            {
                name = "hari ram"
            };
            StudentContext s = new StudentContext();
            s.UpdateStudent(data);
            return Ok(data);
        }


    }
}