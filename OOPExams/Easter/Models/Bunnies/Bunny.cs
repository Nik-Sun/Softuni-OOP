using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private readonly ICollection<IDye> dyes = new List<IDye>();
        private string name;
        private int energy;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }

        public int Energy
        {
            get => energy;
            protected set
            {
                energy = value;
                if (energy < 0)
                {
                    energy = 0;
                }
            }
        }

        public ICollection<IDye> Dyes => dyes;
        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public virtual void Work()
        {
            Energy -= 10;
            Dyes.First().Use();
            if (Dyes.First().IsFinished())
            {
                Dyes.Remove(Dyes.First());
            }
        }
        public override string ToString()
        {
            return $"Name: { Name}\r\nEnergy: {Energy}\r\nDyes: {Dyes.Count} not finished";
        }
    }
}
