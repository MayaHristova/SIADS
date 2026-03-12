using System.Diagnostics;

namespace ConsoleApp1

{

    class Timing
    {
        TimeSpan startingTime;
        TimeSpan duration;
        public Timing()
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void StopTime()
        {
            duration = Process.GetCurrentProcess().Threads[0].
            UserProcessorTime.Subtract(startingTime);
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime = Process.GetCurrentProcess().Threads[0].
            UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    internal class Program
    {
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " " : "");
            }
            Console.WriteLine();
        }

        public static void RandArray(int[] arr, int maxVal, bool allowNegative)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, maxVal + 1);
                if (allowNegative)
                {
                    arr[i] = arr[i] * (1 - 2 * rand.Next(0, 2));
                }
            }
        }

        public static void SwapValues<T>(T[] arr, int i, int j)
        {
            if (arr.Length <= i || arr.Length <= j) return;
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static int LeftChild(int i)
        {
            return 2 * i + 1; // returns index of left child
        }
        public static int RightChild(int i)
        {
            return 2 * i + 2; // returns index of right child
        }
        public static int Parent(int i)
        {
            return (i - 1) / 2; // returns index of parent node
        }

        public static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                Heapify(arr, n, largest);
            }
        }

        //BuildHeap(int[] arr): Започваме от последния вътрешен
        //възел n/2 – 1 и прилагаме Heapify.
        public static void BuildHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
        }

        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i); // build initial heap
            }
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }


        static void Main(string[] args)
        {
            /*Timing tObj = new Timing();
            Console.Write("Number elements:");//100000
            // int len = int.Parse( Console.ReadLine());
            int len;
            if (!int.TryParse(Console.ReadLine(), out len)) return;

            int[] array = new int[len];
            RandArray(array, 50, true);

            int[] arrayCopy1 = (int[])array.Clone();
            int[] arrayCopy2 = (int[])array.Clone();
            int[] arrayCopy3 = (int[])array.Clone();

            //Console.WriteLine("Array before sorting:");
            //PrintArray(array);
            tObj.StartTime();
            BubbleSort(array);
            tObj.StopTime();
            Console.WriteLine();
            Console.WriteLine("Bubble sort time: "
                + tObj.Result().TotalSeconds);
            //Console.WriteLine("Array after Bubble sort:");
            //PrintArray(array);

            *//*Console.WriteLine("Array before sorting:");
            PrintArray(arrayCopy1);*//*
            tObj.StartTime();
            HeapSort(arrayCopy1);
            tObj.StopTime();
            Console.WriteLine();
            Console.WriteLine("Heap sort time: "
                + tObj.Result().TotalSeconds);
            *//*Console.WriteLine("Array after Heap sort sort:");
            PrintArray(arrayCopy1);*/

            int capacity = 100;
            MedianStructure median = new MedianStructure(capacity);
            int[] numbers = { 5, 2, 8, 1, 7 };
            Console.WriteLine("Adding numbers and printing median after each insertion:\n");
            foreach (int num in numbers)
            {
                median.Insert(num); 
                double med = median.GetMedian();
                Console.WriteLine($"Inserted {num}, current median = {med}");
            }
        }
    }
}
