using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualLab.Models
{
	public class Course
	{
		public string Id { get; set; }

		[Required]
		public string CourseName { get; set; }

		[Required]
		public string YearAndSemester { get; set; }

		[Required]
		public string ProfessorId { get; set; }

		[Required]
		public string ProfessorName { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		public int NumberOfStudentsRegistered { get; set; }
	}
}
