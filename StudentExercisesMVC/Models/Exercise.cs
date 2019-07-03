using System.Collections.Generic;

namespace StudentExercisesMVC.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseLanguage { get; set; }
        public List<Student> ListOfStudents = new List<Student>();
    }
}