using SteqoApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SteqoApp.Commands
{
    internal class ExtractCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly MainPageViewModel _viewModel;
        public ExtractCommand(MainPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            using (Bitmap bitmap = new Bitmap(_viewModel.ImagePath))
            {
                string secret = Convert.ToString(69621, 2);
                string rawText = Extract(bitmap);
                string lengh=null;
                if (rawText.Contains(secret))
                {
                    string[] strings = rawText.Split(new string[] { secret }, StringSplitOptions.None);
                    lengh = strings[0];
                    rawText = strings[1];
                    lengh = Convert.ToInt32(lengh, 2).ToString();
                    rawText = rawText.Substring(0, Convert.ToInt32(lengh));
                    _viewModel.HidenText = BinaryToText(rawText);
                }
            }
        }
        public string Extract(Bitmap bitmap)
        {
            string text = null;
            for(int i=0; i<bitmap.Width; i++)
            {
                for(int j=0; j<bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    string blue = Convert.ToString(color.B,2);
                    text += blue[blue.Length-1];
                }
            }
            return text;
        }
        static string BinaryToText(string binary)
        {
            // Ensure the binary string length is a multiple of 8
            int length = binary.Length;
            int padding = 8 - (length % 8);
            if (padding < 8)
            {
                binary = binary.PadLeft(length + padding, '0');
            }

            // Split the binary string into bytes (8 bits each)
            byte[] bytes = new byte[binary.Length / 8];
            for (int i = 0; i < binary.Length; i += 8)
            {
                bytes[i / 8] = Convert.ToByte(binary.Substring(i, 8), 2);
            }

            // Convert bytes to text using UTF-8 encoding
            string originalText = Encoding.UTF8.GetString(bytes);
            return originalText;
        }
    }
}
