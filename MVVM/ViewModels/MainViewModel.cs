using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace MVVM.ViewModels
{
    public class MainViewModel
    {
        private Models.RelayCommand openNomenclatureWindowCommand;
        public Models.RelayCommand OpenNomenclatureWindowCommand
        {
            get
            {
                return openNomenclatureWindowCommand ??
                    (openNomenclatureWindowCommand = new Models.RelayCommand(o=>OpenNomenclatureWindow()));
            }
        }
        private void OpenNomenclatureWindow()
        {
            Views.NomenclatureWindow nomenclatureWindow = new Views.NomenclatureWindow();
            nomenclatureWindow.ShowDialog();
        }
    }
}
