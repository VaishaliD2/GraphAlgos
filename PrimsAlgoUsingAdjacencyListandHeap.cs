using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgos
{
    public class PrimsAlgoUsingAdjacencyListandHeap
    {
        public void PrintPrimMst(ResultSet[] resultSet)
        {
            int totalMinWeight = 0;
            Console.WriteLine("Minimum Spanning Tree");
            for(int i = 1; i< resultSet.Length; i++)
            {
                Console.WriteLine($"Edge {i} - {resultSet[i].Parent} weight: {resultSet[i].Weight}");
                totalMinWeight += resultSet[i].Weight;
            }
        }

        public void PrimMST(int vertices, LinkedList<Tuple<int, int>>[] adj)
        {
            ResultSet[] resultSet = new ResultSet[vertices];


            //Use inHeap[] to keep track of the vertices which are currently in min heap.
            bool[] inHeap = new bool[vertices];

            //keys used to store the key to know whether min heap update is required
            //Create key[] to keep track of key value for each vertex. (keep updating it as heapNode key for each vertex)
            int[] key = new int[vertices];

            //Create a heapNode for each vertex which will store two information.a).vertex b). key
            HeapNode[] heapNodes = new HeapNode[vertices];
            for (int i = 0; i < vertices; i++)
            {
                heapNodes[i] = new HeapNode();
                heapNodes[i].Vertex = i;
                heapNodes[i].Key = int.MaxValue;
                resultSet[i] = new ResultSet();
                resultSet[i].Parent = -1;
                inHeap[i] = true;
                key[i] = int.MaxValue;
            }

            heapNodes[0].Key = 0;

            //add all the vertices to the MinHeap
            //Create min Heap of size = no of vertices.
            MinHeap minHeap = new MinHeap(vertices);
            //add all the vertices to priority queue
            for (int i = 0; i < vertices; i++)
            {
                minHeap.Insert(heapNodes[i]);
            }

            while (!minHeap.IsEmpty())
            {
                // extract the min
                HeapNode extractedNode = minHeap.ExtractMin();
                int extractedVertex = extractedNode.Vertex;

                inHeap[extractedVertex] = false;

                foreach (var item in adj[extractedVertex])
                {
                    int destination = item.Item1;
                    int newKey = item.Item2;// weight
                    //only if edge destination is present in heap
                    if (inHeap[destination])
                    { 
                        //check if updated key < existing key, if yes, update it
                        if(key[destination]>newKey)
                        {
                            DecreaseKey(minHeap, newKey, destination);
                            //update parent node for destination
                            resultSet[destination].Parent = extractedVertex;
                            resultSet[destination].Weight = newKey;
                            key[destination] = newKey;
                        }
                    }
                }
            }

            PrintPrimMst(resultSet);
        }

        public void DecreaseKey(MinHeap minHeap,int newKey, int vertex)
        {
            //get the index which key's needs a decrease;
            int index = minHeap.indexes[vertex];

            //get the node and update its value
            HeapNode node = minHeap.mH[index];
            node.Key = newKey;
            minHeap.HeapifyFromEndToBeginning(index);
        }
    }

    public class ResultSet
    {
        public int Parent { get; set; }
        public int Weight { get; set; }
    }



}
