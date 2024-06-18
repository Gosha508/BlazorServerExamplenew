using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BD.Model
{
    public class Sсhedule
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public DateTime dateTime { get; set; }
    }
}
