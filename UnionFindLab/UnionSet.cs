using System;
using System.Collections.Generic;
using System.Text;

// ---------------------------------------------------------------------------
// File name: UnionSet.cs
// Project name: FindMST
// ---------------------------------------------------------------------------
// Creator’s name and email: Koi Stephanos, stephanos@etsu.edu
// Course-Section://Creation Date:  Algorithms, 11/2/2019
// ---------------------------------------------------------------------------
namespace UnionFindLab
{
    class UnionSet
    {
        public int numVertices,                 //The number of vertices
                    numEdges;                   //The number of edges
        public Edge[] edges;                    //Array of Edge item
        UnionItem[] unionItems;                 //Array of UnionItems

        //Constructor that initializes edges and unionItems arrays based on recieved vertex and edges counts
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
    
        //Makes a set containing only the passed UnionItem, setting the parent as itself
        public void MakeSet(UnionItem x)
        {
            x.parent = x;
            x.rank = 0;
        }

        //Searches through the parents of the passed UnionItems to determine which set it belongs to
        public UnionItem FindSet(UnionItem x)
        {
            if (x != x.parent)
            {
                x.parent = FindSet(x.parent);
            }
            return x.parent;
        }

        //Sets the parent to link to UnionItems together
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

        //Unions two sets together
        public void Union(UnionItem x, UnionItem y)
        {
            Link(FindSet(x), FindSet(y));
        }

        //Kruskals algorithm, determines MST by stepping through edges by weight,
        //and adding them to the MST if doing so doesn't create a cycle,
        //which is determined by which set a vertex belongs to
        public void KruskalMST() 
        { 
            Edge[] MST = new Edge[numVertices - 1];                 //Creates an array to hold our MST, by def contains 1 less than total number of vertices
            Edge nextEdge = new Edge();                             //Container for our next edge variable
            int currentEdgeCount = 0;                               //Current edge count
            int currentEdgeIndex = 0;                               //The index of the current edge
            
            //Initialize MST array
            for (int i = 0; i < numVertices - 1; ++i) {
                MST[i] = new Edge(); 
            }
            
            //Sorts our edges using the native CompareTo method of Edge class
            Array.Sort(edges); 
            
            //Steps through until MST is complete
            while (currentEdgeCount < numVertices - 1) 
            {  
                //Sets nextEdge to evaluate
                nextEdge = edges[currentEdgeIndex++]; 
                
                //Determines the set status of each end of the edge
                UnionItem x = FindSet(unionItems[nextEdge.source]); 
                UnionItem y = FindSet(unionItems[nextEdge.destination]); 
                
                //Check for cycle, by comparing parents of each node
                if (x != y) 
                { 
                    //If no cycle will be created, add the edge to the MST array, and union the two sets
                    MST[currentEdgeCount++] = nextEdge; 
                    Union(x, y); 
                }   
            }
            //Sets our edges array to the newly created MST
            edges = MST;
        } 

        //Prints the MST
        public void PrintMST() {
            Console.WriteLine("\n\nThe MST for the entered graph:\n"); 
            for (int i = 0; i < edges.Length; ++i) 
                    Console.WriteLine("Nodes: " + edges[i].source + " -- " + edges[i].destination + ", Weight = " + edges[i].weight); 
        }                  
    }
}
