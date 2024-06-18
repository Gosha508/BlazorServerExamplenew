using System.ComponentModel.DataAnnotations;


namespace BD.Model
{
    public class Attendance // посещаеомсть
    {
        [Key]
        public int Id { get; set;}

        public bool IsPresent { get; set;}    
        //public int IdLearner { get; set;}
        public Learner? Learner { get; set;}
        //public int IdLesson { get; set; }
        public Lesson? Lesson { get; set;}
        public string Description { get; set;}
        
    }
}
//statehaschanged -- обнова станицы в блазор  