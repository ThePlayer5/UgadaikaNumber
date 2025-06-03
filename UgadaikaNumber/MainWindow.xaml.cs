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

namespace UgadaikaNumber
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();
        public int rndNum = random.Next(0, 100);
        public int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show($"{rndNum}");
            Bg.Background = Brushes.LightSlateGray;
            Input.IsReadOnly = false;
        }

        private void CheckNumBtn_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if (!string.IsNullOrEmpty(Input.Text))
            {
                int userNum = int.Parse(Input.Text);
                if (userNum < rndNum)
                {
                    Bg.Background = Brushes.IndianRed;
                    MessageBox.Show("Слишком мало");
                }
                else if (userNum + 5 == rndNum || userNum - 5 == rndNum)
                {
                    Bg.Background = Brushes.IndianRed;
                    MessageBox.Show("Вы близко");
                }
                else if (userNum > rndNum)
                {
                    Bg.Background = Brushes.IndianRed;
                    MessageBox.Show("Слишком много");
                }
                else if (userNum == rndNum)
                {
                    Bg.Background = Brushes.SeaGreen;
                    Input.Background = Brushes.Gray;
                    MessageBox.Show("Поздравляем, вы угадали число за X попыток!");
                    Input.IsReadOnly = true;
                }
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            Input.Text = string.Empty;
            Bg.Background = Brushes.LightSlateGray;
            Input.Background = Brushes.White;
            Input.IsReadOnly = false;
            rndNum = random.Next(0, 100);
            MessageBox.Show($"{rndNum}");
        }
    }
}
