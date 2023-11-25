using Igland.MVC.Entities;
using Igland.MVC.Models.Account;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Models.Ordre;

namespace Igland.MVC.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            LoginOversikt = new List<LoginViewModel>();
            OrdreOversikt = new List<OrdreViewModel>();
            ArbDokList = new List<ArbDokViewModel>();
            KunderOversikt = new List<KunderViewModel>();
        }
        public List<LoginViewModel> LoginOversikt { get; set; }
        public List<OrdreViewModel> OrdreOversikt { get; set; }
        public List<ArbDokViewModel> ArbDokList { get; set; }
        public List<KunderViewModel> KunderOversikt { get; set; }
    }

}
