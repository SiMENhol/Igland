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

        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Du må fylle inn navn.")]
        [StringLength(50, ErrorMessage = "Navn kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du må fylle inn email.")]
        [StringLength(50, ErrorMessage = "Email kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        [EmailAddress(ErrorMessage = "Feil email format")]
        public string Email { get; set; }
    }
}