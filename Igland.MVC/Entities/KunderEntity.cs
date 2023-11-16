using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities

{
    [Table("Kunder")]
    public class KunderEntity
    {
        public int KundeID { get; set; }
        public string? KundeNavn { get; set; }
    }
}