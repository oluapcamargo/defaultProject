using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace V1.DefaultProject.WebApi
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
         

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.DocumentTitle = "API .net Core";
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Versão 1.0 - 27/01/2022");
            //    options.RoutePrefix = string.Empty;
            //});

            //app.UseRouting();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync(JsonSerializer.Serialize(new ResultViewModel(true, $"API Projeto Padrão {env.EnvironmentName}")));
            //    });
            //    endpoints.MapControllers();
            //});
        }
    }
}
