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

            var species = new Species[] {
                new Human(),
                new Bird(),
                new Fish()
            };

            foreach (var speciesType in species)
            {
                speciesType.GetSpecies();
                Console.WriteLine("I can: ");
                speciesType.Eat();
                speciesType.Drink();
                (speciesType as IFlySpecies)?.Fly();
                (speciesType as ISwimSpecies)?.Swim();
            }

            Console.ReadKey();
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

        public virtual void Drink() {
            Console.WriteLine("Drink");
        }

        public virtual void Eat()
        {
            Console.WriteLine("Eat");
        }

        public virtual void GetSpecies()
        {
            Console.WriteLine($"I'm a / an {name}!");
        }
    }

    public class Human : Species, IFlySpecies, ISwimSpecies
    {
        public Human() : base("Human")
        {
        }

        public void Fly()
        {
            //by plain :)
            Console.WriteLine("Fly, not native though");
        }

        public void Swim()
        {
            Console.WriteLine("Swim");
        }
    }

    public class Bird : Species, IFlySpecies
    {
        public Bird() : base("Bird")
        {
        }

        public void Fly()
        {
            Console.WriteLine("Fly");
        }
    }

    public class Fish : Species, ISwimSpecies
    {
        public Fish() : base("Fish")
        {
        }

        public void Swim()
        {
            Console.WriteLine("Swim");
        }
    }
}

