using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.ServiceDocOversikt

{
    public class HomeFullViewModel
    {
        public HomeFullViewModel()
        {
            UpsertModel = new ServiceDocOversikt();
            UserList = new List<ServiceDocOversikt>();
        }
        public ServiceDocOversikt UpsertModel { get; set; }
        public List<ServiceDocOversikt> UserList { get; set; }


    }

    public class ServiceDocOversikt
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