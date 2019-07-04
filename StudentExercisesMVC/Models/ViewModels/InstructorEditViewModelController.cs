using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercisesMVC.Models.ViewModels
{
    public class InstructorEditViewModel
    {
        public Instructor Instructor { get; set; }
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
    }
}