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
        public List<double> coordX = new List<double>();
        public List<double> coordY = new List<double>();
        public double m = 5;
        public double kx,ky;
        public double Angle, StSpeed;

        public Par(double Angle, double StSpeed, double kx, double ky)
        {
            this.Angle = Angle;
            this.StSpeed = StSpeed;
            this.kx = kx;
            this.ky = ky;
            
            
            List<double> speedx = new List<double> ();
            List<double> speedy = new List<double> ();
            
            int i = 0;
            speedx.Add(StSpeed * Math.Cos(Angle));
            speedy.Add((StSpeed * Math.Sin(Angle)));
            coordX.Add(0);
            coordY.Add(0);


            while (true)
            {
                speedx.Add(speedx[i] - 0.5 * (kx * speedx[i]) / m);
                speedy.Add(speedy[i] - 0.5 * (g + (ky * speedy[i]) / m));
                coordX.Add(coordX[i] + 0.5 * speedx[i]);
                coordY.Add(coordY[i] + 0.5 * speedy[i]);


                if ((coordY[i] + 0.5 * speedy[i]) < 0) { break; }

                i++;

            }
            
        }

        public void Out()
        {
            FileStream file = new FileStream(@"Data.csv", FileMode.Create);//  ../
            StreamWriter writer = new StreamWriter(file);
            
            for (int i = 0; i < coordX.Count; i++) {
            

                writer.WriteLine(coordX[i] + ";" + coordY[i]) ;
                
               
            }
            writer.Close();
        }
    }
    
}
