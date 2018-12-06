using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditLogTest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuditLogTest
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            //var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Test";
            //var connString = $"Data Source={hostname};Initial Catalog=AuditLogTestDb;User ID=sa;Password={password};";

            // var connString = @"User ID=audit_app;Password=docker;Host=postgres;Port=5432;Database=auditlogdb;Pooling=true;CommandTimeout=3000";

            //services.AddDbContext<AuditLogDbContext>(options => options.UseSqlServer(connString));

            //services.AddEntityFrameworkNpgsql()
            //    .AddDbContext<AuditLogDbContext>(
            //        opts => opts.UseNpgsql(connString)
            //    );

            var connection = @"Server=db;Database=master;User=sa;Password=Testing_123;";
            services.AddDbContext<AuditLogDbContext>(options => options.UseSqlServer(connection));
            
            //services.AddDbContext<AuditLogDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAuditLogRepository, AuditLogRepository>();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            
            app.UseStaticFiles();
            app.UseMvc(routes =>
                routes.MapRoute(
                    name: "CustomerRoute",
                    template: "{controller=Customers}/{action=Index}/{id?}"
                ));

        }
    }
}
