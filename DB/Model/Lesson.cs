using System;
using System.ComponentModel.DataAnnotations;


namespace BD.Model
{
    public class Lesson // урок
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }

        //public int IdDiscipline { get; set; }
        public Discipline? Discipline { get; set; }
        //public int IdTeachers { get; set; }
        public Teacher? Teacher { get; set; }
        //public int IdGroups { get; set; }
        public Groups? Groups { get; set; }


        //public int IdSсhedule { get; set; }
        public Sсhedule? Sсhedule { get; set; }
        //public DateTime dateTime {get;set;}

        public DateTime? TimeStart { get; set; }

        public DateTime? TimeEnd { get; set; }
    }
}
