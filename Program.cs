using System;

namespace PoolQueue
{
    class Pool
    {
        public static int count = 0;  //number of pools instantiated

        public Location Loc { get; set; }
        public Temperature Temp { get; set; }
        public string Name { get; set; }
        public Pool()
        {
            Pool.count++;
        }
        public Pool(string n, Location l, Temperature t)
        {
            Name = n;
            Loc = l;
            Temp = t;
            Pool.count++; //increment counter
        }

        public override string ToString()
        {
            if(this.Loc == null)
            { return "Pool " + this.Name.ToString() + " at " + this.Loc.ToString() + ", " + this.Temp.ToString(); }
            return "Pool " + this.Name.ToString() + " at " + this.Loc.ToString() + ", " + this.Temp.ToString();
        }

    }

    class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location() { }
        public Location(int a, int b)
        {
            X = a;
            Y = b;
        }

        public override string ToString()
        {
            return "(" + X.ToString() + "," + Y.ToString() + ")";
        }

    }

    class Temperature
    {
        private static Random R = new Random();

        public double Degree { get; set; }
        public bool Scale { get; set; }  //true: Fahrenheit, false: Celsius

        public Temperature()
        {
            Degree = 68; //ambient temperature 
            Scale = true;
        }
        public Temperature(double d, bool s)
        {
            Degree = d;
            Scale = s;
        }

        public void SetTemp()
        {
            this.Degree = 98.0 + (6 * R.NextDouble()); // random temp btwn 98 and 104 F
        }

        public override string ToString()
        {
            char cf = 'F';
            if (!Scale) cf = 'C';
            return Math.Round(Degree, 1).ToString() + " " + cf;  
        }

    }


    class Program
    {

        static void Main(string[] args) 

         /*
           Steps: 1) create + fill array with seven locations
                  2) create + fill array with seven pools, assign each location to each pool in order
                  3) get shortest paths from each point to next, sort Pool array in shortest path order
                  4) traverse Pool array setting Pool.Temp at each one; print Pool.ToString() for each step.             
         */


        {
            Console.WriteLine("Pools instantiated: " + Pool.count.ToString());
            int[] xlist = { 0, 1, 4, 4, 6, 10, 12, 13 };
            int[] ylist = { 0, 3, 2, 8, 6, 5, 9, 1 };  //coordinates
            string[] namelist = { "a", "b", "c", "d", "e", "f", "g" };
            Location[] loclist = new Location[8];
            Pool[] poolList = new Pool[7];


            loclist[0] = new Location(0, 0);

            for(int i = 0; i < 7; i++)  //fill location list and fill pool list
            {
                loclist[i+1] = new Location(xlist[i+1], ylist[i+1]);
                poolList[i] = new Pool(namelist[i], loclist[i+1], new Temperature());
                Console.WriteLine(poolList[i].ToString());
                Console.WriteLine("Pools instantiated: " + Pool.count.ToString());
            }

            double distance;

            for (int i = 0; i < 7; i++)
            {
                distance = getDist(loclist[i], poolList[i].Loc); 

                for (int j = i; j < 7; j++)

                    if (getDist(loclist[i], poolList[j].Loc) < distance)
                    {
                        distance = getDist(poolList[i].Loc, poolList[j].Loc);
                        (poolList[i], poolList[j]) = (poolList[j], poolList[i]); //swap the elements
                        (loclist[i], loclist[j + 1]) = (loclist[j + 1], loclist[i]);
                    }
                }

            Console.Write("\n\n\n");

            for(int i = 0; i < 7; i++)
            {
                poolList[i].Temp.SetTemp(); 
                Console.WriteLine(poolList[i].ToString());
                if(i < 6) { Console.WriteLine("Distance to next pool: " + Math.Round(getDist(poolList[i].Loc, poolList[i + 1].Loc),2).ToString()); }
                
            }
       

            double getDist(Location a, Location b)  //gets distance btwn two pools using 
            {
                return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow(a.Y - b.Y, 2));
            }

        }

       
    }
}

