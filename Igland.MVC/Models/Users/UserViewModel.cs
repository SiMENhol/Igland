using Igland.MVC.Entities;
using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.Users
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public List<UserEntity> Users { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
