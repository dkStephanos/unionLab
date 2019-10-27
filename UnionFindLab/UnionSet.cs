using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFindLab
{
    class UnionSet
    {
        public int numVertices, numEdges;
        public Edge[] edges;
        UnionItem[] unionItems;

        public UnionSet(int numVertices, int numEdges) {
            this.numVertices = numVertices;
            this.numEdges = numEdges;
            this.unionItems = new UnionItem[numVertices];        
              
            for (int i = 0; i < numVertices; ++i) 
            { 
                this.unionItems[i] = new UnionItem(); 
                this.unionItems[i].parent = this.unionItems[i]; 
                this.unionItems[i].value = i; 
                this.unionItems[i].rank = 0; 
            } 
            edges = new Edge[numEdges];
            for (int i = 0; i < numEdges; i++)
			{
                edges[i] = new Edge();
			}
        }
    

        public void MakeSet(UnionItem x)
        {
            x.parent = x;
            x.rank = 0;
        }

        public UnionItem FindSet(UnionItem x)
        {
            if (x != x.parent)
            {
                x.parent = FindSet(x.parent);
            }
            return x.parent;
        }

        public void Link(UnionItem x, UnionItem y)
        {
            if (x.rank > y.rank)
            {
                y.parent = x;
            }
            else
            {
                x.parent = y;
                if (x.rank == y.rank)
                {
                    y.rank++;
                }
            }     
        }

        public void Union(UnionItem x, UnionItem y)
        {
            Link(FindSet(x), FindSet(y));
        }

        public void KruskalMST() 
        { 
            Edge[] MST = new Edge[numVertices - 1]; 
            Edge nextEdge = new Edge(); 
            int currentEdgeCount = 0; 
            int currentEdgeIndex = 0;
            
            for (int i = 0; i < numVertices - 1; ++i) {
                MST[i] = new Edge(); 
            }
            
            Array.Sort(edges); 
  
            while (currentEdgeCount < numVertices - 1) 
            {  
                nextEdge = edges[currentEdgeIndex++]; 
  
                UnionItem x = FindSet(unionItems[nextEdge.source]); 
                UnionItem y = FindSet(unionItems[nextEdge.destination]); 
                
                //Check for cycle
                if (x != y) 
                { 
                    MST[currentEdgeCount++] = nextEdge; 
                    Union(x, y); 
                }   
            }
            edges = MST;
        } 

        public void PrintMST() {
            Console.WriteLine("\n\nThe MST for the entered graph:\n"); 
            for (int i = 0; i < edges.Length; ++i) 
                    Console.WriteLine("Nodes: " + edges[i].source + " -- " + edges[i].destination + ", Weight = " + edges[i].weight); 
        }                  
    }
}
