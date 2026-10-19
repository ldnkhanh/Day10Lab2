using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BT1Day10.Models;
namespace BT1Day10.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> listStudent = new List<Student>()
            {
                new Student ()
                {
                    Id = 101,
                    Name = "Nguyễn Văn A",
                    Email = "anguyen@gmail.com",
                    Password = "HashedPassword123!",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Hà Nội",
                    Dob = new DateTime(2003, 5, 15)
                },
                new Student ()
                {
                    Id = 102,
                    Name = "Trần Thị B",
                    Email = "btran@gmail.com",
                    Password = "HashedPassword456!",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "Đà Nẵng",
                    Dob = new DateTime(2004, 8, 20)
                },
                new Student
                {
                    Id = 103,
                    Name = "Lê Hoàng C",
                    Email = "cle@gmail.com",
                    Password = "HashedPassword789!",
                    Branch = Branch.EE,
                    Gender = Gender.Male,
                    IsRegular = false, // Hệ vừa học vừa làm / không chính quy
                    Address = "TP. Hồ Chí Minh",
                    Dob = new DateTime(2002, 11, 3)
                },
                new Student
                {
                    Id = 104,
                    Name = "Phạm Minh D",
                    Email = null, // Do Email là string? (nullable)
                    Password = null,
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Cần Thơ",
                    Dob = new DateTime(2003, 1, 25)
                },
                new Student
                {
                    Id = 105,
                    Name = "Hoàng Thu E",
                    Email = "ehoang@gmail.com",
                    Password = "HashedPassword321!",
                    Branch = null, // Do Branch? là nullable enum
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "Hải Phòng",
                    Dob = new DateTime(2004, 3, 12)
                }
            };

        [Route("Admin/Student/List", Name = "studentList")]
        public IActionResult Index()
        {
            return View(listStudent);
        }
        [HttpGet]
        [Route("Admin/Student/Add", Name = "studentAdd")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }
        [HttpPost]
        [Route("Admin/Student/Add")]
        public IActionResult Create(Student student)
        {
            student.Id = listStudent.Last<Student>().Id + 1;
            listStudent.Add(student);
            return View("Index", listStudent);
        }

    }
}
