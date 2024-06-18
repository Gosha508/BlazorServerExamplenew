using BlazorServerExample.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DB;
//using BD.Model;

namespace BlazorServerExample.Storage
{
    public class AppDbContext : DbContext
    {
        // public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        //public DbSet<MyUser> MyUser { get; set; }
        //public DbSet<Attendance> Attendances { get; set; }
        //public DbSet<Groups> Groups { get; set; }
        //public DbSet<Learner> Learners { get; set; }
        //public DbSet<Lesson> Lessons { get; set; }
        //public DbSet<Sсhedule> Schedules { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Discipline> Disciplines { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
