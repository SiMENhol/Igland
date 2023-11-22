using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities

{
    [Table("Ordre")]
    public class OrdreEntity
    {
        public int OrdreNummer { get; set; }
        public int KundeID { get; set; }
        public string SerieNummer { get; set; }
        public string VareNavn { get; set; }
        public string Status { get; set; }
    }
}
