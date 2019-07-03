

namespace StudentExercisesMVC.Models
{
    public class NSSPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SlackHandle { get; set; }
        public Cohort Cohort { get; set; }
        public int CohortId { get; set; }
    }
}