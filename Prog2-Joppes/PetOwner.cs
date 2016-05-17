using System;
using System.IO;
using System.Linq;

namespace Prog2_Joppes
{
    internal class PetOwner
    {
        public int Age { get; set; }
        public Ball Ball => Ball.GetBall;
        public Animal SelectedAnimal { get; set; }

        //Initializer to fill the food storage. 
        public void FillFoodStorage()
        {
            Repository.FoodStorage.Add(FoodType.CatFood, 10);
            Repository.FoodStorage.Add(FoodType.DogFood, 10);
            Repository.FoodStorage.Add(FoodType.PuppyFood, 10);
        }

        public PetOwner(int age)
        {
            Age = age;
            FillFoodStorage();
        }

        public void PlayFetch()
        {
            SelectedAnimal.Interact(Ball);
        }

        //Feed method asks user input of selected food type. It will then transfer the food type to the selected animal's method.
        public void Feed()
        {
            Console.WriteLine("Feed with 1)dog food 2)puppy food 3)cat food");

            string input = Console.ReadLine();

            //We must initialize this enum, otherwise it won't compile. 
            FoodType type = FoodType.CatFood;

            while (!(input.Equals("1") || input.Equals("2") || input.Equals("3")))
            {
                Console.WriteLine("Feed with 1)dog food 2)puppy food 3)cat food");

                input = Console.ReadLine();
            }

            switch (input)
            {
                case "1":
                    type = FoodType.DogFood;
                    break;
                case "2":
                    type = FoodType.PuppyFood;
                    break;
                case "3":
                    type = FoodType.CatFood;
                    break;
            }

            //Eat only if there is enough food
            if (SelectedAnimal.DecreaseFood())
            {
                SelectedAnimal.Eat(type);
            }
        }

        //Lists all the animals by calling their ToString methods. If no pet is existing, it offers to create one.
        public void ListAnimals()
        {
            if (!Repository.Pets.Any())
            {
                Console.WriteLine("You don't have any pets. Do you want to add one? (y/n)");
                var input = Console.ReadKey();

                if (input.KeyChar == 'y')
                {
                    AddPetMenu();
                }
                else
                {
                    ListAnimals();
                }
            }
            else
            {
                foreach (var item in Repository.Pets)
                {
                    Console.WriteLine(item.ToString());
                }
            }


        }

        //This method is very restrictive. It requires 3 commas in the input to serialize it to an array. If the third member of the array is not a number, it gives error. However, I think this is more practical way to ask type, name, age, breed seperately. It's quicker when debugging.
        private void AddPetMenu()
        {
            Console.WriteLine(
                "You can add pets by the following example: [PetType], [Name], [Age], [BreedType]. [PetType] can take dog, puppy, cat. Sample: cat, fluffy, 2, scottish fold");

            var petinput = Console.ReadLine().Split(',');

            while (petinput.Length != 4)
            {
                Console.WriteLine("There seems to be a problem with your input. Try again: ");
                petinput = Console.ReadLine().Split(',');
            }

            int petAge;
            var controlAge = int.TryParse(petinput[2], out petAge);

            while (!controlAge)
            {
                Console.WriteLine("There seems to be a problem with your input. Try again: ");
                petinput = Console.ReadLine().Split(',');
            }

            /*
             * Clears whitespaces from the user input.
             * This created me some problem because "cat, fluffy, 2, scottish fold" input is being seperated as " fluffy" (note the whitespace) leading a 
             * null object when searching for the item. It was hard to see in the debug because it is hard to notice that whitespace on the first glance.
            */
            for (int i = 0; i < petinput.Length; i++)
            {
                petinput[i] = petinput[i].Trim();
            }

            Repository.AddPet(petinput[0], petinput[1], petAge, petinput[3]);
            ShowMenu();
        }


        //This doesn't require any input validation because we are just showing "pet not found" on null objects.
        private void RemovePetMenu()
        {
            ListAnimals();
            Console.WriteLine("Please write pet name to be removed:");

            var petinput = Console.ReadLine();
            var pet = Repository.FindPet(petinput);
            Repository.RemovePet(pet);
            ShowMenu();
        }

        //Prints the ball quality.
        public void CheckBall()
        {
            Console.WriteLine(Ball.ToString());
            ShowMenu();
        }

        //This is a bit messy. Mainly because I did not differentiate between animal specific action menu and general menu. However I noticed that this is a problem for the user because a lot of repetition is needed to continue the interaction. 
        public void ShowMenu()
        {
            ListAnimals();
            Console.WriteLine("Type pet name to interact: ");
            string petname = Console.ReadLine();

            //Input controls needs a lot of repetition in code
            if (string.IsNullOrEmpty(petname))
            {
                Console.WriteLine("Something happened. Please try again.");
                ShowMenu();
            }

            var pet = Repository.FindPet(petname);

            while (pet == null)
            {
                Console.WriteLine("Type pet name to interact: ");
                petname = Console.ReadLine();

                if (string.IsNullOrEmpty(petname))
                {
                    Console.WriteLine("Something happened. Please try again.");
                    ShowMenu();
                }
                pet = Repository.FindPet(petname);
            }

            SelectedAnimal = pet;

            Console.WriteLine($"What would you like to do with {SelectedAnimal.Name}?");
            Console.WriteLine($"1) Play fetch\n2) Feed\n---\n3) Add pet\n4) Remove pet\n---\n5) List all pets\n6) Check ball quality\n7) Check food storage\n8) Buy food\n---\n9) About me\n---\n10) Write animal list in a text file");

            int input;
            int.TryParse(Console.ReadLine(), out input);


            switch (input)
            {
                case 1:
                    PlayFetch();
                    break;
                case 2:
                    Feed();
                    break;
                case 3:
                    AddPetMenu();
                    break;
                case 4:
                    RemovePetMenu();
                    break;
                case 5:
                    ListAnimals();
                    break;
                case 6:
                    CheckBall();
                    break;
                case 7:
                    Repository.ShowFoodStock();
                    break;
                case 8:
                    BuyFood();
                    return;
                case 9:
                    base.ToString();
                    break;
                case 10:
                    PrintToFile();
                    break;
                default:
                    AskForMenu();
                    break;
            }

            AskForMenu();
        }

        //This method prints all animals to a text file and saves it on desktop
        private void PrintToFile()
        {
            string strPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "animallist.txt");
            using (var sw = new StreamWriter(strPath))
            {
                foreach (var item in Repository.Pets)
                {
                    sw.WriteLine(item.ToString());
                }
                Console.WriteLine("Success. Check your desktop!");
            }
        }

        private void AskForMenu()
        {
            Console.WriteLine("Do you want to continue playing with your pet? (y/n)");

            var input = Console.ReadKey();

            if (input.KeyChar == 'y')
            {
                ShowMenu();
            }
            else
            {
                //Exit the application
                Environment.Exit(0);
            }
        }

        public void BuyFood()
        {
            Console.WriteLine("Your local supermarket has a discount for pet food bundle! The bundle has dog, puppy, and cat food in it. Each bundle has 10 unit foods of each type. How many bundles do you want to buy?");

            int qint;
            var q = Console.ReadLine();
            var check = int.TryParse(q, out qint);

            while (!check)
            {
                Console.WriteLine("Please enter number: ");
                q = Console.ReadLine();
                check = int.TryParse(q, out qint);              
            }

            Repository.AddFood(qint);
            Repository.ShowFoodStock();
            ShowMenu(); 
        }

        public override string ToString()
        {
            return $"Hello. I am Jeppe. I am {Age} years old and I have {Repository.Pets.Count} animals!";
        }
    }
}
