using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Joppes_WPF.Annotations;

namespace Joppes_WPF.ViewModel
{
    public class AnimalViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Animal Model { get; }

        public AnimalViewModel(Animal a)
        {
            Model = a;
        }

        public Guid Id
        {
            get { return Model.AnimalId; }
            set { Model.AnimalId = Guid.NewGuid(); }
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                if (value == Model.Name) return;
                Model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get { return Model.Age; }
            set
            {
                if (value == Model.Age) return;
                Model.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string BreedType
        {
            get { return Model.BreedType; }
            set
            {
                if (value == Model.BreedType) return;
                Model.BreedType = value;
                OnPropertyChanged(nameof(BreedType));
            }
        }

        public FoodType FavoriteFood
        {
            get { return Model.FavoriteFood; }
            set
            {
                if (value == Model.FavoriteFood) return;
                Model.FavoriteFood = value;
                OnPropertyChanged(nameof(FavoriteFood));
            }
        }

        public bool IsHungry
        {
            get { return Model.IsHungry; }
            set
            {
                if (value == Model.IsHungry) return;
                Model.IsHungry = value;
                OnPropertyChanged(nameof(IsHungry));
            }
        }

        public int PlayCounter
        {
            get { return Model.PlayCounter; }
            set
            {
                if (value == Model.PlayCounter) return;
                Model.PlayCounter = value;
                OnPropertyChanged(nameof(PlayCounter));
            }
        }


    }
}
