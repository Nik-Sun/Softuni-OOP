using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IRepository<ICar> carsRepository = new CarRepository();
        private IRepository<IRacer> racerRepository = new RacerRepository();

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar current = null;
            switch (type)
            {
                case "SuperCar":
                    current = new SuperCar(make,model,VIN,horsePower);
                    break;
                case "TunedCar":
                    current = new TunedCar(make,model,VIN,horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
                    
            }
            carsRepository.Add(current);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer current = null;
            ICar car = carsRepository.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            

            switch (type)
            {
                case "ProfessionalRacer":
                    current = new ProfessionalRacer(username,car);
                    break;
                case "StreetRacer":
                    current = new StreetRacer(username, car);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);     
            }
            racerRepository.Add(current);
            return string.Format(OutputMessages.SuccessfullyAddedRacer,username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racerRepository.FindBy(racerOneUsername);
            IRacer racerTwo = racerRepository.FindBy(racerTwoUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound,racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            IMap map = new Map();
            return map.StartRace(racerOne,racerTwo);
        }

        public string Report()
        {
            return string.Join("\r\n", racerRepository.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username));
        }
    }
}
