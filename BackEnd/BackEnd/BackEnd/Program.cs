using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackEnd
{
    class Par
    {
        public static double g = 9.81;
        public double[] coordX = new double[10];
        public double[] coordY = new double[10];
        public double Angle, StSpeed;

        public Par(double Angle, double StSpeed)
        {
            this.Angle = Angle;
            this.StSpeed = StSpeed;
            int n = 9;
            double x, y, Time;
            Time = (2 * StSpeed * StSpeed * Math.Sin(Angle)) / g;
            double DifTime = Time / n;

            for (int i = 0; i <= n; i++)
            {
                coordX[i] = StSpeed * DifTime * i * Math.Cos(Angle);

                if(StSpeed * Math.Sin(Angle) * i * DifTime - 0.5 * (g * DifTime * DifTime * i * i) <= 0) { coordY[i] = 0; }
                else coordY[i] = StSpeed * Math.Sin(Angle) * i * DifTime - 0.5 * (g * DifTime * DifTime * i * i);

            }
        }

        public void Out()
        {
            FileStream file = new FileStream(@"C:\Users\Artem.Churikov\source\repos\BackEnd\Data.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            for (int i = 0; i <= 9; i++) {
                
                writer.Write("Координаты (x,y) = (" + coordX[i] + "," + coordY[i] + ")");
                
               // Console.WriteLine("Координаты (x,y) = (" +coordX[i]+","+coordY[i]+")");
            }
            writer.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Par test1 =new Par(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));

            test1.Out();
            int x = Console.Read();

            
            
        }
    }
}
