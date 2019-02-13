using System;
using System.Collections.Generic;
using System.Linq;

// рандомный код

namespace AboutRef
{
    class Program
    {
        static int Difference(List<KeyValuePair<int, int>> list, int p)
        {
            List<int> temp = new List<int>();
            foreach (var l in list)
            {
                temp.Add(MyFunction(l.Key, l.Value, p));
            }
            int min = temp.Min();
            return temp.IndexOf(min);
        }
            
        static int MyFunction(int x, int y, int z)
        {
            return Math.Abs((x + y) - z);
        }

        static void Main(string[] args)
        {
            int[] a = new int[]{ 1, 2, 3, 4 };
            int[] b = new int[] { 10, 20, 30 };
            
            int m = 18;

            List<KeyValuePair<int, int>> keyValues = new List<KeyValuePair<int, int>>();
            foreach (int i in a)
            {
                foreach (int j in b)
                {
                    keyValues.Add(new KeyValuePair<int, int>(i, j));
                }
            }

            int res = Difference(keyValues, m);

            Console.WriteLine(keyValues[res].Key + " "+ keyValues[res].Value);
        }
    }
}
