using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SomeUsualShop.Models;
using SomeUsualShop.Models.Interfaces;

namespace SomeUsualShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opts
                => opts.UseSqlServer(Configuration["Data:DriveTurboProducts:ConnectionString"]));
            
            services.AddTransient<IProductRepository,EfProductRepository>();
            services.AddTransient<ICategoryRepository, EfCategoryRepository>();
            services.AddTransient<IOrderRepository, EfOrderRepository>();
            
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc(point => point.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //js, css files and etc...
            app.UseStaticFiles();
            app.UseSession();
            
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
        }
    }
}