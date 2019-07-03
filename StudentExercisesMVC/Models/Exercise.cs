using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesMVC.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; }
        [Required]
        [Display(Name = "Exercise Language")]
        public string ExerciseLanguage { get; set; }
        public List<Student> ListOfStudents = new List<Student>();        
    }
}