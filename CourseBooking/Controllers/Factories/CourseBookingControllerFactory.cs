using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using CourseBooking.Controllers;
using CourseBooking.Models;
using CourseBooking.DataAccess;

namespace CourseBooking.Controllers.Factories {
    public class CourseBookingControllerFactory : IControllerFactory {
        public IController CreateController(RequestContext context, string name) {
            switch (name) {
                case "Home":
                    return new HomeController();
                case "Courses": {
                    var dao = new TrainingCourseDAO();
                    return new CoursesController(dao);
                }
                default:
                    return null;
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext context, string name) {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller) {}
    }
}