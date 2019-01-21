
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data;
using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
 
 
namespace Cesspool
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
               services.AddDbContext<DatosContext>(options =>
          options.UseMySQL("Server=localhost;Port=3306;Database=test;Uid=root;Pwd=Jurekjurek21`;SslMode=none;"));
         //  options.UseMySQL("Server=localhost;Port=3306;Database=test;Uid=root; SslMode = none;"));

             services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          app.UseMvc();
         //   app.Run(async (context) =>
         //  {
          //     await context.Response.WriteAsync("Hello World2!");
          //  });
        }
    }
}
