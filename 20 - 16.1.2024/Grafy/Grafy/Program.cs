using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    internal class Program
    {
        class Node 
        {
            private int index; //číslo díky kterému poznám který uzel to je
            private List<Node> neighbours;

            public Node (int index)
            {
                this.index = index;
                neighbours = new List<Node> ();
            }

            public void AddNeighbour(Node node) //void nic nevrací
            { 
                if (neighbours.Contains (node)) //aby nebyly duplicity - pokud tam ten uzel byl
                {
                    Console.WriteLine("Node " + node.index + "is already in use.");
                }
                else //přidali jsme uzel
                { 
                    neighbours.Add (node);
                    Console.WriteLine("Added " + node.index + " to the neighbours of");
                    /*node.AddNeighbour(this);*/ //ČTYŘKO PŘIDEJ SI JEDNIČKU ZA SOUSEDA;
                }
                
            
            }

            public int GetIndex() //umím index číst ale nenasavuji, getter na index který je jinak privat
            { 
                return index;
            }
            public int[] GetNeighboursIndices() //zjistí indexy sousedů
            {
                int[] indices = new int[neighbours.Count];
                for (int i = 0; i < neighbours.Count; i++) 
                {
                    indices[i] = neighbours[i].index;
                }
                return indices;
            }

            public Node MoveToNeighbour(int index) //se posuneme do souseda kterého nám uživatel napsal, ošetřili jsme nesousedovost uzlů a přesunutí do neexistujícího uzlu
            { 
                foreach (Node neighbour in neighbours) 
                { 
                    if(neighbour.index == index) 
                    {
                        return neighbour;                       
                    }
                }    
                Console.WriteLine("Node " + index + "is not a neighbour of" + this.index);
                return this;
            }
        
        }
        static void Main(string[] args)
        {
            /*
             * 1: 4,6
             * 2: 3,5,6
             * 3: 2,5
             * 4: 1,6
             * 5: 2,3
             * 6: 1,2,4           
             */

            Node node1 = new Node (1);
            Node node2 = new Node (2);
            Node node3 = new Node (3);
            Node node4 = new Node (4);
            Node node5 = new Node (5);  
            Node node6 = new Node (6);

            node1.AddNeighbour(node4);
            node1.AddNeighbour(node6);

            node2.AddNeighbour(node3);
            node2.AddNeighbour(node5);
            node2.AddNeighbour(node6);

            node3.AddNeighbour(node2);
            node3.AddNeighbour(node5);

            node4.AddNeighbour(node1);
            node4.AddNeighbour(node6);
            
            node5.AddNeighbour(node2);
            node5.AddNeighbour(node3);

            node6.AddNeighbour(node1);
            node6.AddNeighbour(node2);
            node6.AddNeighbour(node4);

            Node currentNode = node1; //proměnná která skáče v grafu kam potřebuji
            while (true) //když je tam true tak mi to jede do nekonečna
            {
                Console.WriteLine("Current nodee: " + currentNode.GetIndex());
                Console.Write("Neighbours "); 
                
                foreach (int neighbourIndex in currentNode.GetNeighboursIndices())
                { 
                    Console.Write(neighbourIndex + " ");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Choose where to go.");
                int desiredIndex = int.Parse(Console.ReadLine());
                currentNode = currentNode.MoveToNeighbour(desiredIndex);
            }





        }
    }
}
