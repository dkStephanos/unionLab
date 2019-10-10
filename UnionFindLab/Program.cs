using System;

namespace UnionFindLab
{
    class Program
    {
        static void Main(string[] args)
        {
            UnionItem[] unionItems = new UnionItem[4];
            UnionSet unionSet = new UnionSet();

            for (int i = 0; i < 4; i++)
            {
                unionItems[i] = new UnionItem();
                unionItems[i].value = i + 1;
                unionSet.MakeSet(unionItems[i]);
            }

            unionSet.Union(unionItems[0], unionItems[1]);
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
          

            Console.ReadLine();


        }
    }
}
