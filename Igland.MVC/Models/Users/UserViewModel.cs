using Igland.MVC.Entities;
using Igland.MVC.Repositories;

namespace Igland.MVC.Models.Users
{
    public class UserViewModel
    {
        public string Name { get; set; }
      
        public string Email { get; set; }

        public List<UserEntity> Users { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
