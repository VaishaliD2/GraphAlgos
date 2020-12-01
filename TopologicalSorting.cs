using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphAlgos
{
    /// <summary>
    /// Topological sorting for Directed Acyclic Graph (DAG) is a linear ordering of vertices such that for every directed edge uv, vertex u comes before v in the ordering.
    /// Topological Sorting for a graph is not possible if the graph is not a DAG.
    /// </summary>
    public class TopologicalSorting
    {

        public void TopologicalSort(int vertices, LinkedList<Tuple<int, int>>[] adj)
        {
            //Mark all vertices as not visited by default
            bool[] visited = new bool[vertices];

            // Create a Stack 
            Stack<int> stack = new Stack<int>();

            // Call the recursive helper function to store  
            // Topological Sort starting from all vertices  
            // one by one  
            for (int i = 0; i < vertices; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack, adj);
            }

            //Print contents of stack
            while(stack.Any())
            {
                Console.Write(stack.Pop());
            }
        }

        private void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack, LinkedList<Tuple<int, int>>[] adj)
        {
            //Mark current node as visited
            visited[v] = true;

            //Recur for all vertices adjacent to this
            foreach(var item in adj[v])
            {
                if (!visited[item.Item1])
                {
                    TopologicalSortUtil(item.Item1, visited, stack, adj);
                }
            }

            //Push Current vertex to stack which stores result
            stack.Push(v);
        }

        public void TopologicalSortusingKahnAlgorithm(int vertices, LinkedList<Tuple<int, int>>[] adj)
        {
            // Create a array to store indegrees of all vertices. Initialize all indegrees as 0. and 
            //Traverse adjacency lists to fill indegrees of vertices. This step takes O(V+E) time 

            int[] indegree = FindInDegreeofEachvertex(vertices,adj);

            // Create a queue and enqueue all vertices with indegree 0 
            Queue<int> queue = new Queue<int>();
            for(int i=0;i<vertices;i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(indegree[i]);
            }

            // Initialize count of visited vertices 
            int cnt = 0;


            // Create a vector to store result (A topological ordering of the vertices) 
            List<int> topoSort = new List<int>();
            while(queue.Any())
            {
                //Extract front of queue(or perform dequeue)and add it to topological order 
                int u = queue.Dequeue();
                topoSort.Add(u);

                // Iterate through all its neighbouring nodes of dequeued node u and decrease their in-degree by 1 
                foreach(var item in adj[u])
                {
                    if(--indegree[item.Item1] == 0)
                    {
                        queue.Enqueue(item.Item1);
                    }
                }
                cnt++;
            }

            // Check if there was a cycle         
            if (cnt != vertices)
            {
                Console.WriteLine("There exists a cycle in the graph");
                return;
            }
            //Print TopoOrder
            foreach(var item in topoSort)
            {
                Console.Write($"{item} ");
            }
        }
        /// <summary>
        /// Find in degree of each vertex
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="adj"></param>
        public int[] FindInDegreeofEachvertex(int vertices, LinkedList<Tuple<int, int>>[] adj)
        {
            int[] iN = new int[vertices];
            int[] ouT = new int[vertices];

            for (int i = 0; i < adj.Count(); i++)
            {
                var list = adj[i];
                // Out degree for ith vertex will be the count of direct paths from i to other vertices 
                ouT[i] = list.Count;

                for (int j = 0; j < list.Count; j++)
                {
                    // Every vertex that has an incoming edge from i 
                    iN[list.ElementAt(j).Item1]++;
                }
            }
            return iN;
        }


        public int[] FindOutDegreeOfEachVertex(int vertices, LinkedList<Tuple<int, int>>[] adj)
        {
            int[] ouT = new int[vertices];
            for (int i = 0; i < adj.Count(); i++)
            {
                var list = adj[i];
                // Out degree for ith vertex will be the count of direct paths from i to other vertices 
                ouT[i] = list.Count;
            }
            return ouT;
        }


    }
}
