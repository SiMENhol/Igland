namespace Igland.MVC.Models.ArbDok
{
    public class ArbDokFullViewModel
    {
        public ArbDokFullViewModel()
        {
            UpsertModel = new ArbDokViewModel();
            ArbDokList = new List<ArbDokViewModel>();
        }
        public ArbDokViewModel UpsertModel { get; set; }
        public List<ArbDokViewModel> ArbDokList { get; set;}
    }
    public class ArbDokViewModel
    {
        public int ArbDokID {  get; set; }
        public int OrdreNummer {  get; set; }
        public string? Kunde {  get; set; }
        public string? Vinsj {  get; set; }
        public DateOnly HenvendelseMotatt {  get; set; }
        public DateOnly AvtaltLevering { get; set; }
        public DateOnly ProduktMotatt { get; set; }
        public DateOnly SjekkUtfort { get; set; }
        public DateOnly AvtaltFerdig {  get; set; }
        public DateOnly ServiceFerdig { get; set; }
        public int AntallTimer { get; set; }
        public string? BestillingFraKunde { get; set; }
        public string? NotatFraMekaniker { get; set; }
        public string? Status {  get; set; }
    }
}
