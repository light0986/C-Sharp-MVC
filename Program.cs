using System;

namespace c_
{
    class Program
    {
        static void Main(string[] args)
        {
           int a = 1;
           int b = 10;
           int c = sum(a,b);
           Console.WriteLine(c);
        }
        public static int sum(int x, int y)
        {
            int a = x;
            int b = y;
            int c = 0;
            while(a < b+1){
                c = c+a;
                a++;
            }
            return c;
        }
    }
}
