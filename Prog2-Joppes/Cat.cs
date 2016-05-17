using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Joppes
{
    internal class Cat:Animal
    {
        public Cat(string name, int age, string breedType):base(name, age, breedType)
        {
            FavoriteFood = FoodType.CatFood;
        }

        public override bool DecreaseFood()
        {
            if (Repository.FoodStorage[FoodType.CatFood] == 0)
            {
                Console.WriteLine("No cat food left. You must buy some to feed your cat.");
                return false;
            }
            Repository.FoodStorage[FoodType.CatFood]--;
            return true;
        }

        public override void OnHungry()
        {
            Console.WriteLine($"{Name} is hungry and scratched your legs! {Name} is a bad cat.");
        }
    }
}
