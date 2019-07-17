using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesMVC.Models
{
    public class Student : NSSPerson
    {
        [Display(Name = "Assigned Exercises")]
        public int ExerciseId { get; set; }
        public List<Exercise> ListOfStudentExercises = new List<Exercise>();
    }
}
