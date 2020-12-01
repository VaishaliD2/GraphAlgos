using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgos
{
    public class DisjointSets
    {
        public void disjointSets(int vertices, LinkedList<Tuple<int, int>>[] adj,List<Edge> edges)
        {
            //create a parent []
            int[] parent = new int[vertices];

            //makeset
            MakeSet(parent);

            //iterate through all the edges and keep making the sets (union the sets)
            foreach(var item in edges)
            {
                int xSet = Find(parent, item.Source);
                int ySet = Find(parent, item.Destination);
                //check if source vertex and destination vertex belongs to the same set
                // if in same set then cycle has been detected else combine them into one set
                if(xSet== ySet)
                {
                    // cycle 
                }
                else
                {
                    Union(parent, xSet, ySet);
                }
            }

            PrintSets(parent);

        }

        public void PrintSets(int[] parent)
        {
            //Find Different sets
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for(int i = 0; i< parent.Length; i++)
            {
                if(map.ContainsKey(parent[i]))
                {
                    var list = map[parent[i]];
                    list.Add(i); // Add Vertex
                    map[parent[i]] = list;
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(i);
                    map.Add(parent[i], list);
                }
            }

            // Print the different sets
            foreach(var item in map.Keys)
            {               
                var elements = string.Empty;
                foreach(var x in map[item])
                {
                    elements += x + ",";
                }
                Console.WriteLine($"Set ID : {item} ; Elements : [{elements}] ");
            }
        }

        public void Union(int[] parent, int x, int y)
        {
            int xSetParent = Find(parent, x);
            int ySetParent = Find(parent, y);
            //make x as parent of y
            parent[ySetParent] = xSetParent;
        }

        public int Find(int[] parent, int vertex)
        {   
            //chain of parent pointers from x upwards through the tree
            // until an element is reached whose parent is itself
            if(parent[vertex] != vertex)
            {
                return Find(parent, parent[vertex]);
            }
            return vertex;

        }

        public void MakeSet(int[] parent)
        {
            //This operation makes a new set by creating a new element with a parent pointer to itself. 
            //The parent pointer to itself indicates that the element is the representative member of its own set.
            //The MakeSet operation has O(1) time complexity.
            //Make set- creating a new element with a parent pointer to itself.
            // no of vertices = parent.length
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
        }

       
    }
}

