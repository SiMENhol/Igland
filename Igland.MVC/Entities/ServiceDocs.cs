using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities
{
    [Table("ServiceSkjema")]
    public class ServiceDokumentEntity
    {
        public int ServiceSkjemaID { get; set; }
        public int? OrdreNummer { get; set; }

        public int Aarsmodel { get; set; }

        public string Garanti { get; set; }

        public string Reparasjonsbeskrivelse { get; set; }

        public string MedgaatteDeler { get; set; }

        public string DeleRetur {  get; set; }

        public string ForesendelsesMaate { get; set; }
    }
}
