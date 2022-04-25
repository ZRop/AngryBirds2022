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

using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer tmr = new DispatcherTimer();

        Vector relativeMousePos;
        FrameworkElement draggedObject;


        bool gameover = false;

        int score = 0;

        int Trg_pos;

        double kx, ky;

        public MainWindow()
        {
            InitializeComponent();

            StartGame();
        }

        public void StartGame()
        {
            tmr.Interval = TimeSpan.FromMilliseconds(100);

            Canvas.SetTop(Ammo,260);
            Canvas.SetLeft(Ammo, 10);

            Random pos = new Random();
            Canvas.SetLeft(Trg, 735);
            Canvas.SetTop(Trg, pos.Next(65, 260));



            score = 0;

            StAngle.Visibility = Visibility.Visible;
            StSpeed.Visibility = Visibility.Visible;
            Fire.Visibility = Visibility.Visible;

            StAngle.Clear();
            StSpeed.Clear();


            Random rnd = new Random();
            kx = rnd.Next(-1, 1);
            ky = rnd.Next(-1, 1);

            gameover = false;
        }

        private void restartGame(object sender, RoutedEventArgs e)
        {
            if(gameover == true)
            {
                StartGame();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string speed = StSpeed.Text;
            string angle = StAngle.Text;

            

            if(speed.Length == 0 || angle.Length == 0)
            {
                MessageBox.Show("Введите данные корректно!!!");
            }
            else
            {
                StAngle.Visibility = Visibility.Hidden;
                StSpeed.Visibility = Visibility.Hidden;
                Fire.Visibility = Visibility.Hidden;
                restart.Visibility = Visibility.Visible;
                



                Par par = new Par(Convert.ToDouble(angle), Convert.ToDouble(speed), Convert.ToDouble(kx), Convert.ToDouble(ky));

                MessageBox.Show("Стартовый угол " + StAngle.Text + ", а стартовая скорость " + StSpeed.Text +" Приземление состоиться в Х = "+ par.coordX[par.coordX.Count - 1]);


                for ()
                {

                }

                gameover = true;
                
            }

            

        }

        /*
        void StartDrag(object sender, MouseButtonEventArgs e)
        {
            draggedObject = (FrameworkElement)sender;
            relativeMousePos = e.GetPosition(draggedObject) - new Point();
            draggedObject.MouseMove += OnDragMove;
            draggedObject.LostMouseCapture += OnLostCapture;
            draggedObject.MouseUp += OnMouseUp;
            Mouse.Capture(draggedObject);
        }
        void OnDragMove(object sender, MouseEventArgs e)
        {
            UpdatePosition(e);
        }
        void UpdatePosition(MouseEventArgs e)
        {
            var point = e.GetPosition(www);
            var newPos = point - relativeMousePos;
            Canvas.SetLeft(draggedObject, newPos.X);
            Canvas.SetTop(draggedObject, newPos.Y);
        }
        void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            FinishDrag(sender, e);
            Mouse.Capture(null);
        }

        void OnLostCapture(object sender, MouseEventArgs e)
        {
            FinishDrag(sender, e);
        }
        void FinishDrag(object sender, MouseEventArgs e)
        {
            draggedObject.MouseMove -= OnDragMove;
            draggedObject.LostMouseCapture -= OnLostCapture;
            draggedObject.MouseUp -= OnMouseUp;
            UpdatePosition(e);
        }*/




    }
}
