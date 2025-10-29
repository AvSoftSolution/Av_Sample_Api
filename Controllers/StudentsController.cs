using Beautiful.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beautiful.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        ResultDTO resultDTO=new ResultDTO();

        public readonly AppDbContext _appDbContext;

        public StudentsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]

        public ActionResult GetStudets()
        {
            var StdentsData= _appDbContext.Studentss.ToList();
           resultDTO.Status = true;
            resultDTO.Message = "Api Is Working";
            resultDTO.Result= StdentsData;
            return Ok(resultDTO);
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int Id = 0)
        {
            var getdata = _appDbContext.Studentss.Where(x => x.Id == Id).FirstOrDefault();
            if (getdata == null)
            {
                resultDTO.Message = "Data not found";
                resultDTO.Status = false;
            }
            else
            {

                resultDTO.Message = "Data found";
                resultDTO.Status = true;
                resultDTO.Result = getdata;
            }

            return Ok(resultDTO);


        }


        [HttpPost]

        public ActionResult AddStudents(Students students)
        {
            if (students.Id == 0)
            {

                _appDbContext.Studentss.Add(students);
                resultDTO.Message = " New Student Added";
                resultDTO.Result = students;
            }
            else
            {
                _appDbContext.Studentss.Update(students);
                resultDTO.Message = " student Updated";
                resultDTO.Result = students;
            }
            _appDbContext.SaveChanges();
                return Ok(resultDTO);
        }

        [HttpDelete]
        public ActionResult Deletestudents(int Id = 0)
        {
            var getdata = _appDbContext.Studentss.Where(x => x.Id == Id).FirstOrDefault();
            if (getdata == null)
            {
                resultDTO.Message = "Data not found";
                resultDTO.Status = false;
            }
            else
            {

                resultDTO.Message = "Data Deleted";
                resultDTO.Status = true;
                _appDbContext.Studentss.Remove(getdata);
                resultDTO.Result = getdata;
                _appDbContext.SaveChanges();
            }
            return Ok(resultDTO);
        }
    }
}

   