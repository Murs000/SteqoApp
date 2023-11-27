using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Drawing;
using SteqoApp.ViewModel;

namespace SteqoApp.Commands
{
    internal class HideCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly MainPageViewModel _viewModel;
        public HideCommand(MainPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            Bitmap bitmap = new Bitmap(_viewModel.ImagePath);
            string text = TextToBinary(_viewModel.HidenText);
            if (text.Length > bitmap.Height * bitmap.Width)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            Bitmap bitmap = new Bitmap(_viewModel.ImagePath);
            string secret = Convert.ToString(69621, 2);
            string text = TextToBinary(_viewModel.HidenText);
            int step = Hide(bitmap, secret,0);
            Hide(bitmap, text, step);
        }
        private int Hide(Bitmap bitmap,string str,int step) 
        {
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    string red = Convert.ToString(color.R, 2);
                    red = red.Remove(red.Length - 1, 1);
                    red = red + str[step];
                    step++;

                    string green = Convert.ToString(color.G, 2);
                    green = green.Remove(green.Length - 1, 1);
                    green = green + str[step];
                    step++;

                    string blue = Convert.ToString(color.B, 2);
                    blue = blue.Remove(blue.Length - 1, 1);
                    blue = blue + str[step];
                    step++;
                }
            }
            return step;
        }

        private string TextToBinary(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            StringBuilder binaryStringBuilder = new StringBuilder();
            foreach (byte b in bytes)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return binaryStringBuilder.ToString();
        }
    }
}
