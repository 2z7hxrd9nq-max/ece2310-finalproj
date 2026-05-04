using System;

namespace PoolQueue
{
    class Pool
    {
        public static int count = 0;  //number of pools instantiated

        public Location Loc { get; set; }
        public Temperature Temp { get; set; }
        public char Name { get; set; }
        public Pool() { }
        public Pool(char n, Location l, Temperature t)
        {
            Name = n;
            Loc = l;
            Temp = t;
        }



    }

    class Location
    {
        public double X { get; set; }
        public double Y { get; set; }

        Location() { }
        Location(double a, double b)
        {
            X = a;
            Y = b;
        }

        double MakeCoord()
        {

        }

    }

    class Temperature
    {
        public double Degree { get; set; }
        public bool Scale { get; set; }  //true: Fahrenheit, false: Celsius

        public Temperature() { }
        public Temperature(double d, bool s)
        {
            Degree = d;
            Scale = s;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Pool.count.ToString());
            Pool[] poolList = new Pool[7];
            char

            Console.WriteLine(Pool.count.ToString());
            Console.WriteLine("Hello World!");
        }

        double getDistance(Pool a, Pool b)  //gets distance btwn two pools using 
        {
            return Math.Sqrt(Math.Pow((a.Loc.X - b.Loc.X), 2) + Math.Pow(a.Loc.Y - b.Loc.Y, 2));
        }
    }
}

