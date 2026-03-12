using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MaxHeap
    {
        private int[] heap;
        private int size;
        public MaxHeap(int capacity)
        {
            heap = new int[capacity];
            size = 0;
        }
        public int Size()
        {
            return size;
        }
        public int Peek()
        {
            return heap[0];
        }
        public void Insert(int value)
        {
            heap[size] = value;
            int i = size;
            size++;
            // bubble up
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (heap[parent] >= heap[i])
                    break;
                int temp = heap[parent];
                heap[parent] = heap[i];
                heap[i] = temp;
                i = parent;
            }
        }
        public int ExtractMax()
        {
            int root = heap[0];
            heap[0] = heap[size - 1];
            size--;
            Heapify(0);
            return root;
        }
        private void Heapify(int i)
        {
            while (true)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int largest = i;
                if (left < size && heap[left] > heap[largest])
                    largest = left;
                if (right < size && heap[right] > heap[largest])
                    largest = right;
                if (largest == i)
                    break;
                int temp = heap[i];
                heap[i] = heap[largest];
                heap[largest] = temp;
                i = largest;
            }
        }
    }

}
