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
        }
        public class BFSAlgorithm
        {
            public BFSAlgorithm(int time, Node root) //default constructor
            {
                this.timeLimit = time;
                this.root = root;
                this.BFSQ.Enqueue(Infected(0,root));
            }
            public boolean isExistQ(Node q) //if q exist in queue
            {
                //
            }
            public boolean isExistL(Node q) //if q exist in list
            {
                //
            }
            Queue<Infected> BFSQ = new Queue<Infected>(); //bfs queue
            public List<Node> InfectedList = new List<Node>(); 
            public boolean isInfected(Node parent, Node child){
                //
            }
            public void checkInfection()
            {
                while(BFSQ.Count > 0){
                    Infected current = BFSQ.Peek();
                    foreach (Link child in current.city.NodesList)
                    {
                        if(isInfected(current.city,child)){
                            //cari waktu masuknya (T(child))

                            //masukin ke list infected
                            if(!isExistL(child)){
                                InfectedList.Add(child);
                            }
                            if(!isExist(child)){
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