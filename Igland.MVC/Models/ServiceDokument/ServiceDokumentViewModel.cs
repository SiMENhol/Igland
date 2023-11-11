using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Models.ServiceDokument

{
    public class ServiceDokumentFullViewModel
    {
        public ServiceDokumentFullViewModel()
        {
            UpsertModel = new ServiceDokumentViewModel();
            ServiceDokumentOversikt = new List<ServiceDokumentViewModel>();
        }
        public ServiceDokumentViewModel UpsertModel { get; set; }
        public List<ServiceDokumentViewModel> ServiceDokumentOversikt { get; set; }


    }

    public class ServiceDokumentViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceSkjemaID { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int OrdreNummer { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int Aarsmodel { get; set; }

        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Garanti { get; set; }

 
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? Reparasjonsbeskrivelse { get; set; }


        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? MedgaatteDeler { get; set; }

   
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? DeleRetur { get; set; }


        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string? ForesendelsesMaate { get; set; }

    }



}