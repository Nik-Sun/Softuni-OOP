using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IEgg> eggRepository;
        private IRepository<IBunny> bunnyRepository;
        private int coloredEggs;
        public Controller()
        {
            eggRepository = new EggRepository();
            bunnyRepository = new BunnyRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            switch (bunnyType)
            {
                case "HappyBunny":
                    bunnyRepository.Add(new HappyBunny(bunnyName));
                    break;
                case "SleepyBunny":
                    bunnyRepository.Add(new SleepyBunny(bunnyName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            return string.Format(OutputMessages.BunnyAdded,bunnyType,bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny current = bunnyRepository.FindByName(bunnyName);
            if (current == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            current.AddDye(new Dye(power));
            return string.Format(OutputMessages.DyeAdded, power, current.Name);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            eggRepository.Add(new Egg(eggName, energyRequired));
            return string.Format(OutputMessages.EggAdded,eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg current = eggRepository.FindByName(eggName);
            List<IBunny> bunnies = new List<IBunny>();
            bunnies = bunnyRepository.Models.Where(b => b.Energy >= 50).OrderByDescending(b=>b.Energy).ToList();
            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            Workshop workshop = new Workshop();
            while (true)
            {
                IBunny bunny = bunnies.First();
                bunnies.Remove(bunny);
                workshop.Color(current, bunny);
                if (bunny.Energy==0)
                {
                    bunnyRepository.Remove(bunny);
                }
                if (current.IsDone())
                {
                    coloredEggs++;
                    break;
                }
                else if (bunnies.Count == 0)
                {
                    break;
                }
                
            }
            return current.IsDone() ? string.Format(OutputMessages.EggIsDone, eggName)
                                    : string.Format(OutputMessages.EggIsNotDone, eggName);
           
        }

        public string Report()
        {
            return $"{coloredEggs} eggs are done!\r\nBunnies info:\r\n{string.Join("\r\n",bunnyRepository.Models)}";
        }
    }
}
