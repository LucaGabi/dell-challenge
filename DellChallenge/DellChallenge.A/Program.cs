using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            new B();
            Console.ReadKey();

            //when B class instance is created the base class A constructor is called so: "A.A()", 
            //then B class constructor is called so: "B.B()" from Console.WriteLine then "A .Age" from the 
            //assignement property setter of Age 
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A .Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
