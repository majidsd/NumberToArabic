using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
    class TafqeetEnglish
    {

        public TafqeetEnglish()
        {
        }


        /** The Constant units. */
        private static String[] units = { "Zero", "One", "Two", "Three",
            "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen" };

        /** The Constant tens. */
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
            "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        /**
	    * Convert.
	    *
	    * @param number the number
	    * @return the string
	    */
        private static String convert(Int32 number)
        {
            if (number < 20)
            {
                return units[number];
            }
            if (number < 100)
            {
                return tens[number / 10]
                        + ((number % 10 > 0) ? " " + convert(number % 10) : "");
            }
            if (number < 1000)
            {
                return units[number / 100]
                        + " Hundred"
                        + ((number % 100 > 0) ? " and " + convert(number % 100)
                                : "");
            }
            if (number < 1000000)
            {
                return convert(number / 1000) + " Thousand "
                        + ((number % 1000 > 0) ? " " + convert(number % 1000) : "");
            }
            return convert(number / 1000000)
                    + " Million "
                    + ((number % 1000000 > 0) ? " " + convert(number % 1000000)
                            : "");
        }


        /**
        * Convert number to english words.
        *
        * @param number the number
        * @return the string
        * @throws NumberFormatException the number format exception
        */
        public static String convertNumberToEnglishWords(String number)
        {
            Int32 i;
            bool check_number = Int32.TryParse(number, out i);

            if (check_number)
                return convert(i);
            else
                return "NOT_NUMBER";
        }

    }
}
