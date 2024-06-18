using DB2.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DB2.Model
{
    public class Attendance // посещаеомсть
    {
        [Key]
        public int Id { get; set;}

        public bool IsPresent { get; set;}    
        public string Grades { get; set; }
        //public int IdLearner { get; set;}
        public MyUser? MyUser { get; set;}
        //public int IdLesson { get; set; }
        public Lesson? Lesson { get; set;}
        public string Description { get; set;}

    }
}
//statehaschanged -- обнова станицы в блазор  