using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace V1.DefaultProject.Persistence.Context
{
    public static class ConfigureApiExtension
    {
        public static void ConfigureApiDocExtension(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            services.AddApiDoc(configuration, assembly);
        }

        public static void UseApiDocExtension(this IApplicationBuilder app, IConfiguration configuration, Assembly assembly)
        {
            // app.UseApiDoc(configuration, assembly);


            //app.();
            //app.UseSwagger(c =>
            //{

            //if (!string.IsNullOrEmpty(basePath))
            // {
            //c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
            //{
            //if (!httpReq.Host.Host.Contains("localhost"))
            //   swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{basePath}" } };
            //});

            //}
            // });

            //app.UseSwaggerUI(c =>
            //{
            //    c.RoutePrefix = "api-docs";
            //    c.SwaggerEndpoint($"../swagger/v1/swagger.json", $"v{timestampVersion}");

            //    if (!string.IsNullOrEmpty(configurationAuthentication))
            //    {
            //        c.DocExpansion(DocExpansion.None);

            //        c.OAuthClientId(UtilSettings.Instance.AppSettings("Authentication:OAuthClientId"));
            //        c.OAuthAppName(UtilSettings.Instance.AppSettings("Authentication:OAuthAppName"));
            //    }
            //});

        }
    }
}
