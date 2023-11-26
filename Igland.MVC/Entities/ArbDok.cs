using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities
{
    [Table("ArbDok")]
    public class ArbDok
    {
        public int ArbDokID { get; set; }
        public int OrdreNummer { get; set; }
        public string? Uke { get; set; }
        public DateOnly HenvendelseMotatt { get; set; }
        public DateOnly AvtaltLevering { get; set; }
        public DateOnly ProduktMotatt { get; set; }
        public DateOnly SjekkUtfort { get; set; }
        public DateOnly AvtaltFerdig { get; set; }
        public DateOnly ServiceFerdig { get; set; }
        public int AntallTimer { get; set; }
        public string? BestillingFraKunde { get; set; }
        public string? NotatFraMekaniker { get; set; }
    }
}
