using BlazorServerExample.Model;
using BlazorServerExample.Services;
using BlazorServerExample.Storage;
//using DB;
//using DB.Interface;
//using DB.Repository;
using DB2.Interface;
using DB2.Services;
using DB2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BlazorServerExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
           

            services.AddDbContext<MyDB2context>(options => options.UseSqlite(Configuration.GetConnectionString("sqlite")), ServiceLifetime.Transient);

            //AppDbContext
            //services.AddTransient<WeatherForecastService>();
            //services.AddTransient<MyUserService>();

            //services.AddTransient<ImyUser, UserRepository>();
            //services.AddTransient<IAttendance, AttendanceRepository>();
            //services.AddTransient<IGroups, GroupsRepository>();
            //services.AddTransient<ILearner, LearnersRepository>();
            //services.AddTransient<ILesson, LessonsRepository>();
            //services.AddTransient<ISchedule, SchedulesRepository>();
            //services.AddTransient<ITeacher, TeachersRepository>();
            //services.AddTransient<IDiscipline, DisciplineRepository>();
            services.AddTransient<IMyUser, MyUserService>();
            services.AddTransient<ISchedule, ScheduleService>();
            services.AddTransient<IDiscipline, DisciplineService>();
            services.AddTransient<IGroups, GroupsService>();
            services.AddTransient<IAttendance, AttendanceService>();
            services.AddTransient<ILesson, LessonService>();
            //прописать остальное

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            using (var scope = app.ApplicationServices.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<MyDB2context>(); //AppDbContext
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
