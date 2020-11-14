using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Threading;


namespace GraphSeacher
{
    class Program
    {

        static bool[,] mCanGo = new bool[,]
        {
            {false, true, false, true, false, false, false, false},
            {false, false, true, false, false, true, false, false},
            {false, true, false, true, false, false, false, false},
            {false, false, true, false, true, false, false, false},
            {false, false, false, false, false, false, true, false},
            {false, false, false, false, false, false, false, true},
            {false, false, false, false, false, true, false, false},
            {false, false, false, false, false, false, false, false}
        };

        static int[,] mCost = new int[,]
        {
            {-1, 1, -1, 5, -1, -1, -1, -1},
            {-1, -1, 1, -1, -1, 8, -1, -1},
            {-1, 1, -1, 0,-1, -1, -1, -1},
            {-1, -1, 0, -1, 1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, 1, -1},
            {-1, -1, -1, -1, -1, -1 -1, -1, 6},
            {-1, -1, -1, -1, -1, 1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1}

        };

        static string[][] lColor = new string[][]
        {
            new string[]{"blue", "gray"},   //red = 0
            new string[]{"cyan","yellow"},  //blue = 1
            new string[]{"blue", "gray"},   //cyan = 2
            new string[]{"cyan", "orange"}, //gray =3
            new string[]{"purple"},         //orange = 4
            new string[]{"yellow"},         //purple = 5
            new string[]{"green"},          //yellow = 6           
            new string[]{ }                 //green = 7
        };

        static int[][] lColors = new int[][]
        {
            new int[]{1, 3},
            new int[]{2, 6},
            new int[]{1, 3},
            new int[]{2, 4},
            new int[]{5},
            new int[]{6},
            new int[]{7},
            new int[]{},
        };

        static int[][] lCost = new int[][]
        {
            new int[]{1, 5},
            new int[]{1, 8},
            new int[]{1, 0},
            new int[]{0, 1},
            new int[]{1},
            new int[]{1},
            new int[]{6},
            new int[]{}
        };


        public class Node : IComparable<Node>
        {
            public int nState;
            public List<Edge> edges = new List<Edge>();

            public int minCostToStart;
            public Node nearestToStart;
            public bool visited;

            public Node(int nState)
            {
                this.nState = nState;
                this.minCostToStart = int.MaxValue;
            }

            public void AddEdge(int cost, Node connection)
            {
                Edge e = new Edge(cost, connection);
                edges.Add(e);
            }

            public int CompareTo(Node n)
            {
                return this.minCostToStart.CompareTo(n.minCostToStart);
            }
        }

        public class Edge : IComparable<Edge>
        {
            public int cost;
            public Node connectedNode;

            public Edge(int cost, Node connectedNode)
            {
                this.cost = cost;
                this.connectedNode = connectedNode;
            }

            public int CompareTo(Edge e)
            {
                return this.cost.CompareTo(e.cost);
            }
        }

        static int nState = 0;
        static List<Node> list = new List<Node>();

        static void Main(string[] args)
        {

            //I think this is working right
            Console.Write("This is from the DFS: ");
            DFS();
            Console.WriteLine("");
            //adds all the colors to a linked list(I think its right)
            Node node;

            node = new Node(0);
            list.Add(node);

            node = new Node(1);
            list.Add(node);

            node = new Node(2);
            list.Add(node);

            node = new Node(3);
            list.Add(node);

            node = new Node(4);
            list.Add(node);

            node = new Node(5);
            list.Add(node);

            node = new Node(6);
            list.Add(node);

            node = new Node(7);
            list.Add(node);

            GetShortestPathDijkstra();

            Console.Write("this is from the Dijkstra Search: ");
            //prints out the list values, which display the shortest path.
            for(int i = 0; i < list.Count; i++)
            {
                IntToColor(list[i].nState);
            }
            Console.WriteLine(" ");
        }


        static void DFS()
        {
            // Mark all the vertices as not visited 
            // (set as false by default in c#) 
            bool[] visited = new bool[lCost.Length];

            // Call the recursive helper function 
            // to print DFS traversal
            
            DFSUtil(nState, visited);
        }

        static void DFSUtil(int v, bool[] visited)
        {
            

            // Mark the current node as visited 
            // and print it 
            visited[v] = true;

            //prints out the traversal
            //Console.Write(v + " ");
            IntToColor(v);

            

            // Recur for all the vertices 
            // adjacent to this vertex 
            int[] thisStateList = lColors[v];
            foreach (int n in thisStateList)
            {
                if (!visited[n])
                {
                    DFSUtil(n, visited);
                }
            }
        }

        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(list[7]);
            BuildShortestPath(shortestPath, list[7]);
            shortestPath.Reverse();
            return (shortestPath);
        }

        static private void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static private int NodeOrderBy(Node n)
        {
            return n.minCostToStart;
        }

        static private void DijkstraSearch()
        {
            Node start = list[0];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);

            do
            {
                // sort our prioQueue by minCostToStart
                // option #1, use .Sort() which sorts in place 
                // and uses the overloaded Node.CompareTo() method
                prioQueue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // to indicate which field to sort by
                // the next 5 lines are equivalent from descriptive to abbreviated:
                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart).ToList();
                prioQueue = prioQueue.OrderBy(n => n.minCostToStart).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (Edge cnn in node.edges)
                //.OrderBy(delegate(Edge n) { return n.cost; }))
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                if (node == list[7])
                {
                    return;
                }
            } while (prioQueue.Any());
        }
    

    static void IntToColor(int i)
        {
            if(i == 0)
            {
                Console.Write("Red ");
            }
            else if(i == 1)
            {
                Console.Write("Blue ");
            }
            else if (i == 2)
            {
                Console.Write("Cyan ");
            }
            else if (i == 3)
            {
                Console.Write("Gray ");
            }
            else if (i == 4)
            {
                Console.Write("Orange ");
            }
            else if (i == 5)
            {
                Console.Write("Purple ");
            }
            else if (i == 6)
            {
                Console.Write("Yellow ");
            }
            else if (i == 7)
            {
                Console.Write("Green ");
            }
        }
    }

}
