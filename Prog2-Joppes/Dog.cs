using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Joppes
{
    internal class Dog : Animal
    {
        public Dog(string name, int age, string breedType) : base(name, age, breedType)
        {
            FavoriteFood = FoodType.DogFood;
        }


        public override void Interact(Ball ball)
        {
            PlayCounter++;

            if (PlayCounter == 1)
            {
                Console.WriteLine($"{Name} runs after the ball and brings it back to you.");
                Ball.GetBall.Quality--;

            }
            else if (PlayCounter == 2)
            {
                Console.WriteLine($"{Name} loves to play fetch with its ball. But this play made him hungry.");
                this.IsHungry = true;
                Ball.GetBall.Quality--;
            }
            else if (PlayCounter > 2)
            {
                OnHungry();
            }
            
        }

        public override bool DecreaseFood()
        {
            if (Repository.FoodStorage[FoodType.DogFood] < 1)
            {
                Console.WriteLine("No dog food left. You must buy some to feed your dog.");
                return false;
            }
            Repository.FoodStorage[FoodType.DogFood] = Repository.FoodStorage[FoodType.DogFood] - 2;
            return true;
        }
    }
}
