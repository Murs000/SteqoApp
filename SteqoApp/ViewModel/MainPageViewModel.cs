using SteqoApp.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace SteqoApp.ViewModel
{
    internal class MainPageViewModel
    {
        public string ImagePath { get; set; }

        public HideCommand Hide => new HideCommand();
        public ExtractCommand Extract => new ExtractCommand();
        public SetPathCommand SetPath => new SetPathCommand();
    }
}
