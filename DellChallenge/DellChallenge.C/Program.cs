using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            computeSum();
            Console.ReadKey();
        }

        private static void computeSum()
        {
            SumServiceProvider sumService = new SumServiceProvider();
            int sumSimple = sumService.Add(1, 3);
            int sumExtended = sumService.AddExtended(1, 3, 5);
            Console.WriteLine(sumSimple);
            Console.WriteLine(sumExtended);
        }
    }

    
}
