using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities

{
        [Table("Sjekkliste")]
        public class SjekklisteEntity
        {
            public string? MekanikerNavn { get; set; }
            public string? SerieNummer { get; set; }
            public DateOnly Dato { get; set; }
            public decimal AntallTimer { get; set; }
            public string? MekanikerKommentar { get; set; }
            public int SjekklisteID { get; set; }
            public int OrdreNummer { get; set; }
            public string? StatusString { get; set; }
    }
} 
