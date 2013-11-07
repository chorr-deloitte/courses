using System.Collections.Generic;
using System.Web.Mvc;
using CourseBooking.Controllers;
using CourseBooking.DataAccess;
using CourseBooking.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseBooking.Test.Controllers {
    [TestClass]
    public class CoursesControllerTest {
        [TestInitialize()]
        public void Begin() {
            dao = new StubTrainingCourseDAO();
            controller = new CoursesController(dao);
        }

        [TestMethod]
        public void IndexAction_ReturnsAllCourses() {
            var result = controller.Index() as ViewResult;
            var courses = (IList<TrainingCourse>) result.ViewData.Model;
            Assert.AreEqual(7, courses.Count);
        }

        [TestMethod]
        public void Show_ReturnsValidCourse() {
            var result = controller.Show("AB12") as ViewResult;
            var tc = (TrainingCourse) result.ViewData.Model;
            Assert.AreEqual("AB12", tc.Number);
            Assert.AreEqual("Intro To C++", tc.Title);
        }

        [TestMethod]
        public void Show_HandlesInvalidCourseNumber() {
            var result = controller.Show("ZZ00") as ViewResult;
            Assert.AreEqual("NoResults", result.ViewName);
        }

        [TestMethod]
        public void ByKeyword_ReturnsValidCourses() {
            var result = controller.ByKeyword("Intro") as ViewResult;
            var courses = (IList<TrainingCourse>) result.ViewData.Model;
            var keyword = (string) result.ViewData["keyword"];
            Assert.AreEqual("Intro", keyword);
            Assert.AreEqual(4, courses.Count);
        }

        [TestMethod]
        public void ByKeyword_HandlesUnknownKeyword() {
            var result = controller.ByKeyword("XXX") as ViewResult;
            Assert.AreEqual("NoResults", result.ViewName);
        }

        private CoursesController controller;
        private ITrainingCourseDAO dao;
    }
}