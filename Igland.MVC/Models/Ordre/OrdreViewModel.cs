using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Models.Sjekkliste;
using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.Ordre

{
    public class OrdreFullViewModel
    {
        public OrdreFullViewModel()
        {
            UpsertModel = new OrdreViewModel();
            OrdreOversikt = new List<OrdreViewModel>();
            UpsertArbDok = new ArbDokViewModel();
            UpsertSjekkliste = new SjekklisteViewModel();
            UpsertServicedokument = new ServiceDokumentViewModel();
            

            ArbDokList = new List<ArbDokViewModel>();
            SjekkelistList = new List<SjekklisteViewModel>();
            ServiceDokumentOversikt = new List<ServiceDokumentViewModel>();
        }
        public OrdreViewModel UpsertModel { get; set; }
        public List<OrdreViewModel> OrdreOversikt { get; set; }
        public ArbDokViewModel UpsertArbDok { get; set; }
        public SjekklisteViewModel UpsertSjekkliste { get; set; }
        public List<ArbDokViewModel> ArbDokList { get; set; }
        public List<SjekklisteViewModel> SjekkelistList { get; set; }

        public ServiceDokumentViewModel UpsertServicedokument { get; set; }
        public List<ServiceDokumentViewModel> ServiceDokumentOversikt { get; set; }
    }
    public class OrdreViewModel
    {
        [Required]
        [Range(9999999, 99999999, ErrorMessage = "Nummeret må være minst 8 siffre langt.")]
        public int OrdreNummer { get; set; }
        [Required]
        [Range(99, 999, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int KundeID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string SerieNummer { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string VareNavn { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Status { get; set; }
    }
}

