using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities
{
    [Table("aspnetusers")]
    public class UserEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }


    }
}
