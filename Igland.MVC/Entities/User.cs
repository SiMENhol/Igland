using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities
{
    [Table("aspnetusers")]
    public class UserEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        public Boolean IsAdmin { get; set; }
    }
}
