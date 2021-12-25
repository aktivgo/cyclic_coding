using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cyclic_coding
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            /*List<int> gPolynomial = ReadPolynomial("Введите генераторный многочлен: ");
            List<int> polynomial = ReadPolynomial("\nВведите входную последовательность: ");
            
            List<int> result = CyclicCoding.DividePolynomials(polynomial, gPolynomial);
            foreach (var item in result)
            {
                Console.Write(item);
            }*/
            
            List<int> gPolynomial = ReadPolynomial("Введите генераторный многочлен: ");
            Console.WriteLine("1 - Ввести входную последовательность\n2 - Сгенерировать входную последовательность");
            int ch = int.Parse(Console.ReadLine() ?? string.Empty);
            List<int> polynomial = new List<int>();
            switch (ch)
            {
                case 1:
                {
                    polynomial = ReadPolynomial("\nВведите входную последовательность: ");
                }
                    break;
                case 2:
                {
                    Console.Write("Введите длину: ");
                    int length = int.Parse(Console.ReadLine() ?? string.Empty);
                    polynomial = CyclicCoding.GenerateRandomBinarySequence(length);
                    
                    Console.WriteLine("\nСгенерированная последовательность: ");
                    foreach (var item in polynomial)
                    {
                        Console.Write(item);
                    }
                    Console.WriteLine("\nСтепень: " + (polynomial.Count - 1));
                }
                    break;
                default:
                {
                    Console.WriteLine("Ошибка ввода\n");
                }
                    break;
            }
            
            List<int> result = CyclicCoding.MultiplyPolynomials(polynomial, gPolynomial);
            Console.WriteLine("\nЦиклический код: ");
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine("\nСтепень: " + (result.Count - 1));

            List<int> check = CyclicCoding.DividePolynomials(result, gPolynomial);
            Console.Write("\nПроверка(s(x) mod g(x)): ");
            foreach (var item in check)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n" + (check.Count == 1 && check[0] == 0 ? "true" : "false"));
        }

        private static List<int> ReadPolynomial(string message)
        {
            Console.Write(message);
            List<int> p = new List<int>();
            string input = Console.ReadLine();
            Debug.Assert(input != null, nameof(input) + " != null");
            foreach (var item in input)
            {
                p.Add(int.Parse(item.ToString()));
            }

            return p;
        }
    }
}