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
            {
                speciesType.GetSpecies();
                speciesType.ActAll();
            }

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
            Console.WriteLine($"I'm  {action}ing");
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

    public class FlyHumanSpeciesAction : FlySpeciesAction
    {
        public FlyHumanSpeciesAction()
        {
        }

        public override void Do()
        {
            Console.WriteLine("Take a tiket, catch the plain and then ");
            base.Do();
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

        public Species(string name, List<ISpeciesAction> speciesActions=default)
        {
            this.name = name;
            if (speciesActions?.Count>0)
                this.speciesActions = speciesActions;
        }

        public virtual void GetSpecies()
        {
            Console.WriteLine($"I'm a / an {name}!");
            var actionCSV = string.Join(", ", speciesActions.Select(x => x.GetActionName()));
            Console.WriteLine($"I can: {actionCSV}");
        }

        protected void AddPosibleAction(ISpeciesAction action)
        {
            speciesActions.Add(action);
        }

        public virtual void Act(ISpeciesAction action)
        {
            action.Do();
        }

        public virtual void ActAll()
        {
            foreach (var action in speciesActions)
                Act(action);
        }
    }

    public class Human : Species
    {
        public Human() : base("Human")
        {
            AddPosibleAction(new DrinkSpeciesAction());
            AddPosibleAction(new EatSpeciesAction());
            AddPosibleAction(new FlyHumanSpeciesAction());
            AddPosibleAction(new SwimSpeciesAction());
        } 
    }

    public class Bird : Species
    {
        public Bird() : base("Bird")
        {
            AddPosibleAction(new DrinkSpeciesAction());
            AddPosibleAction(new EatSpeciesAction());
            AddPosibleAction(new FlySpeciesAction());
        }
    }

    public class Fish : Species
    {
        public Fish() : base("Fish")
        {
            AddPosibleAction(new DrinkSpeciesAction());
            AddPosibleAction(new EatSpeciesAction());
            AddPosibleAction(new SwimSpeciesAction());
        }
    }

}

