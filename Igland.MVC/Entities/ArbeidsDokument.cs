using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities

{
        [Table("ArbDokument")]
        public class ArbeidsDokumentEntity
        {
            public int ArbeidsDokumentID { get; set; }
            public int Ordrenummer { get; set; }
            public string Kunde { get; set; }
            public string Vinsj { get; set; }
            public DateTime HenvendelseMotatt { get; set; }
            public DateTime? AvtaltLevering { get; set; }
            public DateTime? ProduktMotatt { get; set; }
            public DateTime? SjekkUtfort { get; set; }
            public DateTime? AvtaltFerdig { get; set; }
            public DateTime? ServiceFerdig { get; set; }
            public int? AntallTimer { get; set; }
            public string? BestillingFraKunde { get; set; }
            public string? NotatFraMekaniker { get; set; }
            public string? Status { get; set; }
        }
    }
