using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class Link
    {
        public string id;
        public float prob;
        public Link(string id,float prob)
        {
            this.id = id;
            this.prob = prob;
        }
    }

    public class Node
    {
        public string Kota;
        public int Populasi;
        public List<Link> NodesList = new List<Link>();

        public Node(string Kota,int Populasi)
        {
            this.Kota = Kota;
            this.Populasi = Populasi;
        }

        public bool isEqual(Node n)
        {
            if((n.Kota == this.Kota) && (n.Populasi == this.Populasi))
            {
                return true;
            }
            else{return false;}
        }
    }

    public class DirectedGraph
    {
        public int numOfNode;
        public int numOfLink;
        public string id_root;
        public List<Node> ListOfNode = new List<Node>();
        public DirectedGraph()
        {
        
        }

        public void LoadNode(string nodeFile)
        {
            string[] text;
            bool firstLine;
            // Node Parsing
            text = System.IO.File.ReadAllLines(nodeFile);
            firstLine = true;
            foreach (string line in text)
            {
                var data = line.Split(' ');
                if (firstLine)
                {
                    firstLine = false;
                    this.numOfNode = int.Parse(data[0]);
                    this.id_root = data[1];
                }
                else
                {
                    this.ListOfNode.Add(new Node(data[0], int.Parse(data[1])));
                }
            }
        }
        
        public void LoadLink(string linkFile)
        {
            string[] text;
            bool firstLine;
            // Link Parsing
            text = System.IO.File.ReadAllLines(linkFile);
            firstLine = true;
            foreach (string line in text)
            {
                var data = line.Split(' ');
                if (firstLine)
                {
                    firstLine = false;
                    this.numOfLink = int.Parse(data[0]);
                }
                else
                {
                    bool found = false;
                    int i = 0;
                    while (!found)
                    {
                        if (this.ListOfNode[i].Kota == data[0])
                        {
                            found = true;
                            this.ListOfNode[i].NodesList.Add(new Link(data[1], float.Parse(data[2])));
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
        }

        public void PrintGraph() {
            Console.WriteLine("Root Node : {0}", id_root);
            foreach (Node node in ListOfNode) {
                Console.WriteLine("Node : {0}, Population : {1}", node.Kota, node.Populasi);
                foreach (Link link in node.NodesList) {
                    Console.WriteLine("{0}, {1}", link.id, link.prob);
                }
            }
        }

        public Node FindNode(string id) {
            foreach (Node n in ListOfNode) {
                if (n.Kota == id) {
                    return n;
                }
            }

            return null;
        }
    }
}
