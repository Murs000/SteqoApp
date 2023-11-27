using Microsoft.Win32;
using SteqoApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SteqoApp.Commands
{
    internal class SetPathCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly MainPageViewModel _viewModel;
        public SetPathCommand(MainPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            _viewModel.ImagePath = openFileDialog.FileName;
        }
    }
}
