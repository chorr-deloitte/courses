using System.Collections.Generic;
using System.Linq;
using CourseBooking.Models;

namespace CourseBooking.DataAccess {
    public class StubTrainingCourseDAO : ITrainingCourseDAO {
        private readonly List<TrainingCourse> sampleData;

        public StubTrainingCourseDAO() {
            Additions = new List<TrainingCourse>();
            Updates = new List<TrainingCourse>();
            sampleData = new List<TrainingCourse>();
            PopulateInitialCourses();
        }

        public List<TrainingCourse> Additions { get; private set; }

        public List<TrainingCourse> Updates { get; private set; }

        public TrainingCourse GetCourseByNumber(string number) {
            return sampleData.FirstOrDefault(course => course.Number == number);
        }

        public TrainingCourse GetCourseByTitle(string title) {
            return sampleData.FirstOrDefault(course => course.Title == title);
        }

        public IList<TrainingCourse> GetAllCourses() {
            return sampleData;
        }

        public IList<TrainingCourse> GetCoursesByType(string type) {
            return sampleData.Where(tc => tc.Type == type).ToList();
        }

        public IList<TrainingCourse> GetCoursesContainingText(string text) {
            return sampleData.Where(tc => tc.Title.Contains(text)).ToList();
        }

        public void AddCourse(TrainingCourse tc) {
            sampleData.Add(tc);
            Additions.Add(tc);
        }

        public void UpdateCourse(TrainingCourse tc) {
            Updates.Add(tc);
        }

        private void PopulateInitialCourses() {
            sampleData.Add(new TrainingCourse {Number = "AB12", Title = "Intro To C++", Type = "Beginners"});
            sampleData.Add(new TrainingCourse {Number = "CD34", Title = "Intro To C#", Type = "Beginners"});
            sampleData.Add(new TrainingCourse {Number = "EF56", Title = "Intro To Java", Type = "Beginners"});
            sampleData.Add(new TrainingCourse {Number = "GH78", Title = "Intro To IL", Type = "Intermediate"});
            sampleData.Add(new TrainingCourse {Number = "IJ90", Title = "XPath and XSLT", Type = "Intermediate"});
            sampleData.Add(new TrainingCourse {Number = "KL12", Title = "Enterprise JavaBeans", Type = "Advanced"});
            sampleData.Add(new TrainingCourse {Number = "MN34", Title = "Designing .NET Apps", Type = "Advanced"});
        }
    }
}