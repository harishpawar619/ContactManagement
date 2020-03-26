using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactManagement.BusinessManager;
using ContactMangement.Logger;
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
using Swashbuckle.AspNetCore.Swagger;

namespace ContactManagement.API
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
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1.0", new Info { Title = "ContactManagement.API", Version = "1.0" });
			});
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
			app.UseSwagger();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "ContactManagement.API(V 1.0)");
				});
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			SerilogConfigurationSettings config = Configuration.GetSection("SerilogConfigurationSettings").Get<SerilogConfigurationSettings>();
			SerilogManager._ComponentName = config.ComponentName;
			SerilogManager._ConnectionString = config.ConnectionString;
			SerilogManager._TableName = config.TableName;
			SerilogManager._LogFilePath = config.LogFilePath;
			SerilogManager.FilebasedLogger = config.FilebasedLogger;
			SerilogManager.InitializeLogger();
			app.UseCors("MyBlogPolicy");
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
