using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.Home

{
    public class HomeFullViewModel
    {
        public HomeFullViewModel()
        {
            UpsertModel = new HomeViewModel();
            UserList = new List<HomeViewModel>();
        }
        public HomeViewModel UpsertModel { get; set; }
        public List<HomeViewModel> UserList { get; set; }


    }

    public class HomeViewModel
    {

        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }


}