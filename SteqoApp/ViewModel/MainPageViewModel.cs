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

        private string _hidenText;
        public string HidenText
        {
            get => _hidenText;
            set
            {
                _hidenText = value;
                OnPropertyChanged(nameof(HidenText));
            }
        }

        public HideCommand Hide => new HideCommand(this);
        public ExtractCommand Extract => new ExtractCommand();
        public SetPathCommand SetPath => new SetPathCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
