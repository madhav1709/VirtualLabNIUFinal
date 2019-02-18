using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VirtualLab.Areas.Identity.Pages.Course
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
			if(User.IsInRole("Administrator"))
			{
				ViewData["Role"] = "Administrator";
			}

			if (User.IsInRole("Professor"))
			{
				ViewData["Role"] = "Professor";
			}
		}
    }
}