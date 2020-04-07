

using System;
using System.Linq;

namespace NumberToWords
{
    public static class NumberToWords
    {
        static string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        static string[] thousandsGroups = { "", " Thousand", " Million", " Billion", " Trillion", " Quadrillion", " Quintillion", " Sextillion" };

        private static string BeforeDecimalNumber(long n, string leftDigits, int thousands)
        {
            if (n == 0)
            {
                return leftDigits;
            }

            string friendlyInt = leftDigits;

            if (friendlyInt.Length > 0)
            {
                friendlyInt += " ";
            }

            if (n < 10)
            {
                friendlyInt += ones[n];
            }
            else if (n < 20)
            {
                friendlyInt += teens[n - 10];
            }
            else if (n < 100)
            {
                friendlyInt += BeforeDecimalNumber(n % 10, tens[n / 10 - 2], 0);
            }
            else if (n < 1000)
            {
                friendlyInt += BeforeDecimalNumber(n % 100, (ones[n / 100] + " Hundred"), 0);
            }
            else
            {
                friendlyInt += BeforeDecimalNumber(n % 1000, BeforeDecimalNumber(n / 1000, "", thousands + 1), 0);
                if (n % 1000 == 0)
                {
                    return friendlyInt;
                }
            }

            return friendlyInt + thousandsGroups[thousands];
        }

        private static string AfterDecimalNumber(long n, int decimalPrecision)
        {
            if (decimalPrecision == 0) return "";
            string divident = n.ToString();
            if (decimalPrecision > -1)
            {
                divident = divident.Substring(0, decimalPrecision);
            }
            string divisor = "1";
            for (int i = 0; i < divident.Length; i++) divisor = divisor + "0";
            return $" and {divident}/{divisor}";
        }

        public static string NonDecimalNumber(long n)
        {
            if (n == 0)
            {
                return "Zero";
            }
            else if (n < 0)
            {
                return "Negative " + NonDecimalNumber(-n);
            }

            return BeforeDecimalNumber(n, "", 0);
        }



        public static string NumberWithDecimal(object n, int decimalPrecision = -1)
        {
            var number = ((double)n).ToString("F99").TrimEnd('0');
            string[] parts = number.Split('.');
            long i1 = long.Parse(parts[0]);
            var a = parts.Length == 2 && !string.IsNullOrEmpty(parts[1]) ? parts[1] : "0";
            long i2 = long.Parse(a);

            return $"{NonDecimalNumber(i1)} {AfterDecimalNumber(i2, decimalPrecision)}";
        }

        private static int GetPricision(double number)
        { 
            var precision = 0;
            var x = Convert.ToDecimal(number);

            while (x * (decimal)Math.Pow(10, precision) !=
                     Math.Round(x * (decimal)Math.Pow(10, precision)))
                precision++;

            return precision;

        }

    }
}
