using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static List<int> list = new List<int>();

        static string Menu()
        {
            string menuOptions =
                "P - Print numbers\n" +
                "A - Add a number\n" +
                "B - Add more than one number\n" +
                "M - Display mean of the numbers\n" +
                "S - Display the smallest number\n" +
                "L - Display the largest number\n" +
                "D - Search for the number\n" +
                "T - Sort the List\n" +
                "R - Replace a number\n" +
                "X - Remove a specific number\n" +
                "C - Clear the List\n" +
                "Q - Quit\n\n" +
                "Enter your choice:";
            return menuOptions;
        }

        static string Print()
        {
            if (list.Count == 0)
                return "[] - The list is empty";
            else
            {
                string result = "";
                for (int i = 0; i < list.Count; i++)
                {
                    result += $"Number at index {i}: {list[i]}\n";
                }
                return result;
            }
        }
        static void AddMore(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Number of index {i}:");
                int numbers = int.Parse(Console.ReadLine());
                if (!list.Contains(numbers))
                {
                    list.Add(numbers);
                }
                else
                {
                    Console.WriteLine("Duplicate number found and ignored.");
                }
            }
        }

        static string Add(int number)
        {
            
            if (list.Contains(number))
            {
                return "This number already exists.\n";
            }
            else
            {
                list.Add(number);
                return $"Number {number} added to the list.\n";
            }
        }

        static double Mean()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Unable to calculate the mean - no data");
                return 0;
            }
            else
            {
                double sum = 0;
                foreach (int num in list)
                {
                    sum += num;
                }
                return sum / list.Count;
            }
        }

        static int Small()
        {
            if (list.Count == 0)
            {              
                return 0;
            }
            else
            {
                int small = list[0];
                foreach (int num in list)
                {
                    if (num < small)
                    {
                        small = num;
                    }
                }
                return small;
            }
        }

        static int Larg()
        {
            if (list.Count == 0)
            {               
                return 0;
            }
            else
            {
                int large = list[0];
                foreach (int num in list)
                {
                    if (num > large)
                    {
                        large = num;
                    }
                }
                return large;
            }
        }

        static int Search(int number)
        {
            int index = list.IndexOf(number);
            return index;
        }

        static string Clear()
        {
            list.Clear();
            return "List cleared.\n";
        }

        static string Replace(int old, int New)
        {

            int index = list.IndexOf(old);
            if (index == -1)
            {
                return "This old number was not found.";
            }
            if (list.Contains(New))
            {
                return "The new number already exists in the list.";
            }
            else
            {
                list[index] = New;
                return "Replacement done.";
            }
        }
            
        
        static string Sort()
        {
            if (list.Count == 0)
                return "[] - The list is empty";
            int temp = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return $"Sorted done :\n {Print()}";
        }

        static int Removed(int number)
        {
            
            if (list.Remove(number))
            {
                return number;
            }
            else
            {
                return 0;
            }
           
        }

        static void Main(string[] args)
        {
            char choice;
            do
            {
                Console.WriteLine(Menu());
                choice = char.ToUpper(char.Parse(Console.ReadLine()));
                switch (choice)
                {
                    case 'P':
                        string print = Print();
                        Console.WriteLine(print);
                        break;
                    case 'A':
                        Console.WriteLine("Enter the number you want to add:");
                        int number = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine(Add(number));
                        break;
                    case 'B':
                        Console.WriteLine("How many numbers do you want to add?");
                        int numbers = int.Parse(Console.ReadLine());
                        AddMore(numbers);
                        break;
                    case 'M':
                        double mean = Mean();
                        if(mean==0)
                            Console.WriteLine("Unable to calculate the mean - no data");
                        else
                            Console.WriteLine($"Mean: {mean}");
                        break;
                    case 'S':
                        int small = Small();
                        if(small==0)
                            Console.WriteLine("Unable to determine the smallest number - list is empty");
                        else
                            Console.WriteLine($"Smallest number: {small}");
                        break;
                    case 'L':
                        int larg = Larg();
                        if (larg==0)
                            Console.WriteLine("Unable to determine the largest number - list is empty");
                        else
                           Console.WriteLine($"Largest number: {larg}");
                        break;
                    case 'D':
                        Console.WriteLine("Enter the number you want to search for:");
                        int number2 = int.Parse(Console.ReadLine());
                        int index = Search(number2);
                        if (index == -1)
                            Console.WriteLine("The number was not found.\n");
                        else
                            Console.WriteLine($"{number2} found at index: {index}");
                        break;
                    case 'C':
                        Console.WriteLine(Clear());
                        break;
                    case 'R':
                        Console.WriteLine("Enter the old number:");
                        int old = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new number:");
                        int New = int.Parse(Console.ReadLine());
                        string replace = Replace(old, New);
                        Console.WriteLine(replace);
                        break;
                    case 'T':
                        string sort = Sort();                       
                        Console.WriteLine(sort);
                        break;
                    case 'X':
                        Console.WriteLine("Enter the number you want to remove:");
                        int numberToRemove = int.Parse(Console.ReadLine());
                        int removed = Removed(numberToRemove);
                        if (removed == 0)
                            Console.WriteLine($"{numberToRemove} was not found.\n");
                        else
                            Console.WriteLine($"{numberToRemove} has been removed.\n");
                        break;
                    default:
                        if (choice != 'Q')
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                        break;
                }
            } while (choice != 'Q');
            Console.WriteLine("Goodbye");
        }
    }
}
