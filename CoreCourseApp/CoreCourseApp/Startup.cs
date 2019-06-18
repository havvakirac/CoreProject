using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreCourseApp.Infrastructure;
using CoreCourseApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace CoreCourseApp
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection"));
                options.EnableSensitiveDataLogging(true);


            });

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AppUserConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>
                (options =>
                {
                    //Şifre Ayarları
                    options.Password.RequiredLength = 4;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = true;


                    //User Validatio Detail
                    //options.User.AllowedUserNameCharacters = "abc";
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AppIdentityDbContext>()  //sistemin calismasi icin gerekli olan dosyalar
                .AddDefaultTokenProviders();

            //Her yeni olusturulan repository icin buraya servis eklemeyi unutma !!
            services.AddTransient<ICourseRepository, EfCourseRepository>();
            services.AddTransient<IInstructorRepository, EfInstructorRepository>();
            services.AddTransient<IGenericRepository<Contact>, EfGenericRepository<Contact>>();
            services.AddTransient<IGenericRepository<Address>, EfGenericRepository<Address>>();

            services.AddTransient<IPasswordValidator<ApplicationUser>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<ApplicationUser>, CustomUserValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed(dataContext); //seed database bu sekilde tanimlanmis oldu
                                                //Hata  olustugunda da hata kodlarını gostersin
                app.UseDeveloperExceptionPage();

                //Server tarafindan gonderilen hata kodlarını gormek icin
                app.UseStatusCodePages();

                //Varsayilan olarak wwwroot klasorunu aktif hale getiriyoruz.
                app.UseStaticFiles();

                app.UseAuthentication();  //2. db icin eklendi buda

                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine
                    (Directory.GetCurrentDirectory(), @"node_modules")),
                    RequestPath = new PathString("/vendor")
                });


                //app.Run(async (context) =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                app.UseMvcWithDefaultRoute();
            }

        }
    }
}
