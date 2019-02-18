﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualLab.Models
{
	public class Assignments
	{
		public string Id { get; set; }

		[Required]
		public string CourseId { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public DateTime AssignmentDueDate { get; set; }

		[Required]
		public int MaximumGrade { get; set; }
	}
}
