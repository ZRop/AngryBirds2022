using BackEnd;
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
using System.Threading;
using System.Windows.Threading;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool gameover = false;

        double kx, ky;

        public MainWindow()
        {
            InitializeComponent();
            
            StartGame();
        }

        private void SaveF(object sender, RoutedEventArgs e)
        {
            string s = StSpeed.Text;
            string a = StAngle.Text;
            using (var save = new StreamWriter(@"..\..\..\Saves\Data.txt"))
            {
                save.WriteLine(s);
                save.WriteLine(a);
            }
        }

        private void LoadF(object Sender, RoutedEventArgs e)
        {
            using (var load = new StreamReader(@"..\..\..\Saves\Data.txt"))
            {
                StSpeed.Text = load.ReadLine();
                StAngle.Text = load.ReadLine();
            }
        }

        public void StartGame()
        {
            Canvas.SetTop(Ammo,249);
            Canvas.SetLeft(Ammo, 10);

            Random pos = new Random();
            Canvas.SetLeft(Trg, 735);
            Canvas.SetTop(Trg, pos.Next(200, 250));

            StAngle.Visibility = Visibility.Visible;
            StSpeed.Visibility = Visibility.Visible;
            Fire.Visibility = Visibility.Visible;

            StAngle.Clear();
            StSpeed.Clear();


            kx =1;
            ky =1;

            gameover = false;
        }

        private void restartGame(object sender, RoutedEventArgs e)
        {
                StartGame();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string speed = StSpeed.Text;
            string angle = StAngle.Text;

            

            if(speed.Length == 0 || angle.Length == 0 || Convert.ToDouble(angle) > 90)
            {
                MessageBox.Show("?????????????? ???????????? ??????????????????!!!");
            }
            else
            {
                StAngle.Visibility = Visibility.Hidden;
                StSpeed.Visibility = Visibility.Hidden;
                Fire.Visibility = Visibility.Hidden;

                Par par = new Par(Convert.ToDouble(angle), Convert.ToDouble(speed), kx,ky);

                for (int i = 0; i < par.coordX.Count; i++)
                { 
                    Canvas.SetTop(Ammo,290 - 50*(par.coordY[i]));
                    Canvas.SetLeft(Ammo, 50*par.coordX[i]);

                    await Task.Delay(6);
                    if (Canvas.GetLeft(Ammo) <= 760 && Canvas.GetTop(Ammo) <= 290 && i != par.coordX.Count - 1)
                    {
                        if (((Canvas.GetTop(Ammo) + 40 >= Canvas.GetTop(Trg)) && (Canvas.GetTop(Ammo) + 40 <= 40 + Canvas.GetTop(Trg)) && (Canvas.GetLeft(Ammo) + 40 >= Canvas.GetLeft(Trg)) && (Canvas.GetLeft(Ammo) + 40 <= 40 + Canvas.GetLeft(Trg))))
                        {
                            MessageBox.Show("You won!!!");

                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("You lose!!!");
                        break;  
                    }
                }
            }
            gameover = true;
        }
    }
}
