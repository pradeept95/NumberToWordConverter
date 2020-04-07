using NumberToWords;
using System;

namespace NumberToWordTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = -323.99;
            var result = a.ToWordFormat();

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
