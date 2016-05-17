using System;
using System.Windows;

namespace Joppes_WPF
{
    /*
     * This is our base class for the pets. It supplies all the necessary variables to create a pet. 
     * All pets start their life with IsHungry = false and PlayCounter = 0. PlayCounter is only used in Dog child class, 
     * to make the dogs play 2 times before they get hungry.
     * 
     * FoodType is supplied from the child class. The rest calls the base constructor. i.e. This one.
     * 
     * IsHungry is used to determine whether the pet can play or not. If it is true, pet won't play and do the actions defined in OnHungry().
     * 
     * Eat() ensures that all pets eat only special foods created for them for simplicity. 
     * This can be modified and be based on an user input while adding the pet. 
     * 
     * DecreaseFood() is used to determine how many units of foods each pet will require to change their IsHungry status to true. 
     * It must be overridden in children classes.
     * 
     * ToString() just writes pet's name, age, and breed on the screen. It is used to list all the pets to the user so that 
     * user can see all of them before writing pets' name.
     * 
     * As for the moment, AnimalId is not being used. It will be handy in situations such as two or more pets having the same name.
     * Currently search function is made from pet name, so it is not suitable for big databases. 
     */

    public abstract class Animal
    {
        internal int Age { get; set; }
        internal string Name { get; set; }
        internal FoodType FavoriteFood { get; set; }
        internal string BreedType { get; set; }
        internal bool IsHungry { get; set; }
        internal Guid AnimalId { get; set; }
        internal int PlayCounter { get; set; }

        //Base constructor for all the pets.
        protected Animal(string name, int age, string breedType)
        {
            Name = name;
            Age = age;
            BreedType = breedType;
            AnimalId = Guid.NewGuid();
            IsHungry = false;
            PlayCounter = 0;
        }   

        public virtual void Interact(Ball ball)
        {
            if (IsHungry)
            {
                OnHungry();
                return;
            };
            MessageBox.Show($"{Name} is such an egoistical animal, it doesn't want to interact with its human.");
            IsHungry = true;
        }

        public virtual void Eat(FoodType food)
        {
            if (food != FavoriteFood)
            {
                MessageBox.Show($"No no no... {Name} doesn't like this food.");
                return;
            }

            if (IsHungry)
            {
                MessageBox.Show($"Yummy. It liked {food} and is now not hungry.");
                IsHungry = false;
                PlayCounter = 0;
            }
            else
            {
                MessageBox.Show($"{Name} doesn't want to eat. It is not hungry.");
            }
            
        }

        public abstract bool DecreaseFood();

        public virtual void OnHungry()
        {
            MessageBox.Show($"{Name} is hungry and cries for some food... :(");
        }

        public override string ToString()
        {
            return $"Animal type: {GetType().Name} - Name: {Name} - Age: {Age} - Breed: {BreedType}";
        }
    }
}
