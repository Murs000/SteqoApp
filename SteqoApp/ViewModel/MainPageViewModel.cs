using SteqoApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace SteqoApp.ViewModel
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public HideCommand Hide => new HideCommand();
        public ExtractCommand Extract => new ExtractCommand();
        public SetPathCommand SetPath => new SetPathCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
