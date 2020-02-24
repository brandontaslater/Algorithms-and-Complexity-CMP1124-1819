using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoFiles
{
    //Heap Sort
    class HeapSortSortDataFiles
    {
        private int heapSize; //size of heap

        //builds starting heap
        private void BuildHeap(ref string[,] FileHolder1, int Position, int size, ref int OperationCount)
        {
            heapSize = size-1;

            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(ref FileHolder1, i, Position, size, ref OperationCount);
            }
        }

        //function to swap elements
        private void Swap(ref string[,] FileHolder1, int x, int y, int Position, int size, ref int OperationCount)
        {
            string[] TempHolder = new string[11];
            OperationCount++;
            for (int i = 0; i < 11; i++)
            {
                TempHolder[i] = FileHolder1[i, x];
                FileHolder1[i, x] = FileHolder1[i, y];
                FileHolder1[i, y] = TempHolder[i];
            }
        }

        //checks elements 
        private void Heapify(ref string[,] FileHolder1, int index, int Position, int size, ref int OperationCount)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;
            if (Position != 8)
            {
                if (left <= heapSize && Convert.ToDouble(FileHolder1[Position, left].Replace(":", "")) > Convert.ToDouble(FileHolder1[Position, index].Replace(":", ""))) //checks two element for comparison 
                {
                    largest = left;
                }

                if (right <= heapSize && Convert.ToDouble(FileHolder1[Position, right].Replace(":", "")) > Convert.ToDouble(FileHolder1[Position, largest].Replace(":", ""))) //checks two element for comparison 
                {
                    largest = right;
                }
                if (largest != index)
                {
                    Swap(ref FileHolder1, index, largest, Position, size,  ref OperationCount ); //swaps values given 
                    Heapify(ref FileHolder1, largest, Position, size, ref OperationCount); //recalls this method 
                }
            }
            else
            {
                if (left <= heapSize && 0 < (FileHolder1[Position, left].Replace(",", "").CompareTo(FileHolder1[Position, index].Replace(",", "")))) //checks two element for comparison
                {
                    largest = left; //changes largest value to left 
                }

                if (left <= heapSize && 0 < (FileHolder1[Position, right].Replace(",", "").CompareTo(FileHolder1[Position, largest].Replace(",", "")))) //checks two element for comparison
                {
                    largest = right; //changes largest value to right 
                }
                if (largest != index)
                {
                    Swap(ref FileHolder1, index, largest, Position, size, ref OperationCount); //swaps values given
                    Heapify(ref FileHolder1, largest, Position, size, ref OperationCount); //recalls this method
                }
            }
        }

        //first method called
        public void PerformHeapSort(ref string[,] FileHolder1, int Position, int size, ref int OperationCount)
        {
            BuildHeap(ref FileHolder1, Position, size, ref OperationCount); //builds the heap
            for (int i = size-1; i >= 0; i--)
            {
                Swap(ref FileHolder1, 0, i, Position, size, ref OperationCount); //swaps elements given 
                heapSize--; //decrements heapsize
                Heapify(ref FileHolder1, 0, Position, size, ref OperationCount); //checks new elements 
            }
        }

    }
}
