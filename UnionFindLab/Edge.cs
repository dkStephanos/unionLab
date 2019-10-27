using System;

class Edge : IComparable<Edge> 
{ 
    public int source, destination, weight; 
  
    public int CompareTo(Edge edge) 
    { 
        return this.weight - edge.weight; 
    } 
} 