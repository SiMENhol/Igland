using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Models.Sjekkliste;
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
            UpsertArbDok = new ArbDokViewModel();
            UpsertSjekkliste = new SjekklisteViewModel();
            UpsertServicedokument = new ServiceDokumentViewModel();
            

            ArbDokList = new List<ArbDokViewModel>();
            SjekkelistList = new List<SjekklisteViewModel>();
            ServiceDokumentOversikt = new List<ServiceDokumentViewModel>();
        }
        public OrdreViewModel UpsertModel { get; set; }
        public List<OrdreViewModel> OrdreOversikt { get; set; }
        public ArbDokViewModel UpsertArbDok { get; set; }
        public SjekklisteViewModel UpsertSjekkliste { get; set; }
        public List<ArbDokViewModel> ArbDokList { get; set; }
        public List<SjekklisteViewModel> SjekkelistList { get; set; }

        public ServiceDokumentViewModel UpsertServicedokument { get; set; }
        public List<ServiceDokumentViewModel> ServiceDokumentOversikt { get; set; }
    }
    public class OrdreViewModel
    {
        [Range(10000000, 99999999, ErrorMessage = "Nummeret må være minst 8 siffre langt.")]
        public int OrdreNummer { get; set; }
        public int KundeID { get; set; }
        public string SerieNummer { get; set; }
        public string VareNavn { get; set; }
        public string Status { get; set; }
        public string ArbDokument { get; set; }
    }
}

