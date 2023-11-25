namespace Igland.MVC.CommonMethods
{
    public class Date
    {
        /// <summary>
        /// Formats dates to the desired format based on their purpose.
        /// Inspired by geekforgeeks: https://www.geeksforgeeks.org/program-to-replace-every-space-in-a-string-with-hyphen/
        /// </summary>
        /// <param name="str">The original string that is broken down to be edited.</param>
        /// <param name="purpose">A string that defines how the input string should be formatted.</param>
        /// <returns>The formatted string.</returns>
        private string formatDate(string str, string purpose)
        {
            string returString = "";
            string d = "";
            string m = "";
            string y = "";
            int numberOfPeriods = 0;

            // Separates the date, month and year
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
                // Format for normal viewing
                if (y.Equals("0001"))
                    returString = "Ikke satt";
                else
                    returString = d + "." + m + "." + y;
            }
            else if (purpose.Equals("input field"))
            {
                // Format for HTML input type="date"
                if (y.Equals("0001"))
                    returString = "";
                else
                    returString = y + "-" + m + "-" + d;
            }
            else
                returString = "";

            return returString;
        }

        public string formatDateForViewing(DateOnly date)
        {
            return formatDate(date.ToString(), "viewing");
        }

        public string formatDateForInputField(DateOnly date)
        {
            return formatDate(date.ToString(), "input field");
        }
    }
}