using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Range(99, 999, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int KundeID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string KundeNavn { get; set; }
    }
}

