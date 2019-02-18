using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualLab.Models;

namespace VirtualLab.Areas.Identity.Pages.Course
{
    public class AddAnnouncementsModel : PageModel
    {
		[BindProperty]
		public Announcements Announcement { get; set; }

		private Context _context;

        public void OnGet()
        {
				
        }
		public IActionResult onPost()
		{
			_context.Announcements.Add(Announcement);
			_context.SaveChanges();
			return Page();
		}
    }
}