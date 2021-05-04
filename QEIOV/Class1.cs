using System;

namespace project01
{
    public class QEIOV
    {
        public static void Main()
        {
            //2A分之-B +-根號b平方-4AC
            double a = 1;
            double b = -6;
            double c = 8;
            double d = new QEIOV().math1(a, b, c);
            double e = new QEIOV().math2(a, b, c);
            Console.WriteLine(d + ";" + e);
        }
        public double math1(double a, double b, double c)
        {
            double ans = 2 * a;//2Ａ
            double ans2 = -b;//-B
            double ans3 = (b * b) - (4 * a * c);//
            
            if (ans3 < 0)
            {
                ans3 = ans3 * -1;
                ans3 = Math.Sqrt(ans3);
                ans3 = ans3 * -1;
            }
            else
            {
                ans3 = Math.Sqrt(ans3);
            }
            double ans4 = (ans2 + ans3) / ans;
            return Math.Round(ans4,2); //根號b平方減4ac
        }
        public double math2(double a, double b, double c)
        {
            double ans = 2 * a;//2Ａ
            double ans2 = -b;//-B
            double ans3 = (b * b) - (4 * a * c);//

            if (ans3 < 0)
            {
                ans3 = ans3 * -1;
                ans3 = Math.Sqrt(ans3);
                ans3 = ans3 * -1;
            }
            else
            {
                ans3 = Math.Sqrt(ans3);
            }
            double ans4 = (ans2 - ans3) / ans;
            return Math.Round(ans4, 2); //根號b平方減4ac
        }
    }
}