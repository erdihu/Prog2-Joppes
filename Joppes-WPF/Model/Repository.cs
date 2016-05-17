using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Joppes_WPF
{
    /* 
     * Repository is where the data and its interaction methods stay. 
     * This is handy because when we want to connect the application to an external database, 
     * it will be the gate of our database communication. 
     * I.e: The repository will handle the business model of adding and removing the data by various database APIs.
     * If we for example add an Entity Framework to this project, database context methods will be responsible for our CRUD operations. 
     * A much more complex usage of this pattern is explained here: https://www.youtube.com/watch?v=rtXpYpZdOzM
     */

    public class Repository
    {
        private List<Animal> _pets;
        public Dictionary<FoodType, int> FoodStorage = new Dictionary<FoodType, int>();


        private Repository()
        {
            _pets.Add(new Dog("Cinnamon",1,"Husky"));

            FoodStorage.Add(FoodType.CatFood, 10);
            FoodStorage.Add(FoodType.DogFood, 10);
            FoodStorage.Add(FoodType.PuppyFood, 10);
        }

        
        public void AddPet(Animal a)
        {
            _pets.Add(a);
        }

        public void RemovePet(Animal pet)
        {

        }

        //This lambda expression takes all keys and modifies their values accordingly
        public void AddFood(int q)
        {
            FoodStorage = FoodStorage.ToDictionary(f => f.Key, f => f.Value + 10*q);
        }

        public void ShowFoodStock()
        {

        }

        public List<Animal> Get()
        {
            return _pets;
        }

        public Animal Get(Animal animal)
        {
            var fetched = _pets.FirstOrDefault(p => p.AnimalId == animal.AnimalId);
            return fetched ?? null;
        }

    }
}
