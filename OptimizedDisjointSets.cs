using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgos
{
    public class OptimizedDisjointSets
    {

        public bool isCycle(int vertices, List<Edge> edges)
        {

        }
        public void DisjointSets(int vertices, LinkedList<Tuple<int,int>>[] adj, List<Edge> edges)
        {
            //create a parent []
            SubSet[] subSets = new SubSet[vertices];

            //makeset
            MakeSet(subSets);

            //iterate through all the edges and keep making the sets (union the sets)
            foreach (var item in edges)
            {
                int xSet = Find(subSets, item.Source);
                int ySet = Find(subSets, item.Destination);
                //check if source vertex and destination vertex belongs to the same set
                // if in same set then cycle has been detected else combine them into one set
                if (xSet == ySet)
                {
                    // cycle 
                }
                else
                {
                    Union(subSets, xSet, ySet);
                }
            }

            PrintSets(subSets);
        }
        public void MakeSet(SubSet[] subsets)
        {
            //This operation makes a new set by creating a new element of rank of 0 with a parent pointer to itself. 
            //The parent pointer to itself indicates that the element is the representative member of its own set.
            //The MakeSet operation has O(1) time complexity.
            //Make set- creating a new element with a parent pointer to itself.
            // no of vertices = parent.length
            for (int i = 0; i < subsets.Length; i++)
            {
                subsets[i] = new SubSet();
                subsets[i].parent = i;
                subsets[i].rank = 0;

            }
        }
        // Union By Rank
        public void Union(SubSet[] subSets, int x , int y)
        {
            int xSetParent = Find(subSets, x);
            int ySetParent = Find(subSets, y);

            if (subSets[xSetParent].rank < subSets[ySetParent].rank)
                subSets[xSetParent].parent = ySetParent;
            else if (subSets[xSetParent].rank > subSets[ySetParent].rank)
                subSets[ySetParent].parent = xSetParent;
            else
            {
                // make any tree child of other tree
                subSets[ySetParent].parent = xSetParent;
                //now increase the rank of x for the next time
                subSets[xSetParent].rank++;
            }
        }

        //Find by Path compression
        public int Find(SubSet[] subsets, int vertex)
        {
            if (subsets[vertex].parent != vertex)
                subsets[vertex].parent = Find(subsets, subsets[vertex].parent);
            return subsets[vertex].parent;
        }
        public void PrintSets(SubSet[] subsets)
        {
            //Find Different sets
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < subsets.Length; i++)
            {
                if (map.ContainsKey(subsets[i].parent))
                {
                    var list = map[subsets[i].parent];
                    list.Add(i); // Add Vertex
                    map[subsets[i].parent] = list;
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(i);
                    map.Add(subsets[i].parent, list);
                }
            }

            // Print the different sets
            foreach (var item in map.Keys)
            {
                var elements = string.Empty;
                foreach (var x in map[item])
                {
                    elements += x + ",";
                }
                Console.WriteLine($"Set ID : {item} ; Elements : [{elements}] ");
            }
        }
    }

    public class SubSet
    {
        public int parent { get; set; }
        public int rank { get; set; }
    }
}
