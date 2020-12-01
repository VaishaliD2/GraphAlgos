using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgos
{
    public class DijkstraAlgoUsingAdjacencyListandHeap
    {
        public void DijkstraGetMinDistance(int vertices, LinkedList<Tuple<int, int>>[] adj, int sourcevertex)
        {
            //Use SPT[] to keep track of the vertices which are currently in SPT.
            bool[] SPT = new bool[vertices];

            //Create a heapNode for each vertex which will store two information.a).vertex b). key is distance 
            HeapNode[] heapNodes = new HeapNode[vertices];
            for (int i = 0; i< vertices ;i++)
            {
                heapNodes[i] = new HeapNode();
                heapNodes[i].Vertex = i;
                heapNodes[i].Key = int.MaxValue;
            }
            //decrease the distance for first index
            heapNodes[sourcevertex].Key = 0;

            //add all vertices to min heap
            MinHeap minHeap = new MinHeap(vertices);
            for(int i=0;i<vertices;i++)
            {
                minHeap.Insert(heapNodes[i]);
            }

            while(!minHeap.IsEmpty())
            {
                // extract the min 
                HeapNode minHeapNode = minHeap.ExtractMin();

                int extractedVertex = minHeapNode.Vertex;
                SPT[extractedVertex] = true;

                //iterate through all aadjacent vertices
                foreach(var item in adj[extractedVertex])
                {
                    int destination = item.Item1;
                    if(SPT[destination] == false)
                    {
                        //check if distance needs an update or not
                        //means check total weight from source to vertex_V is less than
                        //the current distance value, if yes then update the distance
                        int newKey = heapNodes[extractedVertex].Key + item.Item2;
                        int currentKey = heapNodes[destination].Key;
                        if(currentKey > newKey)
                        {
                            //  Update 
                            DecreaseKey(minHeap, newKey, destination);
                            heapNodes[destination].Key = newKey;
                        }
                    }
                }
            }
        }
        public void PrintDijkstra(HeapNode[] resultSet, int sourceVertex)
        {
            for(int i = 0;i< resultSet.Length;i++)
            {
                Console.WriteLine($"Distance from Source vertex: {sourceVertex} to vertex {i} : {resultSet[i].Key}  ");
            }
        }
        public void DecreaseKey(MinHeap minHeap, int newKey, int vertex)
        {
            //get the index which key's needs a decrease;
            int index = minHeap.indexes[vertex];

            //get the node and update its value
            HeapNode node = minHeap.mH[index];
            node.Key = newKey;
            minHeap.HeapifyFromEndToBeginning(index);
        }
    }

}
