using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseBooking.Models {
    [Table("Courses")]
    public class TrainingCourse {
        public TrainingCourse() {}

        public TrainingCourse(string number, string title, string type) {
            Type = type;
            Number = number;
            Title = title;
        }

        [Key]
        [MaxLength(10)]
        [Column("CourseNum")]
        public string Number { get; set; }

        [MaxLength(15)]
        [Column("CourseType")]
        public string Type { get; set; }

        [MaxLength(30)]
        [Column("CourseTitle")]
        public string Title { get; set; }
    }
}