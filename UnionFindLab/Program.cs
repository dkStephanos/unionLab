using System;

// ---------------------------------------------------------------------------
// File name: Program.cs
// Project name: FindMST
// ---------------------------------------------------------------------------
// Creator’s name and email: Koi Stephanos, stephanos@etsu.edu
// Course-Section://Creation Date:  Algorithms, 11/2/2019
// ---------------------------------------------------------------------------
namespace UnionFindLab
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numVertices,                        //Number of vertices
                    numEdges;                       //Number of edges
            string[] inputLine;                       //Use for console input

            //Collects number of vertices and edges from user
            Console.WriteLine("Enter number of vertices and edges:  ");
            inputLine = Console.ReadLine().Split(" ");
            numVertices = Int32.Parse(inputLine[0]);
            //Console.WriteLine("\n\nEnter number of edges:  ");
            numEdges = Int32.Parse(inputLine[1]);

            //Creates unionSet based on user input
            UnionSet unionSet = new UnionSet(numVertices, numEdges);

            //Collects edges data from user
            for (int i = 0; i < numEdges; i++)
			{
                /*Console.WriteLine("\n\nEnter source of edge" + i + ":  ");
                unionSet.edges[i].source = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\n\nEnter destination of edge" + i + ":  ");
                unionSet.edges[i].destination = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\n\nEnter weight of edge" + i + ":  ");
                unionSet.edges[i].weight = Int32.Parse(Console.ReadLine());*/
                inputLine = Console.ReadLine().Split(" ");
                unionSet.edges[i].source = Int32.Parse(inputLine[0]);
                unionSet.edges[i].destination = Int32.Parse(inputLine[1]);
                unionSet.edges[i].weight = Int32.Parse(inputLine[2]);
            }

            //Run the Kruskal MST algortihm on edges, and print results
            unionSet.KruskalMST();
            unionSet.PrintMST();

            //Prior driver code for UnionSet demonstration
            /*unionSet.Union(unionItems[0], unionItems[1]);
            unionSet.Union(unionItems[2], unionItems[3]);
            unionSet.Union(unionItems[1], unionItems[2]);

            int numRoots = 0;
            int numLeaves = 1;
            string output = "";
            string nextLineOutput = "";
            for (int i = 0; i < unionItems.Length; i++)
            {
                if(unionItems[i].parent == unionItems[i]) //if its own parent, it is a root
                {
                    output += "\n\n" + unionItems[i].value.ToString() + "\n|\n";

                    for (int j = 0; j < unionItems.Length; j++)
                    {
                        if (unionItems[j].parent == unionItems[i] && unionItems[j] != unionItems[i])
                        {
                            if (unionItems[j+1].parent == unionItems[i])
                            {
                                output += unionItems[j].value.ToString() + " - ";
                            }
                            else
                            {
                                output += unionItems[j].value.ToString();
                            }
                            for (int k = 0; k < unionItems.Length; k++)
                            {
                                if (unionItems[k].parent == unionItems[j])
                                {
                                    nextLineOutput = "\n|\n";
                                    if (unionItems[k + 1].parent == unionItems[j])
                                    {
                                        nextLineOutput += unionItems[k].value.ToString() + " - ";
                                    }
                                    else
                                    {
                                        nextLineOutput += unionItems[k].value.ToString();
                                    }
                                }
                            }
                        }
                       
                    }
                    output += nextLineOutput;
                    nextLineOutput = "";
                }             
            }

            Console.WriteLine(output);
          */

            //Wait for user input to show data
            Console.ReadLine();
        }
    }
}
