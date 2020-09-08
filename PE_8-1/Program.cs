using System;

namespace PE_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //various varibles
            double x;            
            double y;
            double z;
            int i = 0;
            int j = 0;
            double[,,] bArray = new double[30, 1200, 3];

                    

            //z = Math.Pow(3 * y, 2) + (2 * x) - 1;  

            //this loads x, y, and z into a 3-d array.
            for (x = -1; x <= 1; x += 0.1)
            {
                i++;
                for (y = 1; y <= 4.1; y += 0.1)
                {
                    j++;
                    z = Math.Pow(3 * y, 2) + (2 * x) - 1;

                    bArray[i, j, 0] = x;
                    bArray[i, j, 1] = y;
                    bArray[i, j, 2] = z;

                    //Console.WriteLine(x);
                    //Console.WriteLine(y);
                    //Console.WriteLine(z);
                }
            }



        }
    }
}
