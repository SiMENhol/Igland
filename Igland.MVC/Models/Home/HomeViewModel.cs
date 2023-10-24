using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.ServiceDocOversikt

{
    public class ServiceDocOversiktFullViewModel
    {
        public ServiceDocOversiktFullViewModel()
        {
            UpsertModel = new ServiceDocOversiktViewModel();
            UserList = new List<ServiceDocOversiktViewModel>();
        }
        public ServiceDocOversiktViewModel UpsertModel { get; set; }
        public List<ServiceDocOversiktViewModel> UserList { get; set; }


    }

    public class ServiceDocOversiktViewModel
    {
       public int ServiceSkjemaID { get; set; }

        public int OrdreNummer { get; set; }

        public int AArsmodel { get; set; }

        public string Garanti { get; set; }

        public string Reperasjonsbeskrivelse { get; set; }

        public string MedgaatteDeler { get; set; }

        public string ForsendelseMaate { get; set; }

    }



}