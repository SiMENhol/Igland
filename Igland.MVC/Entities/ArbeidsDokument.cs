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
            public DateOnly HenvendelseMotatt { get; set; }
            public DateOnly? AvtaltLevering { get; set; }
            public DateOnly? ProduktMotatt { get; set; }
            public DateOnly? SjekkUtfort { get; set; }
            public DateOnly? AvtaltFerdig { get; set; }
            public DateOnly? ServiceFerdig { get; set; }
            public int? AntallTimer { get; set; }
            public string? BestillingFraKunde { get; set; }
            public string? NotatFraMekaniker { get; set; }
            public string? Status { get; set; }
        }
    }
