using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BD.Model;
namespace BD.Model
{
    public class Groups
    {
        [Key]
        public int Id { get; set; }    
        public string Name { get; set; }
        //public Discipline Discipline { get; set; }
        //public virtual ICollection<Lessons>? Lessons { get; set; }

        public virtual ICollection<Lesson>? Lessons { get; set; }
        //public virtual ICollection<MyUser>? MyUser { get; set; }
        public virtual ICollection<Learner> Learners { get; set; }
    }
}
