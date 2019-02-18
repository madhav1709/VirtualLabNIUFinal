using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLab.Areas.Identity.Data;
using VirtualLab.Models;

namespace VirtualLab.ViewModels
{
	public class AddCourseViewModel
	{
		public IEnumerable<VirtualLabUser> VirtualLabUsers { get; set; }
		public IEnumerable<Course> Courses { get; set; }
	}
}
