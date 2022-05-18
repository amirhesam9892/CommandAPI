using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommandAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using AutoMapper;


namespace CommandAPI
{
    public class Startup
    {
        public IConfiguration Configuration {get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
                var builder = new SqlConnectionStringBuilder ();
                builder.ConnectionString = 
                Configuration.GetConnectionString("SqlServerConnection");
                builder.UserID = Configuration["User Id"];
                builder.Password = Configuration["Password"];
                
                services.AddDbContext<CommandContext>(opt => opt.UseSqlServer
                (builder.ConnectionString));
                
                services.AddControllers();

                //services.AddScoped<ICommandAPIRepo,MockCommandAPIRepo>();

                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                services.AddScoped<ICommandAPIRepo,SqlCommandAPIRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
