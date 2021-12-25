using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cyclic_coding
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                PrintMenu();
                Console.Write("\nВыберите пункт меню: ");
                string ch = Console.ReadLine();

                switch (ch)
                {
                    case "0": return;
                    case "1":
                    {
                        List<int> p1 = ReadPolynomial("\nВведите первый полином: ");
                        List<int> p2 = ReadPolynomial("Введите второй полином: ");
                        List<int> result = CyclicCoding.MultiplyPolynomials(p1, p2);
                        PrintResult(result);
                    }
                        break;
                    case "2":
                    {
                        List<int> p1 = ReadPolynomial("\nВведите первый полином: ");
                        List<int> p2 = ReadPolynomial("Введите второй полином: ");
                        KeyValuePair<List<List<int>>, List<int>> result = CyclicCoding.DividePolynomials(p1, p2);
                        PrintResult(result);
                    }
                        break;
                    case "3":
                    {
                    }
                        break;
                    default:
                    {
                        Console.WriteLine("Ошибка ввода: попробуйте ещё раз");
                    }
                        break;
                }
            }
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

        private static void PrintMenu()
        {
            Console.WriteLine("1. Умножение полиномов");
            Console.WriteLine("2. Деление полиномов");
            Console.WriteLine("3. Вычисление циклического кода");
            Console.WriteLine("0. Выход");
        }

        private static void PrintResult(List<int> result)
        {
            Console.Write("\nРезультат: ");
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n");
        }
        
        private static void PrintResult(KeyValuePair<List<List<int>>, List<int>> result)
        {
            Console.Write("\nРезультат: ");
            foreach (var item in result.Value)
            {
                Console.Write(item);
            }
            Console.Write("\nОстатки от деления: ");
            foreach (var item in result.Key)
            {
                foreach (var num in item)
                {
                    Console.Write(num);
                }
                Console.Write(" ");
            }
            
            Console.WriteLine("\n");
        }
    }
}