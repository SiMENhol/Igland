using Igland.MVC.Models.ServiceOrdre;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ServiceOrderViewModel
            {
                ConsumedHours = 0,
                CreatedDate = new DateOnly(2023, 10, 25),
                JobGroups = new List<ServiceOrderJobGroupModel> {
                    new ServiceOrderJobGroupModel {Name ="Mekanisk", Jobs=new List<string>{"Sjekk clutch lameller for slitasje", "Sjekk bremser. Bånd/Pal", "Sjekk lager for trommel", "Sjekk PTO og opplagring", "Sjekk kjedestrammer", "Sjekk wire", "Sjekk pinion lager", "Sjekk kile på kjedehjul"} },
                    new ServiceOrderJobGroupModel{ Name="Hydraulisk", Jobs=new List<string>{"Sjekk hydraulisk sylinder for lekkasje","Sjekk slanger for skader og lekkasje", "Test hydraulikkblokk i testbenk", "Skift olje i tank", "Skift olje på gir boks", "Sjekk Ringsylinder åpne og skift tetninger", "Sjekk bremse sylinder åpne og skift tetninger" } },
                    new ServiceOrderJobGroupModel{ Name="Elektro", Jobs=new List<string>{"Sjekk ledningsnett på vinsj","Sjekk og test radio","Sjekk og test knappekasse" } },
                    new ServiceOrderJobGroupModel{ Name="Trykk settinger", Jobs=new List<string>{"xx- bar" } },
                    new ServiceOrderJobGroupModel{ Name="Funksjons test", Jobs=new List<string>{"Test vinsj og kjør alle funksjoner", "Trekkraft KN", "Bremse kraft KN" } },
                },
                Mechanic = "",
                MechanicComment = "",
                SerialNumber = "",
                ServiceOrderId = 1
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ServiceOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var s = "ineedabreakpoint";

            }
            return View("Index", model);
        }
    }
}
