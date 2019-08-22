using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
    public class TafqeetArabic
    {
        /**
    	 * Instantiates a new tafqeet.
	    */
        public TafqeetArabic()
        {
        }


        /**
	     * Convert one digits.
	    *
	    * @param oneDigit the one digit
	    * @return the string
	    */
        public static String convertOneDigits(String oneDigit)
        {

            Int32 i;
            bool check_number = Int32.TryParse(oneDigit, out i);

            if (check_number)
            {
                switch (i)
                {
                    case 1:
                        return "واحد";
                    case 2:
                        return "إثنان";
                    case 3:
                        return "ثلاث";
                    case 4:
                        return "أربع";
                    case 5:
                        return "خمس";
                    case 6:
                        return "ست";
                    case 7:
                        return "سبع";
                    case 8:
                        return "ثمان";
                    case 9:
                        return "تسع";
                    default:
                        return "";
                }
            }
            else
            {
                return "ليس رقم او اعلي من تسعة";
            }
        }


        /**
	    * Convert two digits.
	    *
	    * @param twoDigits the two digits
	    * @return the string
	    */
        private static String convertTwoDigits(String twoDigits)
        {
            String returnAlpha = "00";
            // check if the first digit is 0 like 0x
            try
            {
                if (twoDigits[0] == '0' && twoDigits[1] != '0')
                { // yes
                  // convert two digits to one
                    return convertOneDigits(twoDigits[1].ToString());
                }
                else
                { // no
                  // check the first digit 1x 2x 3x 4x 5x 6x 7x 8x 9x
                    switch (getIntVal(twoDigits[0]))
                    {
                        case 1:
                            { // 1x
                                if (getIntVal(twoDigits[1]) == 1)
                                {
                                    return "إحدى عشر";
                                }
                                if (getIntVal(twoDigits[1]) == 2)
                                {
                                    return "إثنى عشر";
                                }
                                else
                                {
                                    return convertOneDigits(twoDigits[1].ToString()) + " " + "عشر";
                                }
                            }
                        case 2: // 2x x:not 0
                            returnAlpha = "عشرون";
                            break;
                        case 3: // 3x x:not 0
                            returnAlpha = "ثلاثون";
                            break;
                        case 4: // 4x x:not 0
                            returnAlpha = "أريعون";
                            break;
                        case 5: // 5x x:not 0
                            returnAlpha = "خمسون";
                            break;
                        case 6: // 6x x:not 0
                            returnAlpha = "ستون";
                            break;
                        case 7: // 7x x:not 0
                            returnAlpha = "سبعون";
                            break;
                        case 8: // 8x x:not 0
                            returnAlpha = "ثمانون";
                            break;
                        case 9: // 9x x:not 0
                            returnAlpha = "تسعون";
                            break;
                        default:
                            returnAlpha = "";
                            break;
                    }
                }

                // 20 - 99
                // x0 x:not 0,1
                if (convertOneDigits(twoDigits[1].ToString()).Length == 0)
                {
                    return returnAlpha;
                }
                else
                { // xx x:not 0
                    return convertOneDigits(twoDigits[1].ToString())
                            + " و " + returnAlpha;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        /**
         * Convert three digits.
         *
         * @param threeDigits the three digits
         * @return the string
         */
        public static String convertThreeDigits(String threeDigits)
        {

            // check the first digit x00
            switch (getIntVal(threeDigits[0]))
            {

                case 1:
                    { // 100 - 199
                        if (getIntVal(threeDigits[1]) == 0)
                        { // 10x
                            if (getIntVal(threeDigits[2]) == 0)
                            { // 100
                                return "مائه";
                            }
                            else
                            { // 10x x: is not 0
                                return "مائه"
                                        + " و "
                                        + convertOneDigits(threeDigits[2].ToString());
                            }
                        }
                        else
                        {// 1xx x: is not 0
                            return "مائه" + " و "
                                    + convertTwoDigits(threeDigits.Substring(1, 2));
                        }
                    }
                case 2:
                    { // 200 - 299
                        if (getIntVal(threeDigits[1]) == 0)
                        { // 20x
                            if (getIntVal(threeDigits[2]) == 0)
                            { // 200
                                return "مائتين";
                            }
                            else
                            { // 20x x:not 0
                                return "مائتين"
                                        + " و "
                                        + convertOneDigits(threeDigits[2].ToString());
                            }
                        }
                        else
                        { // 2xx x:not 0
                            return "مائتين" + " و "
                                    + convertTwoDigits(threeDigits.Substring(1, 2));
                        }
                    }
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    { // 300 - 999
                        if (getIntVal(threeDigits[1]) == 0)
                        { // x0x x:not 0
                            if (getIntVal(threeDigits[2]) == 0)
                            { // x00 x:not 0
                                return convertOneDigits(threeDigits[0].ToString()) + "مائه";
                            }
                            else
                            { // x0x x:not 0
                                return convertOneDigits(threeDigits[0].ToString())
                                        + "مائه"
                                        + " و "
                                        + convertOneDigits(threeDigits[2].ToString());
                            }
                        }
                        else
                        { // xxx x:not 0
                            return convertOneDigits(threeDigits[0].ToString())
                                    + "مائه" + " و "
                                    + convertTwoDigits(threeDigits.Substring(1, 2));
                        }
                    }

                case 0:
                    { // 000 - 099
                        if (threeDigits[1] == '0')
                        { // 00x
                            if (threeDigits[2] == '0')
                            { // 000
                                return "";
                            }
                            else
                            { // 00x x:not 0
                                return convertOneDigits(threeDigits[2].ToString());
                            }
                        }
                        else
                        { // 0xx x:not 0
                            return convertTwoDigits(threeDigits.Substring(1, 2));
                        }
                    }
                default:
                    return "";
            }
        }

        /**
         * Convert four digits.
         *
         * @param fourDigits the four digits
         * @return the string
         */
        private static String convertFourDigits(String fourDigits)
        {
            // xxxx
            switch (getIntVal(fourDigits[0]))
            {

                case 1:
                    { // 1000 - 1999
                        if (getIntVal(fourDigits[1]) == 0)
                        { // 10xx x:not 0
                            if (getIntVal(fourDigits[2]) == 0)
                            { // 100x x:not 0
                                if (getIntVal(fourDigits[3]) == 0)
                                { // 1000
                                    return "ألف";
                                }
                                else
                                { // 100x x:not 0
                                    return "ألف"
                                            + " و "
                                            + convertOneDigits(fourDigits[3].ToString());
                                }
                            }
                            else
                            { // 10xx x:not 0
                                return "ألف" + " و "
                                        + convertTwoDigits(fourDigits.Substring(2, 2));
                            }
                        }
                        else
                        { // 1xxx x:not 0
                            return "ألف" + " و "
                                    + convertThreeDigits(fourDigits.Substring(1, 3));
                        }
                    }
                case 2:
                    { // 2000 - 2999

                        if (getIntVal(fourDigits[1]) == 0)
                        { // 20xx
                            if (getIntVal(fourDigits[2]) == 0)
                            { // 200x
                                if (getIntVal(fourDigits[3]) == 0)
                                { // 2000
                                    return "ألفين";
                                }
                                else
                                { // 200x x:not 0
                                    return "ألفين"
                                            + " و "
                                            + convertOneDigits(fourDigits[3].ToString());
                                }
                            }
                            else
                            { // 20xx x:not 0
                                return "ألفين" + " و "
                                        + convertTwoDigits(fourDigits.Substring(2, 2));
                            }
                        }
                        else
                        { // 2xxx x:not 0
                            return "ألفين" + " و "
                                    + convertThreeDigits(fourDigits.Substring(1, 3));
                        }
                    }
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    { // 3000 - 9999
                        if (getIntVal(fourDigits[1]) == 0)
                        { // x0xx x:not 0
                            if (getIntVal(fourDigits[2]) == 0)
                            { // x00x x:not 0
                                if (getIntVal(fourDigits[3]) == 0)
                                { // x000 x:not 0
                                    return convertOneDigits(fourDigits[0].ToString()) + " ألاف";
                                }
                                else
                                { // x00x x:not 0
                                    return convertOneDigits(fourDigits[0].ToString())
                                            + " ألاف"
                                            + " و "
                                            + convertOneDigits(fourDigits[3].ToString());
                                }
                            }
                            else
                            { // x0xx x:not 0
                                return convertOneDigits(fourDigits[0].ToString())
                                        + " ألاف"
                                        + " و "
                                        + convertTwoDigits(fourDigits.Substring(2, 2));
                            }
                        }
                        else
                        { // xxxx x:not 0
                            return convertOneDigits(fourDigits[0].ToString())
                                    + " ألاف" + " و "
                                    + convertThreeDigits(fourDigits.Substring(1, 3));
                        }
                    }

                default:
                    return "";
            }
        }

        /**
         * Convert five digits.
         *
         * @param fiveDigits the five digits
         * @return the string
         */
        private static String convertFiveDigits(String fiveDigits)
        {
            if (convertThreeDigits(fiveDigits.Substring(2, 3)).Length == 0)
            { // xx000
              // x:not															// 0
                return convertTwoDigits(fiveDigits.Substring(0, 2)) + " ألف ";
            }
            else
            { // xxxxx x:not 0
                return convertTwoDigits(fiveDigits.Substring(0, 2)) + " ألفا "
                        + " و " + convertThreeDigits(fiveDigits.Substring(2, 3));
            }
        }

        /**
         * Convert six digits.
         *
         * @param sixDigits the six digits
         * @return the string
         */
        private static String convertSixDigits(String sixDigits)
        {
            if (convertThreeDigits(sixDigits.Substring(3, 3)).Length == 0)
            { // xxx000
              // x:not
                return convertThreeDigits(sixDigits.Substring(0, 3)) + " ألف ";
            }
            else
            { // xxxxxx x:not 0
                return convertThreeDigits(sixDigits.Substring(0, 3)) + " ألفا "
                        + " و " + convertThreeDigits(sixDigits.Substring(3, 3));
            }
        }

        /**
         * Convert seven digits.
         *
         * @param sevenDigits the seven digits
         * @return the string
         */
        private static String convertSevenDigits(String sevenDigits)
        {

            if (getIntVal(sevenDigits[0]) == 0)
            {
                return convertSixDigits(sevenDigits.Substring(1, 7));
            }
            else if (getIntVal(sevenDigits[0]) == 1)
            {
                if (sevenDigits.Substring(1, 6).Equals("000000"))
                {
                    return " مليون";
                }
                else if (sevenDigits.Substring(1, 5).Equals("00000"))
                {
                    return " مليون و" + convertOneDigits(sevenDigits.Substring(6, 7));
                }
                else if (sevenDigits.Substring(1, 4).Equals("0000"))
                {
                    return " مليون و" + convertTwoDigits(sevenDigits.Substring(5, 7));
                }
                else if (sevenDigits.Substring(1, 3).Equals("000"))
                {
                    return " مليون و" + convertThreeDigits(sevenDigits.Substring(4, 7));
                }
                else if (sevenDigits.Substring(1, 2).Equals("00"))
                {
                    return " مليون و" + convertFourDigits(sevenDigits.Substring(3, 7));
                }
                else if (sevenDigits.Substring(1, 1).Equals("0"))
                {
                    return " مليون و" + convertFiveDigits(sevenDigits.Substring(2, 7));
                }
                else
                {
                    return " مليون و"
                            + convertSixDigits(sevenDigits.Substring(1, 6));
                }
            }
            else if (getIntVal(sevenDigits[0]) == 2)
            {
                if (sevenDigits.Substring(1, 6).Equals("000000"))
                {
                    return " مليونين ";
                }
                else if (sevenDigits.Substring(1, 5).Equals("00000"))
                {
                    return " مليونين و" + convertOneDigits(sevenDigits.Substring(6, 1));
                }
                else if (sevenDigits.Substring(1, 4).Equals("0000"))
                {
                    return " مليونين و" + convertTwoDigits(sevenDigits.Substring(5, 2));
                }
                else if (sevenDigits.Substring(1, 3).Equals("000"))
                {
                    return " مليونين و" + convertThreeDigits(sevenDigits.Substring(4, 3));
                }
                else if (sevenDigits.Substring(1, 2).Equals("00"))
                {
                    return " مليونين و" + convertFourDigits(sevenDigits.Substring(3, 4));
                }
                else if (sevenDigits.Substring(1, 1).Equals("0"))
                {
                    return " مليونين و" + convertFiveDigits(sevenDigits.Substring(2, 5));
                }
                else
                {
                    return " مليونين و"
                            + convertSixDigits(sevenDigits.Substring(1, 6));
                }
            }
            else
            {
                if (sevenDigits.Substring(1, 6).Equals("000000"))
                {
                    return convertOneDigits(sevenDigits.Substring(0, 1)) + " مليون ";
                }
                else if (sevenDigits.Substring(1, 5).Equals("00000"))
                {
                    return convertOneDigits(sevenDigits.Substring(0, 1)) + " مليون و " + convertOneDigits(sevenDigits.Substring(6, 1));
                }
                else if (sevenDigits.Substring(1, 4).Equals("0000"))
                {
                    return convertOneDigits(sevenDigits.Substring(0, 1)) + " مليون و " + convertTwoDigits(sevenDigits.Substring(5, 2));
                }
                else if (sevenDigits.Substring(1, 3).Equals("000"))
                {
                    return convertOneDigits(sevenDigits.Substring(0, 1)) + " مليون و " + convertThreeDigits(sevenDigits.Substring(4, 3));
                }
                else if (sevenDigits.Substring(1, 2).Equals("00"))
                {
                    return convertOneDigits(sevenDigits.Substring(0, 1)) + " مليون و " + convertFourDigits(sevenDigits.Substring(3, 4));
                }
                else if (sevenDigits.Substring(1, 1).Equals("0"))
                {
                    return convertOneDigits(sevenDigits.Substring(0, 1)) + " مليون و " + convertFiveDigits(sevenDigits.Substring(2, 5));
                }
                else
                {
                    return convertOneDigits(sevenDigits.Substring(0, 1)) + " مليون و "
                            + convertSixDigits(sevenDigits.Substring(1, 6));
                }
            }
        }

        /**
         * Convert eight digits.
         *
         * @param eightDigits the eight digits
         * @return the string
         */
        private static String convertEightDigits(String eightDigits)
        {

            if (getIntVal(eightDigits[0]) == 0)
            {
                return convertSevenDigits(eightDigits.Substring(1, 7));
            }
            else
            {
                if (eightDigits.Substring(2, 6).Equals("000000"))
                {
                    return convertTwoDigits(eightDigits.Substring(0, 2)) + " مليون ";
                }
                else if (eightDigits.Substring(2, 5).Equals("00000"))
                {
                    return convertTwoDigits(eightDigits.Substring(0, 2)) + " مليون و " + convertOneDigits(eightDigits.Substring(7, 1));
                }
                else if (eightDigits.Substring(2, 4).Equals("0000"))
                {
                    return convertTwoDigits(eightDigits.Substring(0, 2)) + " مليون و " + convertTwoDigits(eightDigits.Substring(6, 2));
                }
                else if (eightDigits.Substring(2, 3).Equals("000"))
                {
                    return convertTwoDigits(eightDigits.Substring(0, 2)) + " مليون و " + convertThreeDigits(eightDigits.Substring(5, 3));
                }
                else if (eightDigits.Substring(2, 2).Equals("00"))
                {
                    return convertTwoDigits(eightDigits.Substring(0, 2)) + " مليون و " + convertFourDigits(eightDigits.Substring(4, 4));
                }
                else if (eightDigits.Substring(2, 1).Equals("0"))
                {
                    return convertTwoDigits(eightDigits.Substring(0, 2)) + " مليون و " + convertFiveDigits(eightDigits.Substring(3, 5));
                }
                else
                {
                    return convertTwoDigits(eightDigits.Substring(0, 2)) + " مليون و " + convertSixDigits(eightDigits.Substring(2, 6));

                }
            }

        }

        /**
         * Convert nine digits.
         *
         * @param nineDigits the nine digits
         * @return the string
         */
        private static String convertNineDigits(String nineDigits)
        {

            if (getIntVal(nineDigits[0]) == 0)
            {
                return convertEightDigits(nineDigits.Substring(1, 8));
            }
            else
            {
                if (nineDigits.Substring(3, 6).Equals("000000"))
                {
                    return convertThreeDigits(nineDigits.Substring(0, 3)) + " مليون ";
                }
                else if (nineDigits.Substring(3, 5).Equals("00000"))
                {
                    return convertThreeDigits(nineDigits.Substring(0, 3)) + " مليون و " + convertOneDigits(nineDigits.Substring(8, 1));
                }
                else if (nineDigits.Substring(3, 4).Equals("0000"))
                {
                    return convertThreeDigits(nineDigits.Substring(0, 3)) + " مليون و " + convertTwoDigits(nineDigits.Substring(7, 2));
                }
                else if (nineDigits.Substring(3, 3).Equals("000"))
                {
                    return convertThreeDigits(nineDigits.Substring(0, 3)) + " مليون و " + convertThreeDigits(nineDigits.Substring(6, 3));
                }
                else if (nineDigits.Substring(3, 2).Equals("00"))
                {
                    return convertThreeDigits(nineDigits.Substring(0, 3)) + " مليون و " + convertFourDigits(nineDigits.Substring(5, 4));
                }
                else if (nineDigits.Substring(3, 1).Equals("0"))
                {
                    return convertThreeDigits(nineDigits.Substring(0, 3)) + " مليون و " + convertFiveDigits(nineDigits.Substring(4, 5));
                }
                else
                {
                    return convertThreeDigits(nineDigits.Substring(0, 3)) + " مليون و " + convertSixDigits(nineDigits.Substring(3, 6));

                }
            }

        }

        /**
         * Convert ten digits.
         *
         * @param tenDigits the ten digits
         * @return the string
         */
        private static String convertTenDigits(String tenDigits)
        { // but edited by new functions

            // Note: The first block of comment is the original code
            /*if (getIntVal(tenDigits.charAt(0)) == 0) {
                return convertNineDigits(tenDigits.Substring(1, 10));
            } else {
                return convertOneDigits(tenDigits.Substring(0, 1))+ " مليار و " + convertNineDigits(tenDigits.Substring(1, 10));
            }*/



            if (tenDigits[0] == 0)
            { // check if it 0xxxxxxxxx then it's nine digits
                return convertNineDigits(tenDigits.Substring(1, 9));
            }
            else
            {

                //String numbers = (String) tenDigits.SubSequence(0, 1); // for Billion from 1-9
                String numbers = (String)tenDigits.Substring(0, 1); // for Billion from 1-9

                if (tenDigits.Substring(1, 9).Equals("000000000"))
                { // if it Billion then print it and exit
                    if (numbers.Equals("1"))
                    {
                        return " مليار ";
                    }
                    else
                    {
                        return convertOneDigits(numbers) + " مليار ";
                    }
                }
                else
                { // if it more than Billion the print the Billion and go to new function the print the reminder
                    String num = tenDigits.Substring(1, 9);
                    for (;;)
                    {
                        if (num[0] == '0')
                        {
                            num = num.Substring(1, num.Length);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (num.Length == 1)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertOneDigits(num); // newConvertNineDigits is the new function
                    }
                    else if (num.Length == 2)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertTwoDigits(num); // newConvertNineDigits is the new function
                    }
                    else if (num.Length == 3)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertThreeDigits(num); // newConvertNineDigits is the new function
                    }
                    else if (num.Length == 4)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertFourDigits(num); // newConvertNineDigits is the new function
                    }
                    else if (num.Length == 5)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertFiveDigits(num); // newConvertNineDigits is the new function
                    }
                    else if (num.Length == 6)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertSixDigits(num); // newConvertNineDigits is the new function
                    }
                    else if (num.Length == 7)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertSevenDigits(num); // newConvertNineDigits is the new function
                    }
                    else if (num.Length == 8)
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertEightDigits(num); // newConvertNineDigits is the new function
                    }
                    else
                    {
                        return convertOneDigits(numbers) + " مليار و " + convertNineDigits(num); // newConvertNineDigits is the new function
                    }

                }
            }
        }

        private static String newConvertNineDigits(String number)
        {

            if (number.Substring(4, 6).Equals("000000")) // check if it contains a million the print it with range (1-999) and end
                return convertThreeDigits(number.Substring(1, 3)) + " مليون و ";
            else if (number.Substring(7, 3).Equals("000"))
            { // check if it contains a thousand the print it with range (1-999) and with million in range (1-999)
                return convertThreeDigits(number.Substring(1, 3)) + " مليون و " + convertThreeDigits(number.Substring(4, 3));
            }
            else
            {
                if (number.Substring(4, 3).EndsWith("000"))
                { // this for case x000000xxx
                    return convertThreeDigits(number.Substring(1, 3)) + " مليون و " + convertThreeDigits(number.Substring(4, 3)) + " " +
                            convertThreeDigits(number.Substring(7, 10));
                }
                else
                { // this for last case xxxxxxxxxx
                    return convertThreeDigits(number.Substring(1, 3)) + " مليون و " + convertThreeDigits(number.Substring(4, 3)) + " الف و " +
                            convertThreeDigits(number.Substring(7, 3));
                }
            }

        }

        /**
         * Gets the int val.
         *
         * @param c the c
         * @return the int val
         */
        private static int getIntVal(char c)
        {
            return Int32.Parse(c.ToString());
        }

        /**
	     * Convert number to arabic words.
	    *
	    * @param number the number
	    * @param currencyName the currency name
	    * @param fractionName the fraction name
	    * @return the string
	    * @throws NumberFormatException the number format exception
	    */
        public static String convertNumberToArabicWords(String number,
                String currencyName, String fractionName)
        {
            bool testNumber = false;
            double num = 0.0;
            // check if the input string is number or not
            //Double.Parse(number);
            testNumber = double.TryParse(number, out num);

            if (!testNumber)
            {
                return "NOT_NUMBER";
            }

		    // check if its floating point number or not
		    if (number.Contains(".")) { // yes
                                    // the number
                String theNumber = number.Substring(0, number.IndexOf('.'));
                // the floating point number
                String theFloat = number.Substring(number.IndexOf('.') + 1);
                // check how many digits in the number 1:x 2:xx 3:xxx 4:xxxx 5:xxxxx
                // 6:xxxxxx		
                switch (theNumber.Length)
                {
                    case 1:
                        String numberConverted = "";
                        // This is to solve single digit number
                        if (convertOneDigits(theNumber).Length != 0)
                            numberConverted = convertOneDigits(theNumber) + " " + currencyName + " و ";
                        switch (theFloat.Length)
                        {
                            case 1:
                                return numberConverted + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return numberConverted + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return numberConverted + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return numberConverted + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return numberConverted + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return numberConverted + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return numberConverted + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return numberConverted + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return numberConverted + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return numberConverted + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 2:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertTwoDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 3:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertThreeDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 4:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertFourDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 5:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertFiveDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 6:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertSixDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 7:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertSevenDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 8:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertEightDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 9:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertNineDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    case 10:
                        switch (theFloat.Length)
                        {
                            case 1:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertOneDigits(theFloat) + " "
                                        + fractionName + "";
                            case 2:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertTwoDigits(theFloat) + " "
                                        + fractionName + "";
                            case 3:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertThreeDigits(theFloat) + " "
                                        + fractionName + "";
                            case 4:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertFourDigits(theFloat) + " "
                                        + fractionName + "";
                            case 5:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertFiveDigits(theFloat) + " "
                                        + fractionName + "";
                            case 6:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertSixDigits(theFloat) + " "
                                        + fractionName + "";
                            case 7:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertSevenDigits(theFloat) + " "
                                        + fractionName + "";
                            case 8:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertEightDigits(theFloat) + " "
                                        + fractionName + "";
                            case 9:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertNineDigits(theFloat) + " "
                                        + fractionName + "";
                            case 10:
                                return convertTenDigits(theNumber) + " " + currencyName
                                        + " و " + convertTenDigits(theFloat) + " "
                                        + fractionName + "";
                        }
                        return "";
                    default:
                        return "";
                    }
                }
		    else {
                switch (number.Length)
                {
                    case 1:
                        return convertOneDigits(number) + " " + currencyName;
                    case 2:
                        return convertTwoDigits(number) + " " + currencyName;
                    case 3:
                        return convertThreeDigits(number) + " " + currencyName;
                    case 4:
                        return convertFourDigits(number) + " " + currencyName;
                    case 5:
                        return convertFiveDigits(number) + " " + currencyName;
                    case 6:
                        return convertSixDigits(number) + " " + currencyName;
                    case 7:
                        return convertSevenDigits(number) + " " + currencyName;
                    case 8:
                        return convertEightDigits(number) + " " + currencyName;
                    case 9:
                        return convertNineDigits(number) + " " + currencyName;
                    case 10:
                        return convertTenDigits(number) + " " + currencyName;
                    default:
                        return "";
                }

            }
        }


    }
    
}
