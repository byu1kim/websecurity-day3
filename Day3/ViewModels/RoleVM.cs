using System.ComponentModel.DataAnnotations;

namespace Day3.ViewModels
{
    public class RoleVM
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

    }
}
