using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords
{
    public static class Extension
    {
        public static string ToWordFormat(this object input)
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

                //decimal format
                case float r:
                    convertedString = NumberToWords.NumberWithDecimal(r.ToString());
                    break;

                case double r:
                     convertedString = NumberToWords.NumberWithDecimal(r.ToString()); 
                    break;

                case decimal r:
                    convertedString = NumberToWords.NumberWithDecimal(r.ToString());
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
