using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualLab.Areas.Identity.Data;
using VirtualLab.Models;

[assembly: HostingStartup(typeof(VirtualLab.Areas.Identity.IdentityHostingStartup))]
namespace VirtualLab.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ContextConnection")));

                services.AddIdentity<VirtualLabUser, IdentityRole>()
				.AddDefaultUI()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<Context>();
			});
        }
    }
}