using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseBooking.Models;
using CourseBooking.DataAccess;

namespace CourseBooking.Controllers {
    public class CoursesController : Controller {
        public CoursesController(ITrainingCourseDAO dao) {
            this.dao = dao;
        }

        public ActionResult Index() {
            return View(dao.GetAllCourses());
        }

        public ActionResult Show(string number) {
            var course = dao.GetCourseByNumber(number);

            if (course == null) {
                return View("NoResults", model: String.Format("No course with the number '{0}'", number));
            }

            return View(course);
        }

        public ActionResult ByKeyword(string keyword) {
            var courses = dao.GetCoursesContainingText(keyword);

            if (!courses.Any()) {
                return View("NoResults", model: String.Format("No courses contain the keyword '{0}'", keyword));
            }

            ViewData["keyword"] = keyword;
            return View(courses);
        }

        [HttpGet]
        public ActionResult New() {
            return View();
        }

        [HttpPost]
        public ActionResult New(string number, string title, string type) {
            var course = new TrainingCourse { Number = number, Title = title, Type = type };
            dao.AddCourse(course);
            ViewData["message"] = "Course created successfully!";
            return View("NewCourseCreated", course);
        }

        private readonly ITrainingCourseDAO dao;
    }
}