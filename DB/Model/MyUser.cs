using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BD.Model
{
    public class MyUser
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }

        //public ICollection<Lessons>? Lessons { get; set; }
        //public ICollection<Groups>? Groups { get; set; }

        [Column("Discriminator")]
        public string Discriminator { get; set; }
    }
}
