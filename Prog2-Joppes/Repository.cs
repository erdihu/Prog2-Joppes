using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Joppes
{
    /* 
     * Repository is where the data and its interaction methods stay. 
     * This is handy because when we want to connect the application to an external database, 
     * it will be the gate of our database communication. 
     * I.e: The repository will handle the business model of adding and removing the data by various database APIs.
     * If we for example add an Entity Framework to this project, database context methods will be responsible for our CRUD operations. 
     * A much more complex usage of this pattern is explained here: https://www.youtube.com/watch?v=rtXpYpZdOzM
     */
    internal static class Repository
    {
        public static List<Animal> Pets { get; set; } = new List<Animal>();
        public static Dictionary<FoodType, int> FoodStorage { get; set; } = new Dictionary<FoodType, int> {};

        public static void AddPet(string petType, string name, int age, string breedType)
        {
            switch (petType)
            {
                case "cat":
                    Pets.Add(new Cat(name, age, breedType));
                    break;
                case "dog":
                    Pets.Add(new Dog(name, age, breedType));
                    break;
                case "puppy":
                    Pets.Add(new Puppy(name, age, breedType));
                    break;
            }
        }

        public static Animal FindPet(string name)
        {
            var pet = Pets.FirstOrDefault(p => p.Name == name);
            return pet;
        }

        public static void RemovePet(Animal pet)
        {
            var animal = Pets.FirstOrDefault(a => a.AnimalId == pet.AnimalId);

            if (animal != null)
            {
                Pets.Remove(animal);
            }
            else
            {
                Console.WriteLine("Strange. Animal can't be found.");
            }
        }

        //This lambda expression takes all keys and modifies their values accordingly
        public static void AddFood(int q)
        {
            FoodStorage = FoodStorage.ToDictionary(f => f.Key, f => f.Value + 10*q);
        }

        public static void ShowFoodStock()
        {
            Console.WriteLine("The existing foods:");
            foreach (var i in FoodStorage)
            {
                Console.WriteLine($"{i.Key.ToString()}: {i.Value} units");
            }  
        }
    }
}
