using System;
using System.Collections.Generic;

namespace cyclic_coding
{
    public static class CyclicCoding
    {
        public static KeyValuePair<List<List<int>>, List<int>> DividePolynomials(List<int> divisible, List<int> divider)
        {
            Stringify(divisible);
            Stringify(divider);
            
            if (IsPolynomialLess(divisible, divider))
            {
                throw new ArgumentException("Делитель должен быть меньше делимого");
            }

            List<int> result = new List<int>();
            List<List<int>> tailings = new List<List<int>>();
            List<int> newDivisible = new List<int>(divisible);

            // 1000/1010
            while (!IsPolynomialLess(divider, newDivisible))
            {
                int k = newDivisible[0] / divider[0];
                result.Add(k);
                for (int i = divider.Count - 1; i >= 0; i--)
                {
                    newDivisible[i] += (k * divider[i]) % 2;
                }
                Stringify(newDivisible);
                tailings.Add(newDivisible);
            }
            
            return new KeyValuePair<List<List<int>>, List<int>>(tailings, result);
        }

        private static bool IsPolynomialLess(List<int> p1, List<int> p2)
        {
            if (p1.Count < p2.Count)
            {
                return true;
            }
            
            // 1000 1011
            if (p1.Count == p2.Count)
            {
                for (int i = 0; i < p1.Count; i++)
                {
                    if (p1[i] < p2[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void Stringify(List<int> p)
        {
            while (p[0] == 0)
            {
                p.RemoveAt(0);
            }
        }
    }
}