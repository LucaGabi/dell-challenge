using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();

    }

    public interface IFlySpecies : ISpecies
    {
        void Fly();
    }

    public interface ISwimSpecies : ISpecies
    {
        void Swim();
    }


    public abstract class Species : ISpecies
    {
        private readonly string name = "Unknown";

        public Species(string name)
        {
            this.name = name;
        }

        public abstract void Drink();
        public abstract void Eat();

        public virtual void GetSpecies()
        {
            Console.WriteLine($"I'm a / an {name}!");
        }
    }

    public class Human : Species, IFlySpecies, ISwimSpecies
    {
        public Human(string name) : base("Human")
        {
        }

        public override void Drink()
        {
            throw new NotImplementedException();
        }

        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            //by plain :)
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    public class Bird : Species, IFlySpecies
    {
        public Bird() : base("Bird")
        {
        }

        public override void Drink()
        {
            throw new NotImplementedException();
        }

        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }

    public class Fish : Species, ISwimSpecies
    {
        public Fish(string name) : base("Fish")
        {
        }

        public override void Drink()
        {
            throw new NotImplementedException();
        }

        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
}

