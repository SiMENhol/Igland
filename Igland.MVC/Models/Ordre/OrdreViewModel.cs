using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Models.Ordre

{
    public class OrdreFullViewModel
    {
        public OrdreFullViewModel()
        {
            UpsertModel = new OrdreViewModel();
            OrdreOversikt = new List<OrdreViewModel>();
        }
        public OrdreViewModel UpsertModel { get; set; }
        public List<OrdreViewModel> OrdreOversikt { get; set; }


    }
    public class OrdreViewModel
    {
        [Range(10000000, 99999999, ErrorMessage = "Nummeret må være minst 8 siffre langt.")]
        public int OrdreNummer { get; set; }
        public int KundeID { get; set; }
        public string? SerieNummer { get; set; }
        public string? VareNavn { get; set; }
        public string? Status { get; set; }
        public string? ArbDokument { get; set; }
    }
}

