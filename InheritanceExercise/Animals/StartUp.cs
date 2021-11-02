using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (input != "Beast!")
            {
                string animalType = input;
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal = null;

                switch (animalType)
                {

                    case "Cat":
                        animal = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        break;
                    case "Dog":
                        animal = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        break;
                    case "Frog":
                        animal = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        break;
                    case "Kitten":
                        animal = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                        break;
                    case "Tomcat":
                        animal = new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
                        break;
                    default:
                       
                        break;
                }
                animals.Add(animal);
                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }


        }

    }
}

