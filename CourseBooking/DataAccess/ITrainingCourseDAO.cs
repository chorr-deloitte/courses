using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseBooking.Models;

namespace CourseBooking.DataAccess {
    public interface ITrainingCourseDAO {
        void AddCourse(TrainingCourse course);
        void UpdateCourse(TrainingCourse course);
        TrainingCourse GetCourseByNumber(string number);
        TrainingCourse GetCourseByTitle(string title);
        IList<TrainingCourse> GetAllCourses();
        IList<TrainingCourse> GetCoursesByType(string type);
        IList<TrainingCourse> GetCoursesContainingText(string text);
    }
}
