using SteqoApp.ViewModel;
using SteqoApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace SteqoApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainPage mainPage = new MainPage();
            mainPage.DataContext = new MainPageViewModel();
            MainWindow = mainPage;
            MainWindow.Show();
        }
    }
}
