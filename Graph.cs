using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class Program
    {
        // public class Graph
        // {
        //     public 
        // }

        public class Node
        {
            public string Kota;
            public int Populasi;
            List<Node> NodesList = new List<Node>();

            public Node(string Kota,int Populasi)
            {
                this.Kota = Kota;
                this.Populasi = Populasi;
            }

            public string GetKota(){
                return this.Kota;
            }

            public void SetKota(string Kota){
                this.Kota = Kota;
            }

            public int GetPopulasi(){
                return this.Populasi;
            }

            public void SetPopulasi(int Populasi){
                this.Populasi = Populasi;
            }

            // public List<Node> Nodes
            // {

            // }
        }

        static void Main(string[] args)
        {
            Node N = new Node("A",100000);
        }
    }
}
