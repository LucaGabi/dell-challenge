using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallenge.C
{
    public class SumService
    {

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int AddExtended(int a, int b, int c)
        {
            return Add(a, b) + c;
        }
    }
}
