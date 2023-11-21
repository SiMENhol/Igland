using Igland.MVC.Models.ServiceDokument;
using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.Sjekkliste
{
    public class SjekklisteFullViewModel
    {
        public SjekklisteFullViewModel()
        {
            UpsertModel = new SjekklisteViewModel();
            SjekklisteOversikt = new List<SjekklisteViewModel>();
        }
        public SjekklisteViewModel UpsertModel { get; set; }
        public List<SjekklisteViewModel> SjekklisteOversikt { get; set; }
    }
    public class SjekklisteViewModel
    {
        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(100, ErrorMessage = "Kan ikke være lengre enn 100 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn er tillatt.")]
        public string? MekanikerNavn { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? SerieNummer { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        public DateOnly Dato { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public decimal AntallTimer { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(300, ErrorMessage = "Kan ikke være lengre enn 300 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn er tillatt.")]
        public string? MekanikerKommentar { get; set; }

        
        public int SjekklisteID { get; set; }

        public int OrdreNummer { get; set; }

        public string? RadioButtonValues { get; set; }

        [Required(ErrorMessage = "Listen må fylles ut.")]
        public List<SjekklisteJobGroupModel> JobGroups { get; set; }

        public string? ClutchLameller { get; set; }

    }

    public class SjekklisteJobGroupModel
    {
        public string? Name { get; set; }

        public List<Jobs> Jobs { get; set; }
    }

    public class Jobs
    {
        public string? Name { get; set; }
        public int Value { get; set; }
    }


}
