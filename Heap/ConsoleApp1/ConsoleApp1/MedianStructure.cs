using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MedianStructure
    {
        private MaxHeap left;
        private MinHeap right;
        public MedianStructure(int capacity)
        {
            left = new MaxHeap(capacity);
            right = new MinHeap(capacity);
        }
        public void Insert(int value)
        {
            if (left.Size() == 0 || value <= left.Peek())
                left.Insert(value);
            else
                right.Insert(value);
            // balance heaps
            if (left.Size() > right.Size() + 1)
            {
                int moved = left.ExtractMax();
                right.Insert(moved);
            }
            else if (right.Size() > left.Size())
            {
                int moved = right.ExtractMin();
                left.Insert(moved);
            }
        }
        public double GetMedian()
        {
            if (left.Size() > right.Size())
                return left.Peek();
            return (left.Peek() + right.Peek()) / 2.0;
        }
    }

}
