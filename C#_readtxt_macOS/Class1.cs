using System;
using System.IO;

namespace prectice01
{
    public class Class1
    {
        public string cube()
        {
            var path = "/Users/light0986/Documents/c#/prectice01/test.txt";
            StreamReader reader = new StreamReader(path);
            var input = reader.ReadToEnd();
            return input;
        }
    }
}
