using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Joppes
{
    internal class Puppy : Dog
    {
        public Puppy(string name, int age, string breedType) : base(name, age, breedType)
        {
            FavoriteFood = FoodType.PuppyFood;
        }

        public override void Interact(Ball ball)
        {
            if (IsHungry)
            {
                OnHungry();
                return;
            };
            Console.WriteLine($"{Name} is just a puppy and is too small to grab the ball with its mouth. He became tired trying to grab the ball and is now sleepy and hungry.");
            IsHungry = true;
        }

        public override bool DecreaseFood()
        {
            if (Repository.FoodStorage[FoodType.PuppyFood] == 0)
            {
                Console.WriteLine("No puppy food left. You must buy some to feed your puppy.");
                return false;
            }
            Repository.FoodStorage[FoodType.PuppyFood]--;
            return true;
        }
    }
}
