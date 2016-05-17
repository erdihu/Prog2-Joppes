using System.Windows;

namespace Joppes_WPF
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
                MessageBox.Show($"{Name} runs after the ball and brings it back to you.");
                Ball.GetBall.Quality--;

            }
            else if (PlayCounter == 2)
            {
                MessageBox.Show($"{Name} loves to play fetch with its ball. But this play made him hungry.");
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
            if (_repo.FoodStorage[FoodType.DogFood] < 1)
            {
                MessageBox.Show("No dog food left. You must buy some to feed your dog.");
                return false;
            }
            _repo.FoodStorage[FoodType.DogFood] = _repo.FoodStorage[FoodType.DogFood] - 2;
            return true;
        }
    }
}
