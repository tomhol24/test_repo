using System.Collections.Generic;

namespace GraphPlayground
{
    //Simple node class, no comments needed
    internal class Node
    {
        public int index;

        public List<Node> neighbors;

        public bool visited; //jestli jsem jej navštívil nebo ne
        
        public Node cameFrom; //To si pamatuje odkud jsem do daného uzlu přišel, jen uložím uzel ze kterého jsem se dostal do toho aktuálního

        public Node(int index)
        {
            this.index = index;
            neighbors = new List<Node>();
            visited = false;
            cameFrom = null; //Počáteční nastavení na nulu
        }
    }
}
