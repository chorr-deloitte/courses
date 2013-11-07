using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CourseBooking.Models;

namespace CourseBooking.DataAccess {
    public class TrainingCourseDAO : DbContext, ITrainingCourseDAO {
        public TrainingCourseDAO() : base("TrainingCourseConnection") {
        }

        public DbSet<TrainingCourse> Courses { get; set; }

        public void AddCourse(TrainingCourse course) {
            throw new NotImplementedException();
        }

        public void UpdateCourse(TrainingCourse course) {
            throw new NotImplementedException();
        }

        public TrainingCourse GetCourseByNumber(string number) {
            return Courses.Find(number);
        }

        public TrainingCourse GetCourseByTitle(string title) {
            throw new NotImplementedException();
        }

        public IList<TrainingCourse> GetAllCourses() {
            return Courses.ToList();
        }

        public IList<TrainingCourse> GetCoursesByType(string type) {
            throw new NotImplementedException();
        }

        public IList<TrainingCourse> GetCoursesContainingText(string text) {
            throw new NotImplementedException();
        }
    }
}