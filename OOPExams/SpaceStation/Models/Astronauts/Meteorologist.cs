using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Concrete
{
    public class Meteorologist : Astronaut
    {
        public Meteorologist(string name) 
            : base(name, 90)
        {

        }
    }
}
