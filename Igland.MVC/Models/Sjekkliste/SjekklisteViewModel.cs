using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.Sjekkliste
{
    public class SjekklisteViewModel
    {
        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(100, ErrorMessage = "Kan ikke være lengre enn 100 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn er tillatt.")]
        public string Mechanic { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        public DateOnly CreatedDate { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public decimal ConsumedHours { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(300, ErrorMessage = "Kan ikke være lengre enn 300 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9\s]*$", ErrorMessage = "Kun alfanumeriske tegn er tillatt.")]
        public string MechanicComment { get; set; }

        
        public int ServiceOrderId { get; set; }

        [Required(ErrorMessage = "Listen må fylles ut.")]
        public List<SjekklisteJobGroupModel> JobGroups { get; set; }

    }
  
    public class SjekklisteJobGroupModel
    {
        public string Name { get; set; }

        public List<string> Jobs { get; set; }
    }

}
