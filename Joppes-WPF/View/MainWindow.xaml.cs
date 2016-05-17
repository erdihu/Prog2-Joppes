using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Joppes_WPF.ViewModel;


namespace Joppes_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _model = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _model;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }
    }
}
