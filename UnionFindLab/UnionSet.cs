using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFindLab
{
    class UnionSet
    {
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
    }
}
