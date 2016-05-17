using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Joppes_WPF.Annotations;

namespace Joppes_WPF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private static Repository _repo;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private AnimalViewModel _selectedAnimal;

        public ObservableCollection<AnimalViewModel> Animals { get; }

        public AnimalViewModel SelectedAnimal
        {
            get { return _selectedAnimal;}
            set
            {
                if (Equals(value, _selectedAnimal)) return;
                _selectedAnimal = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _repo = new Repository();

            Animals = new ObservableCollection<AnimalViewModel>(_repo.Get().OrderBy(p => p.Name).Select(p => new AnimalViewModel(p)));

            Animals.CollectionChanged += AnimalsOnCollectionChanged;
        }

        private void AnimalsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (AnimalViewModel p in e.NewItems)
                    _repo.AddPet(p.Model);
        }
    }
}
