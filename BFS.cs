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
            public int timeInfected(Node child){
                // mencari waktu terinfeksinya anak dari yang terinfeksi

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
                this.BFSQ.Enqueue(Infected(0,root));
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
                double I = ((double)parent.city.Populasi)/(1 + (parent.city.Populasi - 1)*Math.Exp((-1)*0.25*(this.timeLimit - parent.time)));
                double S = I*prob;
                return S > 1;
            }
            public void checkInfection(DirectedGraph g)
            {
                while(BFSQ.Count > 0){
                    Infected current = BFSQ.Peek();
                    foreach (Link child in current.city.NodesList)
                    {
                        if(isInfected(current, child.prob)){
                            //cari waktu masuknya (T(child))
                            t = current.timeInfected(child);
                            //masukin ke list infected
                            Node infect = g.FindNode(child.id);
                            if(!isExistL(infect)){
                                InfectedList.Add(infect);
                            }
                            if(!isExistQ(child)){
                                BFSQ.Enqueue(Infected(t,child));
                            }
                        }
                    }
                    BFSQ.Dequeue();
                }
            }

        }
    }
}