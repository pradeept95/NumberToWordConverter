using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords
{
    public static class Extension
    {
        /// <summary>
        /// Converts the given number to the corrosponding word in the valid range
        /// </summary>
        /// <param name="input">number need to be converted</param>
        /// <param name="decimalPrecision">Decimal pricision of the returned result. It should be -1 to ignore the pricision level change</param>
        /// <returns></returns>
        public static string ToWordFormat(this object input, int decimalPrecision = -1)
        {
            var convertedString = "";
            if (string.IsNullOrEmpty(input.ToString()))
            {
                throw new ArgumentNullException($"parameter can't be empty or null");
            } 

            switch (input) //switch on anything
            {
                // non decimal format
                case int r: 
                    convertedString = NumberToWords.NonDecimalNumber(r);
                    break;  
                
                case long r: 
                    convertedString = NumberToWords.NonDecimalNumber(r);
                    break; 

                //decimal format
                case float r:
                    convertedString = NumberToWords.NumberWithDecimal(r, decimalPrecision);
                    break;

                case double r:
                     convertedString = NumberToWords.NumberWithDecimal(r, decimalPrecision); 
                    break;

                case decimal r:
                    convertedString = NumberToWords.NumberWithDecimal(r, decimalPrecision);
                    break;

                default:
                    convertedString = $"<Too Large Number> or <Unknown Format> or <Inuput { input } is not a Number>";
                    break;
            }
             

            return convertedString;
;
        }
    }
}
