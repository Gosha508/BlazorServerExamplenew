using System.ComponentModel.DataAnnotations;

namespace BD.Model
{
    public class Discipline
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
