using System.ComponentModel.DataAnnotations;

namespace BD.Model
{
    public class PlaceOfRealization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
