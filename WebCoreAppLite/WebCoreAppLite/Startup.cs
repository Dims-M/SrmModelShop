using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebCoreAppLite
{
    public class Startup
    {
        // Этот метод вызывается средой выполнения. Используйте этот метод для добавления служб в контейнер.
        // Дополнительные сведения о настройке приложения см. В разделе https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddMvc(); // добавление службы в сервис. для обработки запросов

        }

        // Этот метод вызывается средой выполнения. Используйте этот метод для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())  //проверяем находится ли приложение в режиме разработки. Если тру 
            {
                app.UseDeveloperExceptionPage();  // используем первый параметр.  Метод выводит ошибку клгда находимся в режиме разработки
            }

            else
            {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");  // 
            });
            }
        }
    }
}
