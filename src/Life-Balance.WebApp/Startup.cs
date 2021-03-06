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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Life_Balance.BLL.Models;

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
            services.AddTransient<LifeBalanceDbContext>();
            services.AddDbContext<LifeBalanceDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgresConnections")));
            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<LifeBalanceDbContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IMailSettings>(Configuration.GetSection("MailSettings").Get<MailSettings>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IDiaryService, DiaryService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IRazorViewToString, RazorViewToString>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddControllersWithViews();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSwaggerGen();

            services.AddCors();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DiaryProfile());
                mc.AddProfile(new ProfileMapperProfile());
                mc.AddProfile(new EventProfile());
                mc.AddProfile(new ToDoProfile());
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

            app.UseCors(options => options.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Life Balance"));

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
