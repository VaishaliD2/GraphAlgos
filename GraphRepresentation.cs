using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphAlgos
{
    /// <summary>
    /// Graph representation Using Adjacency List 
    /// </summary>
    public class GraphRepresentation
    {
        private readonly int NoOfVertices;
        private readonly LinkedList<Tuple<int,int>>[] adj;
        private readonly List<Edge> edges;
        public GraphRepresentation(int vertices)
        {
             NoOfVertices = vertices;
             adj = new LinkedList<Tuple<int, int>>[vertices];
            edges = new List<Edge>();
            for (int i = 0; i < vertices; i++)
                adj[i] = new LinkedList<Tuple<int, int>>();
        }

        /// <summary>
        ///  A utility function to add an edge in an undirected graph  
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        public void addEdge(int u, int v, int weight = 0)
        {
            adj[u].AddLast(new Tuple<int,int>(v,weight));
            Edge edge1 = new Edge(u, v, weight);
            edges.Add(edge1);
            adj[v].AddLast(new Tuple<int, int>(u, weight));
            Edge edge2 = new Edge(v, u, weight);
            edges.Add(edge2);
        }

        /// <summary>
        /// A utility function to add an edge in an directed graph
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void addEdgeDirectedGraph(int start, int end, int weight = 0)
        {
            adj[start].AddLast(new Tuple<int,int>(end,weight));
            Edge edge = new Edge(start, end, weight);
            edges.Add(edge);
        }


        /// <summary>
        /// A utility function to print the adjacency list representation of graph  
        /// </summary>
        public void printGraph()
        {
            for (int i = 0; i < adj.Length; i++)
            {
                Console.WriteLine("\nAdjacency list of vertex " + i);
                Console.Write("head");

                foreach (var item in adj[i])
                {
                    Console.Write($" -> {item.Item1} ({item.Item2})");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Print DFS Traversal from given source
        /// </summary>
        /// <param name="s"></param>
        public void PrintDFS(int s)
        {
            //Mark all vertices as not visited by default
            bool[] visited = new bool[NoOfVertices];

            // Create a Stack for BFS
            Stack<int> dfsStack = new Stack<int>();

           
            dfsStack.Push(s);

            while(dfsStack.Any())
            {
                //Pop a vertex from stack and print it
                s =  dfsStack.Peek();
                dfsStack.Pop();

                //stack may contain same vertex twice So print popped item only if not visited
                if(visited[s] == false)
                {
                    Console.Write($"{s} ");
                    visited[s] = true;
                }
                // Get all adjacent vertices of the popped vertex s If a adjacent has not been visited, then push it 
                
                foreach (var item in adj[s])
                {
                    if (!visited[item.Item1])
                        dfsStack.Push(item.Item1);

                }
            }
        }

        /// <summary>
        /// Print BFS Traversal from given source
        /// </summary>
        /// <param name="s"></param>
        public void PrintBFS(int s)
        {
            //Mark all vertices as not visited by default
            bool[] visited = new bool[NoOfVertices];

            // Create a Queue for BFS
            Queue<int> bfsQueue = new Queue<int>();

            //Mark current node as visited and enqueue it
            visited[s] = true;
            bfsQueue.Enqueue(s);

            while(bfsQueue.Any())
            {
                // Dequeue a vertex from Queue and print it
                s = bfsQueue.Dequeue();
                Console.Write($"{s} ");

                // Get all adjacent vertices of dequeued vertex
                var iterator = adj[s].GetEnumerator();
                while(iterator.MoveNext())
                {
                    int n = iterator.Current.Item1;
                    if(!visited[n])
                    {
                        visited[n] = true;
                        bfsQueue.Enqueue(n);
                    }
                }
            }

        }

        /*After an enumerator is created, the enumerator is positioned before the first element in the collection, and the first call to MoveNext advances the enumerator to the first element of the collection.

       If MoveNext passes the end of the collection, the enumerator is positioned after the last element in the collection and MoveNext returns false. When the enumerator is at this position, subsequent calls to MoveNext also return false.

       An enumerator remains valid as long as the collection remains unchanged. If changes are made to the collection, such as adding, modifying, or deleting elements, the enumerator is irrecoverably invalidated and the next call to MoveNext throws an InvalidOperationException.
       */
      


        /// <summary>
        /// Topological Sort
        /// </summary>
        public void TopologicalSort()
        {
            TopologicalSorting s = new TopologicalSorting();
            s.TopologicalSort(NoOfVertices, adj);
        }


        public void PrimMSTusingAdjacencyListandMinHeap()
        {
            PrimsAlgoUsingAdjacencyListandHeap primsAlgoUsingAdjacencyListandHeap = new PrimsAlgoUsingAdjacencyListandHeap();
            primsAlgoUsingAdjacencyListandHeap.PrimMST(NoOfVertices, adj);
        }

        public void DisjointSets()
        {
            DisjointSets sets = new DisjointSets();
            sets.disjointSets(NoOfVertices, adj,edges);

        }
    }

    public class Edge
    {
        public Edge(int source, int destination,int weight)
        {
            this.Source = source;
            this.Destination = destination;
            this.Weight = weight;
        }
       public int Source { get; set; }

        public int Destination { get; set; }

        public int Weight { get; set; }


    }
}
