using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (httpcontext,next)=> {
                Console.WriteLine("开始中间件A");
                await next();
                Console.WriteLine("退出中间件A");
            });

            app.Use(async (httpcontext, next) => {
                Console.WriteLine("开始中间件B");
                await next();
                Console.WriteLine("退出中间件B");
            });

            app.UseRouting();

            app.Run(async (context) =>
            {
                await Task.Delay(1000);
                context.Response.ContentType = "text/plain;charset=utf-8";
                await context.Response.WriteAsync("中断中间件");
            }); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.ContentType = "text/palin;charset=utf-8";
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
