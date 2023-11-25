using Igland.MVC.Models.Sjekkliste;

namespace Igland.MVC.CommonMethods
{
    public class SjekklisteRadioButtonValues
    {
        /// <summary>
        /// Create a statusString that contains values of the radio buttons from the Sjekkliste/Ny View
        /// </summary>
        /// <param name="sjekkliste">The SjekklisteFullViewModel.</param>
        /// <returns>A string containing values of radio buttons, separated by a comma(,).</returns>
        public string createStatusString(SjekklisteFullViewModel sjekkliste)
        {
            var statusString = "";
            statusString += sjekkliste.UpsertModel.ClutchLameller + ",";
            statusString += sjekkliste.UpsertModel.Bremser + ",";
            statusString += sjekkliste.UpsertModel.Trommel + ",";
            statusString += sjekkliste.UpsertModel.PTO + ",";
            statusString += sjekkliste.UpsertModel.Kjedestrammer + ",";
            statusString += sjekkliste.UpsertModel.Wire + ",";
            statusString += sjekkliste.UpsertModel.Pinion + ",";
            statusString += sjekkliste.UpsertModel.Kjedehjul + ",";
            statusString += sjekkliste.UpsertModel.Hydraulisksylinder + ",";
            statusString += sjekkliste.UpsertModel.Slanger + ",";
            statusString += sjekkliste.UpsertModel.Hydraulikkblokk + ",";
            statusString += sjekkliste.UpsertModel.Oljetank + ",";
            statusString += sjekkliste.UpsertModel.Oljegir + ",";
            statusString += sjekkliste.UpsertModel.Ringsylinder + ",";
            statusString += sjekkliste.UpsertModel.Bremsesylinder + ",";
            statusString += sjekkliste.UpsertModel.Ledningsnett + ",";
            statusString += sjekkliste.UpsertModel.Testradio + ",";
            statusString += sjekkliste.UpsertModel.Knappekasse + ",";
            statusString += sjekkliste.UpsertModel.Xxbar + ",";
            statusString += sjekkliste.UpsertModel.Testvinsj + ",";
            statusString += sjekkliste.UpsertModel.Trekkraftkn + ",";
            statusString += sjekkliste.UpsertModel.Bremsekraft + ",";
            return statusString;
        }

        /// <summary>
        /// Breaks up the specified statusString and sorts the different values into a list.
        /// </summary>
        /// <param name="str">The desired statusString to be sorted.</param>
        /// <returns>A list of strings, containing values for each individual radio button.</returns>
        public List<string> sortStatusString(string str)
        {
            string itemValue = "";
            List<string> liste = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals(','))
                {
                    liste.Add(itemValue);
                    itemValue = "";
                }
                else if (str[i].Equals('0'))
                    itemValue += "0"; // "Defekt"
                else if (str[i].Equals('1'))
                    itemValue += "1"; // "Skal endres"
                else if (str[i].Equals('2'))
                    itemValue += "2"; // "OK
                else 
                    itemValue += "-1"; // tom
            }
            return liste;
        }
    }
}
