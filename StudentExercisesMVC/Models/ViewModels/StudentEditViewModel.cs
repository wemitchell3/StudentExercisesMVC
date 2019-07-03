using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
