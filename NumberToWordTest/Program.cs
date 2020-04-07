using NumberToWords;
using System;

namespace NumberToWordTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = -40.5087878;
            var result = a.ToWordFormat(3);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
