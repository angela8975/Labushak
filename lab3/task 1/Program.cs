namespace task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            int[] arr = new int[0];

            Console.WriteLine("Выберите способ ввода массива:");
            Console.WriteLine("1 - From file");
            Console.WriteLine("2 - From keyboard");
            Console.WriteLine("3 - Fill random numbers");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the path to the file : ");
                    string FilePath = Console.ReadLine();
                    if (File.Exists(FilePath))
                    {
                        string[] lines = File.ReadAllLines(FilePath);
                        arr = Array.ConvertAll(lines[0].Split(), int.Parse);
                        size = arr.Length;
                    }
                    else
                    {
                        Console.WriteLine("File not exist");
                        return;
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter array size: ");
                    size = int.Parse(Console.ReadLine());
                    arr = new int[size];
                    Console.WriteLine("Input elements of array separeted by enter: ");
                    arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    break;


                case 3:
                    size = 50;
                    Random rnd = new Random();
                    arr = new int[size];
                    for (int i = 0; i < size; ++i)
                    {
                        arr[i] = rnd.Next(-100, 100);
                    }
                    break;


                default:
                    Console.WriteLine("Wrong choise");
                    return;
                    
            }

            Console.WriteLine("Original array:");
            for (int i = 0; i < size; ++i)
            {
                Console.Write(arr[i] + " ");
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }

                int max = arr[0];
                int maxIndex = 0;

                for (int k = 0; k < size; ++k)
                {
                    if (arr[k] > max)
                    {
                        max = arr[k];
                        maxIndex = k;
                    }
                }

                Console.WriteLine($"\nMax = {max} at index {maxIndex}");

                int negativeCount = 0;
                int secondNegativeIndex = -1;

                for (int j = 0; j < size; ++j)
                {
                    if (arr[j] < 0)
                    {
                        negativeCount++;
                    }
                    if (negativeCount == 2)
                    {
                        secondNegativeIndex = j;
                        break;
                    }
                }

                if (secondNegativeIndex != -1)
                {
                    Console.WriteLine($"Second negative number = {arr[secondNegativeIndex]} at index {secondNegativeIndex}");

                    int temp = arr[maxIndex];
                    arr[maxIndex] = arr[secondNegativeIndex];
                    arr[secondNegativeIndex] = temp;

                    Console.WriteLine("\nArray after permutation:");
                    for (int m = 0; m < size; ++m)
                    {
                        Console.Write(arr[m] + " ");
                        if ((m + 1) % 10 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no second negative number in the array. No swapping was done.");
                }
            }
        }
    }

