using System.Collections.Generic;

namespace StudentExercisesMVC.Models
{
    public class Cohort
    {
        public int Id { get; set; }
        public string CohortName { get; set; }
        public List<Student> StudentsInCohort { get; set; } = new List<Student>();
        public List<Instructor> InstructorsInCohort { get; set; } = new List<Instructor>();
    }
}