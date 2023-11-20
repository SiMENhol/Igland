using System.ComponentModel.DataAnnotations.Schema;

namespace Igland.MVC.Entities

{
        [Table("SjekklisteItem")]
        public class SjekklisteItemEntity
    {
            public int SjekklisteItemID { get; set; }
            public int SjekklisteID { get; set; }
            public string Jobs { get; set; }
            public string JobGroups { get; set; }
            public string RadioButtonValue { get; set; }

    }
} 
