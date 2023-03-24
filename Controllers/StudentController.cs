using Microsoft.AspNetCore.Mvc;
using StudentRecord.Databse_Operation;

namespace StudentRecord.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ModelState.Clear();
            return View(new StuDbOperation().GetAllStudents()) ;
        }
        public JsonResult GetStudents()
        {
            StuDbOperation stu = new StuDbOperation();
            return Json(new {data = stu.GetAllStudents()});
        }
    }
}
