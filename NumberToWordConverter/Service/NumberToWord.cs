

using System.Linq;

namespace NumberToWords
{
    public static class NumberToWords
    {
        static string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        static string[] thousandsGroups = { "", " Thousand", " Million", " Billion" };

        private static string BeforeDecimalNumber(int n, string leftDigits, int thousands)
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

        private static string AfterDecimalNumber(int n)
        {
            string divident = n.ToString();
            string divisor = "1";
            for (int i = 0; i < divident.Length; i++) divisor = divisor + "0";
            return $" and {divident}/{divisor}";
        }

        public static string NonDecimalNumber(int n)
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



        public static string NumberWithDecimal(string n)
        {
            string[] parts = n.Split('.'); 
            int i1 = int.Parse(parts[0]);
            int i2 = int.Parse(parts[1]);

            return $"{NonDecimalNumber(i1)} {AfterDecimalNumber(i2)}" ;
        } 
    }
}
