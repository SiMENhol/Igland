using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities

{
    public class ArbeidsDokument
    {
        [Table("ArbDokument")]
        public class ArbeidsDokumentEntity
        {
            public int ArbeidsDokumentID { get; set; }
            public int Ordrenummer { get; set; }
            public string Kunde { get; set; }
            public string Vinsj { get; set; }
            public DateTime HenvendelseMotatt { get; set; }
            public string? AvtaltLevering { get; set; }
            public string? ProduktMotatt { get; set; }
            public string? SjekkUtført { get; set; }
            public string? AvtaltFerdig { get; set; }
            public string? ServiceFerdig { get; set; }
            public int? AntallTimer { get; set; }
            public string? BestillingFraKunde { get; set; }
            public string? NotatFraMekaniker { get; set; }
            public string? Status { get; set; }
        }
    }
}
