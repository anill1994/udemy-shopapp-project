using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using shopapp.business.Abstract;
using shopapp.business.Concrete;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;

namespace shopapp.webui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository,EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
            services.AddScoped<IProductService,ProductManager>();
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions{
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                    RequestPath="/modules"
            });
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name:"adminproducts",
                    pattern:"admin/products",
                    defaults: new {controller="admin", action="productlist"}
                );
                endpoints.MapControllerRoute(
                    name:"adminproducts",
                    pattern:"admin/productcreate",
                    defaults: new {controller="admin", action="productcreate"}
                );
                  endpoints.MapControllerRoute(
                    name:"adminproductedit",
                    pattern:"admin/products/{id?}",
                    defaults: new {controller="admin", action="ProductEdit"} 
                );
                endpoints.MapControllerRoute(
                    name:"admincategories",
                    pattern:"admin/categories",
                    defaults: new {controller="admin", action="categorylist"}
                );
                endpoints.MapControllerRoute(
                    name:"admincategorycreate",
                    pattern:"admin/categorycreate",
                    defaults: new {controller="admin", action="categorycreate"}
                );
                  endpoints.MapControllerRoute(
                    name:"admincategoryedit",
                    pattern:"admin/categories/{id?}",
                    defaults: new {controller="admin", action="categoryEdit"} 
                );

                  endpoints.MapControllerRoute(
                    name:"search",
                    pattern:"{search}",
                    defaults: new {controller="shop", action="search"}
                );
                endpoints.MapControllerRoute(
                    name:"productdetails",
                    pattern:"{url}",
                    defaults: new {controller="shop", action="details"} 
                );
                endpoints.MapControllerRoute(
                    name:"products",
                    pattern:"products/{category?}",
                    defaults: new {controller="shop", action="list"} 
                );
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
