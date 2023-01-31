using System.ComponentModel.DataAnnotations;

namespace Day3.ViewModels
{
    public class UserVM
    {
        [Key]
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
