using System;

namespace GraphPlayground
{
    internal class Program
    {
        public static void DFS(Graph graph, Node startNode, Node targetNode = null)
        {

        }

        public static void BFS(Graph graph, Node startNode, Node targetNode = null) //Pro zobrazení grafu https://csacademy.com/app/graph_editor/
        {
            startNode.visited = true;
            Node currentNode = startNode; //nastavím si jej jako startovní protože v něm začínám
            while (true) 
            {
                Console.WriteLine($"Aktuálně jsem v uzlu " + currentNode.index);
                Node haveNeighborToVisit = null;
                foreach (Node neighbor in currentNode.neighbors) 
                { 
                    if (!neighbor.visited) 
                    { 
                        haveNeighborToVisit = neighbor;
                        break;  
                    
                    }             
                }
                if (haveNeighborToVisit == null) //Všichni sousedi navšítvení //pokud se to nikdy nedostalo do toho ifu nahoře (dokončené iterace a všichni sousedi jsou navšítvení) tak dávám return a končím celé DFS protože už není kam jít
                {
                    if (currentNode == startNode) //Na to abych to skončil úplně musím být zpátky na začátku
                    {
                        Console.WriteLine("Jsem v startovacím uzlu, nemám kam jít, končím DFS.");
                        return;
                    }
                    else 
                    {
                        Console.WriteLine("Jsem ve slepé uličce, vracím se z uzlu " + currentNode.index + " do uzlu " + currentNode.cameFrom); 
                        currentNode = currentNode.cameFrom;
                    }
                }
                else //Mám nenavšíteného souseda, kterého jdu navštívit
                {
                    Console.WriteLine("Jdu z uzlu " + currentNode.index + " do nenavštíveného souseda " + haveNeighborToVisit.index);
                    haveNeighborToVisit.visited = true;
                    haveNeighborToVisit.cameFrom = currentNode;
                    currentNode = haveNeighborToVisit;
                }
            }

        }

        static void Main(string[] args)
        {
            //Create and print the graph
            Graph graph = new Graph();
            graph.PrintGraph();
            graph.PrintGraphForVisualization();

            //Call both algorithms with a random starting node
            Random rng = new Random();
            DFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]); //zaviólá se a dá se tomu náhodný startovací node
            BFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.ReadKey();
        }
    }
}
