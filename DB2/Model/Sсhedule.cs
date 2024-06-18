using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB2.Model
{
    public class Sсhedule
    {
        [Key]
        public int Id { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
        public DateTime dateTime { get; set; }
    }
}
