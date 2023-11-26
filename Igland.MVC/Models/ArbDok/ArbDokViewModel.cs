using Igland.MVC.Models.Kunder;
using Igland.MVC.Models.Ordre;
using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.ArbDok
{
    public class ArbDokFullViewModel
    {
        public ArbDokFullViewModel()
        {
            UpsertArbDok = new ArbDokViewModel();
            UpsertOrdre = new OrdreViewModel();
            UpsertKunder = new KunderViewModel();

            ArbDokList = new List<ArbDokViewModel>();
            OrdreList = new List<OrdreViewModel>();
            KunderList = new List<KunderViewModel>();
        }
        public ArbDokViewModel UpsertArbDok { get; set; }
        public OrdreViewModel UpsertOrdre { get; set; }
        public KunderViewModel UpsertKunder { get; set; }

        public List<ArbDokViewModel> ArbDokList { get; set;}
        public List<OrdreViewModel> OrdreList { get; set;}
        public List<KunderViewModel> KunderList { get; set;}
    }
    public class ArbDokViewModel
    {
        public int ArbDokID {  get; set; }
        public int OrdreNummer {  get; set; }
        [StringLength(50)]
        public string? Kunde {  get; set; }
        [StringLength(50)]
        public string? Vinsj {  get; set; }
        public DateOnly HenvendelseMotatt {  get; set; }
        public DateOnly AvtaltLevering { get; set; }
        public DateOnly ProduktMotatt { get; set; }
        public DateOnly SjekkUtfort { get; set; }
        public DateOnly AvtaltFerdig {  get; set; }
        public DateOnly ServiceFerdig { get; set; }
        public int AntallTimer { get; set; }
        [StringLength(50)]
        public string? BestillingFraKunde { get; set; }
        [StringLength(100)]
        public string? NotatFraMekaniker { get; set; }
        [StringLength(50)]
        public string? Status {  get; set; }
    }
}
