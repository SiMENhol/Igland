using System.Xml.Linq;
using System.Xml;

namespace Igland.MVC.Models.LogIn
{
    public class LogInModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
