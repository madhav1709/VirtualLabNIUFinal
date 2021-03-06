﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualLab.Models
{
	public class Grades
	{
		public string Id { get; set; }

		[Required]
		public string StudentId { get; set; }

		[Required]
		public string CourseId { get; set; }

		[Required]
		public string AssignmentId { get; set; }

		[Required]
		public int Grade { get; set; }
	}
}
