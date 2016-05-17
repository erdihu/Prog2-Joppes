using System.Windows;

namespace Joppes_WPF
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
            MessageBox.Show($"{Name} is just a puppy and is too small to grab the ball with its mouth. He became tired trying to grab the ball and is now sleepy and hungry.");
            IsHungry = true;
        }

        public override bool DecreaseFood()
        {
            if (_repo.FoodStorage[FoodType.PuppyFood] == 0)
            {
                MessageBox.Show("No puppy food left. You must buy some to feed your puppy.");
                return false;
            }
            _repo.FoodStorage[FoodType.PuppyFood]--;
            return true;
        }
    }
}
