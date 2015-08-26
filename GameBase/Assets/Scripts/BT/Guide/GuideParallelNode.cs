using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GuideParallelNode:GuideNode
    {
        public GuideParallelNode(string name):base(name)
        {

        }

        protected override void Execute()
        {
            for(int i = 0;i<ListChild.Count;i++)
            {
                GuideNode _node = ListChild[i];
                _node.RunNode();
            }
        }

    }
}
