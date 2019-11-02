using System;
using System.Collections.Generic;
using System.Text;

// ---------------------------------------------------------------------------
// File name: UnionItem.cs
// Project name: FindMST
// ---------------------------------------------------------------------------
// Creator’s name and email: Koi Stephanos, stephanos@etsu.edu
// Course-Section://Creation Date:  Algorithms, 11/2/2019
// ---------------------------------------------------------------------------
namespace UnionFindLab
{
    class UnionItem
    {
        public UnionItem parent;        //UnionItem that is the parent of instance
        public int rank,                //Rand of node 
                  value;                //Value associated with node
    }
}
