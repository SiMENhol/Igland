namespace Igland.MVC.CommonMethods
{
    public class Date
    {
        // Funksjon som formaterer dato alt etter hvordan vi ønsker å vise det
        // Inspirert av geekforgeeks: https://www.geeksforgeeks.org/program-to-replace-every-space-in-a-string-with-hyphen/
        private string formatDate(string str, string purpose)
        {
            string returString = "";
            string d = "";
            string m = "";
            string y = "";
            int numberOfPeriods = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals('/'))
                    numberOfPeriods++;
                else
                {
                    if (numberOfPeriods == 0)
                        m += str[i];
                    else if (numberOfPeriods == 1)
                        d += str[i];
                    else
                        y += str[i];
                }
            }

            if (purpose.Equals("viewing"))
            {
                if (y.Equals("0001"))
                    returString = "Ikke satt";
                else
                    returString = d + "." + m + "." + y;
            }
            else if (purpose.Equals("input field"))
            {
                if (y.Equals("0001"))
                    returString = "";
                else
                    returString = y + "-" + m + "-" + d;
            }

            return returString;
        }

        public string formatDateForViewing(string inputString)
        {
            return formatDate(inputString, "viewing");
        }

        public string formatDateForInputField(string inputString)
        {
            return formatDate(inputString, "input field");
        }
    }
}