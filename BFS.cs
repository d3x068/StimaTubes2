using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Graph;

namespace BreadthFirst
{
        public delegate double function(int population, int time);

        class InfectedFunction {
            public static double LinearFunc(int population, int time) {
                return ((double)population*time)/20;
            }

            public static double LogisticFunc(int population, int time) {
                return ((double)population)/(1 + (population - 1)*Math.Exp((-1)*0.25*time));
            }
        }
    
        public class Infected
        {
            public int time;
            public Node city;

            public Infected(int time, Node city){
                this.time = time;
                this.city = city;
            }
            public int timeInfected(float prob, function f){
                // mencari waktu terinfeksinya anak dari yang terinfeksi
                int t = 1;
                double I = f(this.city.Populasi, t);
                //double I = ((double)this.city.Populasi)/(1 + (this.city.Populasi - 1)*Math.Exp((-1)*0.25*t));
                double S = I*prob;
                while (S <= 1) {
                    t++;
                    I = f(this.city.Populasi, t);
                    S = I*prob;
                }

                return t + this.time;

            }
        }
        public class BFSAlgorithm
        {
            int timeLimit;
            Node root;
            public BFSAlgorithm(int time, Node root) //default constructor
            {
                this.timeLimit = time;
                this.root = root;
                this.BFSQ.Enqueue(new Infected(0,root));
                List<Node> firstDay = new List<Node>();
                firstDay.Add(root);
                this.InfectedList.Add(0, firstDay);
            }
            public bool isExistQ(Node q) //if q exist in queue
            {
                Queue<Infected> qcopy = new Queue<Infected>(this.BFSQ.ToArray());
                while (qcopy.Count > 0)
                {
                    if(q.isEqual((qcopy.Peek()).city)){
                        return true;}
                    qcopy.Dequeue();
                }
                return false;
            }
            public int isExistL(int t, Node q) //if q exist in list
            {
                foreach (KeyValuePair<int, List<Node>> dict in InfectedList)
                {
                    if (dict.Value.Contains(q))
                    {
                        return dict.Key;
                    }
                }
                if (!this.InfectedList.ContainsKey(t))
                {
                    this.InfectedList.Add(t, new List<Node>());
                }
                return -1;
            }
            Queue<Infected> BFSQ = new Queue<Infected>(); //bfs queue
            public SortedDictionary<int, List<Node>> InfectedList = new SortedDictionary<int, List<Node>>(); 
            public bool isInfected(Infected parent, float prob, function f){
                if (this.timeLimit != parent.time) {
                    double I = f(parent.city.Populasi, this.timeLimit - parent.time);
                    double S = I*prob;
                    return S > 1;
                } else {
                    return false;
                }
            }
            public void checkInfection(DirectedGraph g)
            {
                while(BFSQ.Count > 0){
                    Infected current = BFSQ.Peek();
                    foreach (Link child in current.city.NodesList)
                    {
                        if(isInfected(current, child.prob, InfectedFunction.LogisticFunc)){
                            Node infect = g.FindNode(child.id);
                            //cari waktu masuknya (T(child))
                            int t = current.timeInfected(child.prob, InfectedFunction.LogisticFunc);
                        //masukin ke list infected
                            int res = isExistL(t, infect);
                            if(res == -1){
                                InfectedList[t].Add(infect);
                                BFSQ.Enqueue(new Infected(t, infect));
                            } 
                            else if (t < res)
                            {
                                InfectedList[res].Remove(infect);
                                if (InfectedList[res].Count == 0)
                                {
                                    InfectedList.Remove(res);
                                }
                                if (!InfectedList.ContainsKey(t))
                                {
                                    this.InfectedList.Add(t, new List<Node>());
                                }
                                InfectedList[t].Add(infect);
                                BFSQ.Enqueue(new Infected(t, infect));
                            }
                        }
                    }
                    BFSQ.Dequeue();
                }
            }

            /*
            public void PrintSolution() {
                Console.WriteLine("City Infected : ");
                foreach(Node n in InfectedList) {
                    Console.WriteLine("{0}", n.Kota);
                }
            }
            */

        }
        /*
        class Program {
            static void Main() {
                DirectedGraph g = new DirectedGraph();
                g.LoadGraph("node.txt", "link.txt");
                BFSAlgorithm bfs = new BFSAlgorithm(10, g.FindNode(g.id_root));
                bfs.checkInfection(g);
                bfs.PrintSolution();
            }
        }
        */
}