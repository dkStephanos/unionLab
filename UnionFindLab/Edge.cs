using System;

// ---------------------------------------------------------------------------
// File name: Edge.cs
// Project name: FindMST
// ---------------------------------------------------------------------------
// Creator’s name and email: Koi Stephanos, stephanos@etsu.edu
// Course-Section://Creation Date:  Algorithms, 11/2/2019
// ---------------------------------------------------------------------------
class Edge : IComparable<Edge> 
{ 
    public int source,                      //The source of the edge
               destination,                 //The destincation of the edge
               weight;                      //The weight of the edge
    
    //Custom CompareTo method for the IComparable implementation
    //Uses weight to sort edges
    public int CompareTo(Edge edge) 
    { 
        return this.weight - edge.weight; 
    } 
} 