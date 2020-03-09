using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class Program
    {
        public class Graph
        {
            public int Size;
            public int id_root;
            List<Node> ListOfNode = new List<Node>();

            public Graph(int Size,int id_root)
            {
                this.Size = Size;
                this.id_root = id_root;
            } 
        }

        public class Link
        {
            public int id;
            public float prob;

            public Link(int id,float prob)
            {
                this.id = id;
                this.prob = prob;
            }
        }

        public class Node
        {
            public string Kota;
            public int Populasi;
            List<Link> NodesList = new List<Link>();

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
            int N;
            string Kota;
            int Populasi;
            Console.WriteLine("Masukan N : ");
            N = Convert.ToInt32(Console.ReadLine());
            List<Node> NodesList = new List<Node>();
            Console.WriteLine("Masukan Kota dan Populasi");
            for (int i = 0;i<N;i++){
                Kota = Console.ReadLine();
                Populasi = Convert.ToInt32(Console.ReadLine());
                Node Q = new Node(Kota,Populasi);
                NodesList.Add(Q);
            }

        }
    }
}
