using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Models.ArbeidsDokument

{
    public class ArbeidsDokumentFullViewModel
    {
        public ArbeidsDokumentFullViewModel()
        {
            UpsertModel = new ArbeidsDokumentViewModel();
            ArbeidsDokOversikt = new List<ArbeidsDokumentViewModel>();
        }
        public ArbeidsDokumentViewModel UpsertModel { get; set; }
        public List<ArbeidsDokumentViewModel> ArbeidsDokOversikt { get; set; }


    }
    public class ArbeidsDokumentViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArbeidsDokumentID { get; set; }

        //[MinLength(8, ErrorMessage = "Nummeret må være minst 8 siffre langt.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        [ForeignKey("Ordrenummer")]
        public int Ordrenummer { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Kunde { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Vinsj { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        public DateTime HenvendelseMotatt { get; set; }

        public DateTime? AvtaltLevering { get; set; }

        public DateTime? ProduktMotatt { get; set; }

        public DateTime? SjekkUtfort { get; set; }

        public DateTime? AvtaltFerdig { get; set; }

        public DateTime? ServiceFerdig { get; set; }

        [Range(1, 100, ErrorMessage = "Verdien må være mellom 0 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int? AntallTimer { get; set; }

        [StringLength(500, ErrorMessage = "Kan ikke være lengre enn 500 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? BestillingFraKunde { get; set; }

        //Bilde?

        [StringLength(500, ErrorMessage = "Kan ikke være lengre enn 500 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? NotatFraMekaniker { get; set; }

        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Status { get; set; }
    }
}
