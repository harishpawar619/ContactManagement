using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactManagement.BusinessManager;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeManagement.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(option => option.AddPolicy("MyBlogPolicy", builder => {
				builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

			}));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddDbContext<ContactDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("ConactDBConnection")));
			services.AddScoped<IContactRepository, ContactRepository>();
			services.AddScoped<IContactManager, ContactManager>();
			//services.AddScoped<IMapper, Mapper>();
	
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseCors("MyBlogPolicy");
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
