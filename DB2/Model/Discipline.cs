using System.ComponentModel.DataAnnotations;

namespace DB2.Model
{
    public class Discipline
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
