using Igland.MVC.Models.ServiceDokument;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(100, ErrorMessage = "Kan ikke være lengre enn 100 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn er tillatt.")]
        public string? MekanikerNavn { get; set; }

        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? SerieNummer { get; set; }


        public DateOnly Dato { get; set; }


        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public decimal AntallTimer { get; set; }



        [StringLength(300, ErrorMessage = "Kan ikke være lengre enn 300 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn er tillatt.")]
        public string? MekanikerKommentar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SjekklisteID { get; set; }

        [Required]
        [Range(9999999, 99999999, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int OrdreNummer { get; set; }

        public List<SjekklisteJobGroupModel> JobGroups { get; set; }

        public string? StatusString { get; set; }

        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? ClutchLameller { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Bremser {  get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Trommel { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? PTO { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Kjedestrammer { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Wire { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Pinion { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Kjedehjul { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Hydraulisksylinder { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Slanger { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Hydraulikkblokk { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Oljetank { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Oljegir { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Ringsylinder { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Bremsesylinder { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Ledningsnett { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Testradio { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Knappekasse { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Xxbar { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Testvinsj { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Trekkraftkn { get; set; }
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Bremsekraft { get; set; }

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
