using SpaceStation.Concrete;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private int exploredPlanets;
        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            switch (type)
            {
                case "Biologist":
                    astronautRepository.Add(new Biologist(astronautName));
                    break;
                case "Geodesist":
                    astronautRepository.Add(new Geodesist(astronautName));
                    break;
                case "Meteorologist":
                    astronautRepository.Add(new Meteorologist(astronautName));
                    break;
               
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
                 
            }
            return string.Format(OutputMessages.AstronautAdded, type,astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded,planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> explorers = new List<IAstronaut>();
            foreach (var astronaut in astronautRepository.Models)
            {
                if (astronaut.Oxygen >= 60)
                {
                    explorers.Add(astronaut);
                }
            }

            if (explorers.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            var mission = new Mission();
            var currentPlanet = planetRepository.FindByName(planetName);
            mission.Explore(currentPlanet, explorers);
            exploredPlanets++;
            return string.Format(OutputMessages.PlanetExplored,planetName,explorers.Where(e=>e.CanBreath == false).Count());
        }

        public string Report()
        {
            return $"{exploredPlanets} planets were explored!{Environment.NewLine}Astronauts info:{Environment.NewLine}{string.Join("\r\n",astronautRepository.Models)}";
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut current = astronautRepository.FindByName(astronautName);
            if (astronautRepository.Remove(current))
            {
                return string.Format(OutputMessages.AstronautRetired,astronautName);
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,astronautName));
        }
    }
}
