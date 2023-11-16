using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Models.Kunder

{
    public class KunderFullViewModel
    {
        public KunderFullViewModel()
        {
            UpsertModel = new KunderViewModel();
            KunderOversikt = new List<KunderViewModel>();
        }
        public KunderViewModel UpsertModel { get; set; }
        public List<KunderViewModel> KunderOversikt { get; set; }


    }
    public class KunderViewModel
    {
        [Range(10000000,99999999, ErrorMessage = "Nummeret må være minst 8 siffre langt.")]
        public int KundeID { get; set; }
        public string? KundeNavn { get; set; }
    }
}

