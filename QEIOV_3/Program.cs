using System;

namespace console_project
{
    class Program
    {
        static void Main(string[] args)
        {
            
                //2A分之-B +-根號b平方-4AC
                double a = 1;
                double b = -6;
                double c = 8;
                double[] d = new double[2];
                d = new project01.QEIOV().Math1(a, b, c);
                Console.WriteLine(d[0] + "," + d[1]);
           
        }
    }
}
