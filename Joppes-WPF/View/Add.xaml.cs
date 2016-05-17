using System;
using System.Windows;

namespace Joppes_WPF
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private Repository _repo = Repository.GetRepository;
        public Add()
        {
            InitializeComponent();
            cmbAnimalType.ItemsSource = Enum.GetNames(typeof(Animals));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Animal a = new Cat(PetName.Text, (int)AgeSlider.Value, Breed.Text);
            switch (cmbAnimalType.SelectedItem.ToString().ToLower())
            {
                case "cat":
                    a = new Cat(PetName.Text, (int)AgeSlider.Value, Breed.Text);
                    break;
                case "dog":
                    a = new Dog(PetName.Text, (int)AgeSlider.Value, Breed.Text);
                    break;
                case "puppy":
                    a = new Puppy(PetName.Text, (int)AgeSlider.Value, Breed.Text);
                    break;
            }

            _repo.AddPet(a);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
