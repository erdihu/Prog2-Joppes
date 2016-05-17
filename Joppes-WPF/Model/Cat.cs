using System.Windows;
using Joppes_WPF.ViewModel;

namespace Joppes_WPF
{
    internal class Cat:Animal
    {
        private MainViewModel _model;
        public Cat(string name, int age, string breedType):base(name, age, breedType)
        {
            FavoriteFood = FoodType.CatFood;
        }

        public override bool DecreaseFood()
        {
            if (_repo.FoodStorage[FoodType.CatFood] == 0)
            {
                MessageBox.Show("No cat food left. You must buy some to feed your cat.");
                return false;
            }
            _repo.FoodStorage[FoodType.CatFood]--;
            return true;
        }

        public override void OnHungry()
        {
            MessageBox.Show($"{Name} is hungry and scratched your legs! {Name} is a bad cat.");
        }
    }
}
