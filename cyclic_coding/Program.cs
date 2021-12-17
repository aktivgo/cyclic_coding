using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cyclic_coding
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            List<int> p1 = new List<int>();
            string input = Console.ReadLine();
            Debug.Assert(input != null, nameof(input) + " != null");
            foreach (var item in input)
            {
                p1.Add(int.Parse(item.ToString()));
            }
            
            List<int> p2 = new List<int>();
            input = Console.ReadLine();
            Debug.Assert(input != null, nameof(input) + " != null");
            foreach (var item in input)
            {
                p2.Add(int.Parse(item.ToString()));
            }
            KeyValuePair<List<List<int>>, List<int>> result = CyclicCoding.DividePolynomials(p1, p2);

            foreach (var item in result.Value)
            {
                Console.Write(item);
            }
        }
    }
}