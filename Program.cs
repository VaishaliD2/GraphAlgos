using System;

namespace GraphAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Undirected Graph Representation using Adjacency List");
            //GraphRepresentation graph = new GraphRepresentation(5);
            //graph.addEdge(0, 1);
            //graph.addEdge(0, 4);
            //graph.addEdge(1, 2);
            //graph.addEdge(1, 3);
            //graph.addEdge(1, 4);
            //graph.addEdge(2, 3);
            //graph.addEdge(3, 4);

            //graph.printGraph();

            //Console.WriteLine("Directed Graph Representation using Adjacency List");
            //GraphRepresentation g = new GraphRepresentation(4);
            //g.addEdgeDirectedGraph(0, 1);
            //g.addEdgeDirectedGraph(0, 2);
            //g.addEdgeDirectedGraph(1, 2);
            //g.addEdgeDirectedGraph(2, 0);
            //g.addEdgeDirectedGraph(2, 3);
            //g.addEdgeDirectedGraph(3, 3);

            //g.printGraph();
            //g.PrintBFS(2);

            //Console.WriteLine("DFS directed graph");
            //GraphRepresentation graph1 = new GraphRepresentation(5);
            //graph1.addEdgeDirectedGraph(1, 0);
            //graph1.addEdgeDirectedGraph(0, 2);
            //graph1.addEdgeDirectedGraph(2, 1);
            //graph1.addEdgeDirectedGraph(0, 3);
            //graph1.addEdgeDirectedGraph(1, 4);

            //graph1.PrintDFS(0);

            //GraphRepresentation graphForPrimAlgousingAdjacencylistandheapTesting = new GraphRepresentation(6);
            //graphForPrimAlgousingAdjacencylistandheapTesting.addEdge(0, 1, 4);
            //graphForPrimAlgousingAdjacencylistandheapTesting.addEdge(0, 2, 3);
            //graphForPrimAlgousingAdjacencylistandheapTesting.addEdge(1, 2, 1);
            //graphForPrimAlgousingAdjacencylistandheapTesting.addEdge(1, 3, 2);
            //graphForPrimAlgousingAdjacencylistandheapTesting.addEdge(2, 3, 4);
            //graphForPrimAlgousingAdjacencylistandheapTesting.addEdge(3, 4, 2);
            //graphForPrimAlgousingAdjacencylistandheapTesting.addEdge(4, 5, 6);

            //graphForPrimAlgousingAdjacencylistandheapTesting.PrimMSTusingAdjacencyListandMinHeap();

            GraphRepresentation graphRepresentationForDisjointSets = new GraphRepresentation(6);
            graphRepresentationForDisjointSets.addEdgeDirectedGraph(0, 1);
            graphRepresentationForDisjointSets.addEdgeDirectedGraph(0, 2);
            graphRepresentationForDisjointSets.addEdgeDirectedGraph(1, 3);
            graphRepresentationForDisjointSets.addEdgeDirectedGraph(4, 5);
            graphRepresentationForDisjointSets.DisjointSets();

        }
    }
}
