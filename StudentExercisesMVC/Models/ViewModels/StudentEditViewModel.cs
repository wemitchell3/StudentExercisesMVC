using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercisesMVC.Models.ViewModels
{
    public class StudentEditViewModel
    {
        public Student Student { get; set; }
        public List<Cohort> AvailableCohorts { get; set; }
        public List<SelectListItem> AvailableCohortsSelectList
        {
            get
            {
                return AvailableCohorts
                    .Select(c => new SelectListItem(c.CohortName, c.Id.ToString()))
                    .ToList();
            }
        }
        public List<Exercise> AvailableExercises { get; set; }
        public List<SelectListItem> AvailableExercisesSelectList
        {
            get
            {
                return AvailableExercises
                    .Select(c => new SelectListItem(c.ExerciseName, c.Id.ToString()))
                    .ToList();
            }
        }
    }
}
