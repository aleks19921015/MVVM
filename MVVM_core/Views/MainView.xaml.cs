using System.Windows;

namespace MVVM_core.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();
        }
    }
}
