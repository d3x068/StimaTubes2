using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Graph;

namespace BreadthFirst
{
    class Program
    {
        public class Infected
        {
            public int time;
            public Node city;

            public Infected(int time, Node city){
                this.time = time;
                this.city = city;
            }
            public int timeInfected(float prob){
                // mencari waktu terinfeksinya anak dari yang terinfeksi
                int t = 1;
                double I = ((double)this.city.Populasi)/(1 + (this.city.Populasi - 1)*Math.Exp((-1)*0.25*t));
                double S = I*prob;
                while (S <= 1) {
                    t++;
                    I = ((double)this.city.Populasi)/(1 + (this.city.Populasi - 1)*Math.Exp((-1)*0.25*t));
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
                this.InfectedList.Add(root);
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
            public bool isExistL(Node q) //if q exist in list
            {
                if(this.InfectedList.Contains(q)){
                    return true;
                }
                return false;
            }
            Queue<Infected> BFSQ = new Queue<Infected>(); //bfs queue
            public List<Node> InfectedList = new List<Node>(); 
            public bool isInfected(Infected parent, float prob){
                if (this.timeLimit != parent.time) {
                    double I = ((double)parent.city.Populasi)/(1 + (parent.city.Populasi - 1)*Math.Exp((-1)*0.25*(this.timeLimit - parent.time)));
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
                        if(isInfected(current, child.prob)){
                            Node infect = g.FindNode(child.id);
                            //cari waktu masuknya (T(child))
                            int t = current.timeInfected(child.prob);
                            //masukin ke list infected
                            if(!isExistL(infect)){
                                InfectedList.Add(infect);
                            }
                            if(!isExistQ(infect)){
                                BFSQ.Enqueue(new Infected(t,infect));
                            }
                        }
                    }
                    BFSQ.Dequeue();
                }
            }

            public void PrintSolution() {
                Console.WriteLine("City Infected : ");
                foreach(Node n in InfectedList) {
                    Console.WriteLine("{0}", n.Kota);
                }
            }

        }
    }
}