using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.Mapping;
using Life_Balance.BLL.Repository;
using Life_Balance.BLL.Services;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL;
using Life_Balance.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Life_Balance.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LifeBalanceDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnections")));
            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 5;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<LifeBalanceDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IDiaryService, DiaryService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IRazorViewToString, RazorViewToString>();
            services.AddScoped<IEventService, EventService>();
            services.AddControllersWithViews();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DiaryProfile());
                mc.AddProfile(new ProfileMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
