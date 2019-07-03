
using System.Collections.Generic;

namespace StudentExercisesMVC.Models
{
    public class Student : NSSPerson
    {
        public List<Exercise> ListOfStudentExercises = new List<Exercise>();
    }
}
