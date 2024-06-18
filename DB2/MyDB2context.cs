
using DB2.Model;
using Microsoft.EntityFrameworkCore;


namespace DB2
{
    public class MyDB2context : DbContext 
    {
        public DbSet<MyUser> MyUser { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Groups> Groups { get; set; }
      //  public DbSet<Learner> Learners { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Sсhedule> Schedules { get; set; }
     //   public DbSet<Teacher> Teachers { get; set; }

        //public DbSet<PlaceOfRealization> PlaceOfRealizations { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }

        public MyDB2context(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

        }    
    }
}
