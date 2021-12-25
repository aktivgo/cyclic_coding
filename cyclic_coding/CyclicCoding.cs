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

            Stringify(result);
            return result;
        }

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

            // 10000/1011
            while (!IsPolynomialLess(newDivisible, divider))
            {
                int k = newDivisible[0] / divider[0];
                result.Add(k);
                if (k > 0)
                {
                    for (int i = divider.Count - 1; i >= 0; i--)
                    {
                        newDivisible[i] += k * divider[i];
                        newDivisible[i] %= 2;
                    }

                    Stringify(newDivisible);
                    tailings.Add(newDivisible);
                }
                else
                {
                    newDivisible.Add(0);
                }
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

            // 10000 1011
            return false;
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