using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VirtualLab.Areas.Identity.Pages.Course
{
	[Authorize(Roles = "Administrator")]
    public class AddCourseModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}