using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VirtualLab.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the VirtualLabUser class
    public class VirtualLabUser : IdentityUser
    {
		[PersonalData]
		public string Name { get; set; }
		[PersonalData]
		public string UniversityName { get; set; }
	}
}
