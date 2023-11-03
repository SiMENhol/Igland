using Igland.MVC.Entities;

namespace Igland.MVC.Models.Users
{
    public class UserViewModel
    {
        public string UserName { get; set; }
      
        public string Email { get; set; }

        public string Password { get; set; }

        public List<UserEntity> Users { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
