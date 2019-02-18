using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VirtualLab.Areas.Identity.Data;
using VirtualLab.Models;

namespace VirtualLab
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthentication();

			app.UseMvc();

			CreateRoles(serviceProvider).Wait();

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}

		private async Task CreateRoles(IServiceProvider serviceProvider)
		{
			//initializing custom roles   
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var UserManager = serviceProvider.GetRequiredService<UserManager<VirtualLabUser>>();
			string[] roleNames = { "Administrator", "Professor" };
			IdentityResult roleResult;

			foreach (var roleName in roleNames)
			{
				var roleExist = await RoleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					//create the roles and seed them to the database: Question 1  
					roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
				}
			}

			VirtualLabUser user = await UserManager.FindByEmailAsync("admin@virtuallab.com");

			if (user == null)
			{
				user = new VirtualLabUser()
				{
					UserName = "admin@virtuallab.com",
					Email = "admin@virtuallab.com",
					Name = "Administrator",
					UniversityName = "NIU"
				};
				await UserManager.CreateAsync(user, "sALT@GNW2");
			}
			await UserManager.AddToRoleAsync(user, "Administrator");


			VirtualLabUser user1 = await UserManager.FindByEmailAsync("lguo@virtuallab.com");

			if (user1 == null)
			{
				user1 = new VirtualLabUser()
				{
					UserName = "lguo@virtuallab.com",
					Email = "lguo@virtuallab.com",
					Name = "Liping Guo",
					UniversityName = "NIU"
				};
				await UserManager.CreateAsync(user1, "kH4n@C4vr");
			}
			await UserManager.AddToRoleAsync(user1, "Professor");

		}
	}
}
