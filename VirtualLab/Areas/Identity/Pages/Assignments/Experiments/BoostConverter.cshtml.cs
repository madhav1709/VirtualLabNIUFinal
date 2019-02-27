using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VirtualLab.Areas.Identity.Pages.Assignments.Experiments
{
    public class BoostConverterModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Resistance (Ω)")]
            public int Ru { get; set; }

            [Required]
            [Display(Name = "Inductance (μH)")]
            public int Lu { get; set; }

            [Required]
            [Display(Name = "Duty Cycle (%)")]
            public int Du { get; set; }

            [Required]
            [Display(Name = "Capacitance (μF)")]
            public int Cu { get; set; }

            [Required]
            [Display(Name = "Voltage Input (V)")]
            public int Vin { get; set; }

            [Required]
            [Display(Name = "Frequency (kHz)")]
            public int Fu { get; set; }

            public int r1 = 0;
        }

        public void OnGet()
        {
        }
    }
}