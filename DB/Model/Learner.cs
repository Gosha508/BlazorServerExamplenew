using System.ComponentModel.DataAnnotations;


namespace BD.Model
{
    public class Learner : MyUser  //учащиеся 
    {
        //[Key]
        //public int Id { get; set; }
        //public string Name { get; set; }    
        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Password { get; set; }
        //public int IdGroups { get; set; }
        public Groups Groups { get; set; }
        //public int IdMyUser { get; set; }
        //public MyUser MyUser { get; set; }
        //public int GroupsID { get; set; }
        // public ICollection<Attendance>? Attendances { get; set; }

    }
}
