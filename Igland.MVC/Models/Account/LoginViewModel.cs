using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.Account;

public class LoginFullViewModel
{
    public LoginFullViewModel()
    {
        LoginOversikt = new List<LoginViewModel>();
    }
    public List<LoginViewModel> LoginOversikt { get; set; }


}



public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
