using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Concrete
{
    public class Biologist : Astronaut
    {
        public Biologist(string name)
            : base(name, 70)
        {
           
        }
        public override void Breath()
        {
            if (CanBreath)
            {
                Oxygen -= 5;
            }
        }
    }
}
