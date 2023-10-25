namespace Igland.MVC.Models.ArbeidsDokument
{
    public class ArbeidsDokumentFullViewModel
    {
        public ArbeidsDokumentFullViewModel()
        {
            UpsertModel = new ArbeidsDokumentViewModel();
            ArbeidsDokOversikt = new List<ArbeidsDokumentViewModel>();
        }
        public ArbeidsDokumentViewModel UpsertModel { get; set; }
        public List<ArbeidsDokumentViewModel> ArbeidsDokOversikt { get; set; }


    }
    public class ArbeidsDokumentViewModel
    {
        public int ArbeidsDokumentID { get; set; }
        public int Ordrenummer { get; set; }
        public string Kunde {  get; set; }
        public string Vinsj {  get; set; }
        public DateTime HenvendelseMotatt {  get; set; }
        public string? AvtaltLevering { get; set; }
        public string? ProduktMotatt { get; set; }
        public string? SjekkUtført { get; set; }
        public string? AvtaltFerdig {  get; set; }
        public string? ServiceFerdig { get; set; }
        public int? AntallTimer { get; set; }
        public string? BestillingFraKunde { get; set; }
        public string? NotatFraMekaniker { get; set; }
        public string? Status {  get; set; }
    }
}
