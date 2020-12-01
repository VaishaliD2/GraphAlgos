using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgos
{
    public class KruskalsAlgo
    {
        public void KrusKalMST(int vertices, LinkedList<Tuple<int, int>>[] adj, List<Edge> edges)
        {
            Edge[] result = new Edge[vertices];
            OptimizedDisjointSets optimizedDisjointSets = new OptimizedDisjointSets();
            //Sort edges by weight

            edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));

            //create subsets []
            SubSet[] subSets = new SubSet[vertices];

            //makeset
            optimizedDisjointSets.MakeSet(subSets);
            int i = 0;// Index used to pick next edge
            int e = 0; // Index used for result
            while (e < vertices - 1)
            {
                var nextEdge = edges[i];
                int xroot = optimizedDisjointSets.Find(subSets, nextEdge.Source);
                int yroot = optimizedDisjointSets.Find(subSets, nextEdge.Destination);
                i++;
                if(xroot != yroot )
                {
                    // no cycle so do union
                    result[e++] = nextEdge;
                    optimizedDisjointSets.Union(subSets, xroot, yroot);
                  
                }
                // else discard the edge              
            }

            //Print 
            for(int j = 0; j < e; ++j )
            {
                Console.WriteLine(result[i].Source + " -- " +
               result[i].Destination + " == " + result[i].Weight);
                Console.ReadLine();

            }
        }
       
    }
}
