namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[8, 3, 1, 7, 0, 10, 2]
            //[3, 1, 0, 2]       7,      [8, 10]
            //[0]   1   [3, 2]
        }

        /*
         [ < pivot | = pivot | ? | > pivot ]
             low     lt       i     gt
         */

        //[4, 2, 4, 4, 1, 4, 3]
        //[pivot = 4
        //lt = 0, i = 0, gt = 6
        //[4, 2, 4, 4, 1, 4, 3]
        // ^
        // |
        //1. arr[i] == pivot
        //  i++; lt = 0, i = 1, gt = 6
        //[4, 2, 4, 4, 1, 4, 3]
        //    ^
        //2. arr[i] = 2 < pivot
        //  swap(lt, i)
        //[2, 4, 4, 4, 1, 4, 3]
        //lt = 1, i = 2;
        //3. arr[i ]= 4 == pivot
        //  i++;
        //4. arr[i ]= 4 == pivot
        //  i++;
        //5. arr[i] = 1 < pivot
        //  swap(lt, i)
        //  [2, 1, 4, 4, 4, 4, 3]
        //lt = 2, i = 5
        //6. arr[i] = 4 == pivot
        //  i++
        //7. arr[i] = 3 < pivot
        //  swaplt, i)
        //  [2, 1, 3, 4, 4, 4, 4]
        //i > gt
        //[2, 1, 3] |   [4, 4, 4, 4] |  []
        static void QuickSort3Way(int[] arr, int low, int high)
        {
            if (low >= high)
                return;
            int lt = low;
            int gt = high;
            int pivot = arr[low];
            int i = low;
            while (i <= gt)
            {
                if (arr[i] < pivot)
                {
                    Swap(arr, lt, i);
                    lt++;
                    i++;
                }
                else if (arr[i] > pivot)
                {
                    Swap(arr, i, gt);
                    gt--;
                }
                else
                {
                    i++;
                }
            }
            QuickSort3Way(arr, low, lt - 1);
            QuickSort3Way(arr, gt + 1, high);
        }
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                // Recursively sort left part
                QuickSort(arr, low, pivotIndex - 1);
                // Recursively sort right part
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            //[8, 3, 1, 7, 0, 9, 2]
            //pivot = 2

            int pivot = arr[high];
            int i = low - 1;
            //итерации:
            //j = 0 -> 8 > 2 - нищо
            //j = 1 -> 3 > 2 - нищо
            //j = 2 -> 1 < 2
            //i = 0;
            //swap(8, 1)
            //[1, 3, 8, 7, 0, 9, 2]
            //i++
            //j = 4 -> 0 < 2
            //i = 1;
            //i = 1;
            //swap(3, 0)
            //[1, 0, 8, 7, 3, 9, 2]
            ///.................
            //[1, 0]        2       [ 7, 3, 9, 8]
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;
            return i + 1;
        }


        static int QuickSelect(int[] arr, int low, int high, int k)
        {
            if (low == high)
                return arr[low];
            int pivotIndex = PartitionSelect(arr, low, high);
            if (k == pivotIndex)
                return arr[k];
            else if (k < pivotIndex)
                return QuickSelect(arr, low, pivotIndex - 1, k);
            else
                return QuickSelect(arr, pivotIndex + 1, high, k);
        }
        static int PartitionSelect(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr, i, j);
                    i++;
                }
            }
            Swap(arr, i, high);
            return i;
        }
        //[7, 10, 4, 3, 20, 21, 15] k = 3
        //pivot = 15
        //[7, 10, 4, 3]     15  [20, 21]
        //pivotIndex = 4
        //[]    3   [7, 10, 4]
        //pivotIndex = 0
        //pivot = 4
        //[]    4   [7, 10]
        //pivotIndex = 1
        //pivot = 10
        //[7]   10  []
        //[7, 10, 4, 3,      15,     20, 21]
        //[3,       7, 10, 4,        15,         20, 21]
        //[3,       4,       7, 10,      15,        20, 21]
        //[3,       4,       7,     10,      15,        20, 21]



    }
}
