namespace ConsoleApp1
{
    internal class Program
    {

        //T(n) = T(n - 1) + O(1)
        static int Factorial(int n)
        {
            // Base case: stop recursion
            if (n == 0)
                return 1;
            // Recursive call with smaller problem
            return n * Factorial(n - 1);
        }
        static void GenerateSubsets(int[] arr, int[] subset, int index,
            int subsetSize)
        {
            if (index == arr.Length)
            {
                for (int i = 0; i < subsetSize; i++)
                    Console.Write(subset[i] + " ");
                Console.WriteLine();
                return;
            }
            GenerateSubsets(arr, subset, index + 1, subsetSize);
            subset[subsetSize] = arr[index];
            GenerateSubsets(arr, subset, index + 1, subsetSize + 1);
        }

        static int LIS(int[] arr, int index, int prev)
        {
            if (index == arr.Length)
                return 0;
            int include = 0;
            if (arr[index] > prev)
                include = 1 + LIS(arr, index + 1, arr[index]);
            int exclude = LIS(arr, index + 1, prev);
            return Math.Max(include, exclude);
        }

        static void Main(string[] args)
        {
            /*int n = 5;
            int result = Factorial(n);
            Console.WriteLine("Factorial of " + n + " = " + result);*/

            /*int[] arr = { 1, 2, 3 };
            int[] subset = new int[arr.Length];
            GenerateSubsets(arr, subset, 0, 0);*/

            int[] arr = { 3, 10, 2, 20 };
            int result = LIS(arr, 0, int.MinValue);
            Console.WriteLine(result);

        }
    }
}
