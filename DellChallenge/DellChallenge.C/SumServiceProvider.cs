using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallenge.C
{
    public class SumServiceProvider
    {

        public int Do(int a, int b)
        {
            return a + b;
        }

        public int DoExtended(int a, int b, int c)
        {
            return Do(a, b) + c;
        }
    }
}
