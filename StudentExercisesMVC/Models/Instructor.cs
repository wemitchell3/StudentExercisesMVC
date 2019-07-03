

namespace StudentExercisesMVC.Models
{
    public class Instructor : NSSPerson
    {
        public string InstructorSpecialty { get; set; }
        public void AssignExercise(Student student, Exercise exercise)
        {
            student.ListOfStudentExercises.Add(exercise);
            exercise.ListOfStudents.Add(student);
        }
    }
}