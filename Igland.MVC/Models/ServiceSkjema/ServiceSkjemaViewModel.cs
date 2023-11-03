using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.ServiceSkjema

{
    public class ServiceSkjemaFullViewModel
    {
        public ServiceSkjemaFullViewModel()
        {
            UpsertModel = new ServiceSkjemaViewModel();
            ServiceDocOversikt = new List<ServiceSkjemaViewModel>();
        }
        public ServiceSkjemaViewModel UpsertModel { get; set; }
        public List<ServiceSkjemaViewModel> ServiceDocOversikt { get; set; }


    }

    public class ServiceSkjemaViewModel
    {
        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int ServiceSkjemaID { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int OrdreNummer { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int Aarsmodel { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Garanti { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Reparasjonsbeskrivelse { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string MedgaatteDeler { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string DeleRetur { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string ForesendelsesMaate { get; set; }

    }



}