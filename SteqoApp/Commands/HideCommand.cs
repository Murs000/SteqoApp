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
            /*Bitmap bitmap = new Bitmap(_viewModel.ImagePath);
            string text = TextToBinary(_viewModel.HidenText);
            if (text.Length > bitmap.Height * bitmap.Width)
            {
                return false;
            }
            else
            {
                return true;
            }*/
            return true;
        }

        public void Execute(object parameter)
        {
            Bitmap bitmap = new Bitmap(_viewModel.ImagePath);
            string secret = Convert.ToString(69621, 2);
            string userText = TextToBinary(_viewModel.HidenText);
            string textLenght = Convert.ToString(userText.Length, 2);
            string hideText = textLenght + secret + userText;
            bitmap = Hide(bitmap, hideText);
            string newPath = _viewModel.ImagePath.Insert(_viewModel.ImagePath.LastIndexOf('.'), "Hidden");
            bitmap.Save(newPath);
            bitmap.Dispose();
            _viewModel.Clear();
        }
        private Bitmap Hide( Bitmap bitmap, string str)
        {
            /*if (str.Length % 3 != 0)
            {
                int lenght = str.Length - 1 / 3;
                if(str.Length - lenght == 1)
                {
                    str = str + "0" + "0";
                }
                else
                {
                    str += "0";
                }
            }*/
            int step = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);

                    /*string red = Convert.ToString(color.R, 2);
                    red = red.Remove(red.Length - 1, 1);
                    red = red + str[step];
                    red = Convert.ToInt32(red, 2).ToString();
                    step++;

                    string green = Convert.ToString(color.G, 2);
                    green = green.Remove(green.Length - 1, 1);
                    green = green + str[step];
                    green = Convert.ToInt32(green, 2).ToString();
                    step++;*/

                    string blue = Convert.ToString(color.B, 2);
                    blue = blue.Remove(blue.Length - 1, 1);
                    blue = blue + str[step];
                    blue = Convert.ToInt32(blue, 2).ToString();
                    step++;
                    if (step >= str.Length)
                    {
                        break;
                    }
                    color = Color.FromArgb(color.A, /*Convert.ToInt32(red)*/color.R, /*Convert.ToInt32(green)*/color.G, Convert.ToInt32(blue));
                    bitmap.SetPixel(i, j, color);
                }
                if (step >= str.Length)
                {
                    break;
                }
            }
            return bitmap;
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
