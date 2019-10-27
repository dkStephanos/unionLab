using System;

namespace UnionFindLab
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numVertices, numEdges;

            Console.WriteLine("Enter number of vertices:  ");
            numVertices = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\n\nEnter number of edges:  ");
            numEdges = Int32.Parse(Console.ReadLine());

            UnionSet unionSet = new UnionSet(numVertices, numEdges);

            for (int i = 0; i < numEdges; i++)
			{
                Console.WriteLine("\n\nEnter source of edge" + i + ":  ");
                unionSet.edges[i].source = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\n\nEnter destination of edge" + i + ":  ");
                unionSet.edges[i].destination = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\n\nEnter weight of edge" + i + ":  ");
                unionSet.edges[i].weight = Int32.Parse(Console.ReadLine());
			}

            unionSet.KruskalMST();
            unionSet.PrintMST();

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

            Console.ReadLine();


        }
    }
}
