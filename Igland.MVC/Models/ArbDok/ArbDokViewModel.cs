using Igland.MVC.Models.Kunder;
using Igland.MVC.Models.Ordre;
using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.ArbDok
{
    public class ArbDokFullViewModel
    {
        public ArbDokFullViewModel()
        {
            UpsertArbDok = new ArbDokViewModel();
            UpsertOrdre = new OrdreViewModel();
            UpsertKunder = new KunderViewModel();

            ArbDokList = new List<ArbDokViewModel>();
            OrdreList = new List<OrdreViewModel>();
            KunderList = new List<KunderViewModel>();
        }
        public ArbDokViewModel UpsertArbDok { get; set; }
        public OrdreViewModel UpsertOrdre { get; set; }
        public KunderViewModel UpsertKunder { get; set; }

        public List<ArbDokViewModel> ArbDokList { get; set;}
        public List<OrdreViewModel> OrdreList { get; set;}
        public List<KunderViewModel> KunderList { get; set;}
    }
    public class ArbDokViewModel
    {
        [Required]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int ArbDokID {  get; set; }
        [Required]
        [Range(9999999, 99999999, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int OrdreNummer {  get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Kunde {  get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Vinsj {  get; set; }
        public DateOnly HenvendelseMotatt {  get; set; }
        public DateOnly AvtaltLevering { get; set; }
        public DateOnly ProduktMotatt { get; set; }
        public DateOnly SjekkUtfort { get; set; }
        public DateOnly AvtaltFerdig {  get; set; }
        public DateOnly ServiceFerdig { get; set; }
        [Range(0, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int AntallTimer { get; set; }
        [StringLength(255, ErrorMessage = "Kan ikke være lengre enn 255 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? BestillingFraKunde { get; set; }
        [StringLength(255, ErrorMessage = "Kan ikke være lengre enn 255 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? NotatFraMekaniker { get; set; }

        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Status {  get; set; }
    }
}
