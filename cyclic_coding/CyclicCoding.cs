using System;
using System.Collections.Generic;

namespace cyclic_coding
{
    public static class CyclicCoding
    {
        public static List<int> MultiplyPolynomials(List<int> multiplier1, List<int> multiplier2)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < multiplier1.Count + multiplier2.Count - 1; i++)
            {
                result.Add(0);
            }

            for (int i = 0; i < multiplier1.Count; i++)
            {
                for (int j = 0; j < multiplier2.Count; j++)
                {
                    result[i + j] += multiplier1[i] * multiplier2[j];
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                result[i] %= 2;
            }

            return result;
        }

        public static List<int> GenerateRandomBinarySequence(int length)
        {
            Random random = new Random();
            List<int> result = new List<int>();
            
            for (int i = 0; i < length; i++)
            {
                result.Add(random.Next(0, 2));
            }

            return result;
        }

        public static List<int> DividePolynomials(List<int> divisible, List<int> divider)
        {
            List<int> newDivisible = new List<int>(divisible);
            
            while (newDivisible.Count >= divider.Count)
            {
                for (int i = 0; i < divider.Count; i++)
                {
                    newDivisible[i] += divider[i];
                    newDivisible[i] %= 2;
                }
                Stringify(newDivisible);
            }
            
            Stringify(newDivisible);
            return newDivisible;
        }
        
        private static void Stringify(List<int> p)
        {
            while (p[0] == 0 && p.Count > 1)
            {
                p.RemoveAt(0);
            }
        }
    }
}