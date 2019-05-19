using System;
using System.Collections.Generic;
using System.Linq;

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
                speciesType.GetSpecies();

            Console.ReadKey();
        }
    }

    public interface ISpeciesAction
    {
        void Do();
        string GetActionName();
    }

    public abstract class SpeciesAction : ISpeciesAction
    {
        private readonly string action;

        public SpeciesAction(string action)
        {
            this.action = action;
        }

        public virtual void Do()
        {
            Console.WriteLine(action);
        }

        public string GetActionName()
        {
            return action;
        }
    }

    public class DrinkSpeciesAction : SpeciesAction
    {
        public DrinkSpeciesAction() : base("Drink")
        {
        }
    }

    public class EatSpeciesAction : SpeciesAction
    {
        public EatSpeciesAction() : base("Eat")
        {
        }
    }

    public class FlySpeciesAction : SpeciesAction
    {
        public FlySpeciesAction() : base("Fly")
        {
        }
    }

    public class SwimSpeciesAction : SpeciesAction
    {
        public SwimSpeciesAction() : base("Swim")
        {
        }
    }

    public abstract class Species
    {
        private readonly string name;
        private List<ISpeciesAction> speciesActions = new List<ISpeciesAction>();

        public Species(string name, List<ISpeciesAction> speciesActions)
        {
            this.name = name;
            this.speciesActions = speciesActions;
        }

        public virtual void GetSpecies()
        {
            Console.WriteLine($"I'm a / an {name}!");
            var actionCSV = string.Join(", ", speciesActions.Select(x => x.GetActionName()));
            Console.WriteLine($"I can: {actionCSV}");
        }
    }

    public class Human : Species
    {
        public Human() :
            base("Human",
                new List<ISpeciesAction> {
                    new DrinkSpeciesAction(),
                    new EatSpeciesAction(),
                    new FlySpeciesAction(),
                    new SwimSpeciesAction(),
                })
        {
            // ctor body
        }
    }

    public class Bird : Species
    {
        public Bird() :
            base("Bird",
                new List<ISpeciesAction> {
                    new DrinkSpeciesAction(),
                    new EatSpeciesAction(),
                    new FlySpeciesAction(),
                })
        {
            // ctor body
        }
    }

    public class Fish : Species
    {
        public Fish() :
            base("Fish",
                new List<ISpeciesAction> {
                    new DrinkSpeciesAction(),
                    new EatSpeciesAction(),
                    new SwimSpeciesAction(),
                })
        {
            // ctor body
        }
    }

}

