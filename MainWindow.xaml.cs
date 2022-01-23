using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ScaleImage(OpenFileDialog op, float spriteScaleFactor1, float spriteScaleFactor2)
        {
            var bmp = new BitmapImage(new Uri(op.FileName));
            Image.Width = bmp.Width * spriteScaleFactor1 * spriteScaleFactor2;
            Image.Height = bmp.Height * spriteScaleFactor1 * spriteScaleFactor2;
            Image.Source = bmp;
            Image.Stretch = Stretch.Fill;
            Canvas.SetBottom(Image, 0);
            Line.Y1 = 0;
            Line.Y2 = 0;
            Line.X2 = Image.Width;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ScaleImage(op, 2.5f, 2);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int number;
            if (int.TryParse(TextBox.Text, out number))
            {
                Line.Y1 = 0 + 8;
                var tmp = number + Line.StrokeThickness / 2;
                Line.Y1 -= tmp * 3;
                Line.Y2 = Line.Y1;
            }
            else 
            {
                return;
            }
        }
    }
}
