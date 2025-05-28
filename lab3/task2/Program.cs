using System.Dynamic;
using System.Runtime.InteropServices;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter arry size (n*n): ");
            int n = int.Parse(Console.ReadLine());
            int[,] array= new int[n,n];

            Console.WriteLine("Chose arry input method: ");
            Console.WriteLine("1 - From file.");
            Console.WriteLine("2 - Manually.");
            Console.WriteLine("3 - Randome.");
            Console.Write("Your choice: ");

            int choise = int.Parse(Console.ReadLine());


            switch (choise) {
                case 1:
                    array = ReadArrFromFile(n); 
                    break;
                case 2:
                    array = InputArrManually(n); 
                    break;
                case 3:
                    array = GenRandomArr(n); 
                    break;
                default:
                    Console.WriteLine("Invalid choice. A random array will be used.");
                    array = GenRandomArr(n);
                    break;

            }
            Console.WriteLine("\nSource array: ");
            PrintArr(array);

            
            int difference = CalculateDifference(array);
            Console.WriteLine($"\nThe difference between the sums of the first and second halves of the array elements: {difference}");

            
            SortElementsAfterMax(array);

           
            Console.WriteLine("\nArray after sorting elements after the maximum in each row: ");
            PrintArr(array);

            static int[,] ReadArrFromFile(int n)
            {
                int[,]array = new int[n,n];
                Console.Write("Enter the path to the file: ");
                string path = Console.ReadLine();

                try
                {
                    string[] lines = File.ReadAllLines(path);
                    if (lines.Length < n)
                    {
                        Console.WriteLine("Not enough lines in file. Random array will be used.");
                        return GenRandomArr(n);
                    }
                    for (int i = 0; i < n; i++)
                    {
                        string[] values = lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (values.Length < n)
                        {
                            Console.WriteLine($"Not enough values ​​in row {i + 1}. A random array will be used.");
                            return GenRandomArr(n);


                        }
                        for (int j = 0; j < n; j++)
                        {
                            array[i, j] = int.Parse(values[j]);

                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error reading file: {ex.Message}. A random array will be used.");
                    return GenRandomArr(n);
                
                }

                return array;
            }
            static int[,] GenRandomArr(int n) {
                int[,]array= new int[n,n];
                Random rnd = new Random();
                for(int i = 0; i < n; ++i)
                {
                    for(int j = 0; j < n; ++j)
                    {
                        array[i, j] = rnd.Next(-100, 100);
                    }
                }

                return array;
            }
            static int[,] InputArrManually(int n) {
                int[,] array = new int[n, n];
                Console.WriteLine("Enter your arry {n}×{n} : ");
                for (int i = 0; i < n; ++i)
                {
                    Console.WriteLine($"Line {i + 1}:");
                    for (int j = 0; j < n; ++j)
                    {
                        Console.Write($"[{i},{j}]: ");
                        array[i,j] = int.Parse(Console.ReadLine());
                    }
                }

                return array;
            }
            static void PrintArr(int[,] array)
            {
                int n = array.GetLength(0);
                for (int i = 0;i < n; ++i)
                {
                    for (int j = 0;j < n; ++j)
                    {
                        Console.WriteLine($"{array[i, j],5}");
                    }
                    Console.WriteLine();
                }
            }
            static int CalculateDifference(int[,] array)
            {
                int n = array.GetLength(0);
                int totalelements = n* n;
                int halfelements = totalelements / 2;

                int firstHalfSum = 0;
                int secondHalfSum = 0;
                int count = 0;

                for (int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        if (count< halfelements)
                        {
                            firstHalfSum += array[i, j];
                        } else
                        {
                            secondHalfSum += array[i, j];
                        }
                        count++;
                    }
                }


                return firstHalfSum - secondHalfSum;
            }
            static void SortElementsAfterMax(int[,] array)
            {
                int n = array.GetLength(0);


                for (int i = 0; i < n; i++)
                {

                    int maxIndex = 0;
                    int maxValue = array[i, 0];


                    for (int j = 1; j < n; j++)
                    {
                        if (array[i, j] > maxValue)
                        {
                            maxValue = array[i, j];
                            maxIndex = j;
                        }
                    }


                    if (maxIndex < n - 1)
                    {

                        int[] elementsAfterMax = new int[n - maxIndex - 1];


                        for (int j = 0; j < elementsAfterMax.Length; j++)
                        {
                            elementsAfterMax[j] = array[i, maxIndex + 1 + j];
                        }


                        Array.Sort(elementsAfterMax);


                        Array.Reverse(elementsAfterMax);

                        for (int j = 0; j < elementsAfterMax.Length; j++)
                        {
                            array[i, maxIndex + 1 + j] = elementsAfterMax[j];
                        }
                    }
                }
            }
        }
    }
}
