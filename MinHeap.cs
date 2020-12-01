using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgos
{
    public class MinHeap
    {
        int capacity;
        int currentSize;
        public HeapNode[] mH;
        public int[] indexes; // will be used to decrease key

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            mH = new HeapNode[capacity];
            indexes = new int[capacity];
            mH[0] = new HeapNode();
            mH[0].Key = int.MinValue;
            mH[0].Vertex = -1;
            currentSize = 0;
        }

        public void Insert(HeapNode x)
        {
            int idx = currentSize;
            mH[idx] = x;
            indexes[x.Vertex] = idx;
            HeapifyFromEndToBeginning(idx);
            currentSize++;
        }

        public void HeapifyFromEndToBeginning(int pos)
        {
            if (pos >= mH.Length) return;
            int parentPos = (pos-1)/ 2;
            int currentidx = pos;
            while (currentidx > 0 && mH[parentPos].Key > mH[currentidx].Key)
            {
                HeapNode currentNode = mH[currentidx];
                HeapNode parentNode = mH[parentPos];

                //swap the positions
                indexes[currentNode.Vertex] = parentPos;
                indexes[parentNode.Vertex] = currentidx;
                Swap(currentidx, parentPos);

                currentidx = parentPos;
                parentPos = (parentPos- 1 )/ 2;
            }
        }

        public HeapNode ExtractMin()
        {
            HeapNode min = mH[0];
            HeapNode lastNode = mH[currentSize - 1];
            // Update the indexes[] and move the last node to the top
            indexes[lastNode.Vertex] = 0;
            mH[0] = lastNode;
            mH[currentSize - 1] = null;
            currentSize--;
            HeapifyFromBeginningToEnd(0);         
            return min;
        }

        public void HeapifyFromBeginningToEnd(int pos)
        {
            if (pos >= mH.Length)
                return;

            int smallest = pos;
            int left = 2 * pos + 1;
            int right = 2 * pos + 2;

            if (left < currentSize && mH[smallest].Key > mH[left].Key)
                smallest = left;
            if (right < currentSize && mH[smallest].Key > mH[right].Key)
                smallest = right;

            if (smallest != pos)
            {
                HeapNode smallestNode = mH[smallest];
                HeapNode posNode = mH[pos];

                //swap the positions
                indexes[smallestNode.Vertex] = pos;
                indexes[posNode.Vertex] = smallest;
                Swap(pos, smallest);
                HeapifyFromBeginningToEnd(smallest);
            }
        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        public int GetHeapSize()
        {
            return currentSize;
        }

        public void Display()
        {
            for (int i = 0; i <= currentSize; i++)
            {
                Console.WriteLine(" " + mH[i].Vertex + "   key   " + mH[i].Key);
            }
            Console.WriteLine("________________________");
        }
        private int GetRightChildIndex(int index)
        {
            if (((2 * index) + 2) < mH.Length && (index >= 1))
                return (2 * index) + 2;
            return -1;
        }

        private int GetLeftChildIndex(int index)
        {
            if ((2 * index + 1) < mH.Length && (index >= 1))
                return 2 * index + 1;
            return -1;
        }

        private int GetParent(int index)
        {
            if ((index > 1) && (index < mH.Length))
            {
                return index / 2;
            }
            return -1;
        }
        private void Swap(int pos1, int pos2)
        {
            HeapNode temp = mH[pos1];
            mH[pos1] = mH[pos2];
            mH[pos2] = temp;
        }


    }
    public class HeapNode
    {
        public int Vertex { get; set; }
        public int Key { get; set; }
    }

}
