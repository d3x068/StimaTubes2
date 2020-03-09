using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Graph;

namespace BreadthFirst
{
    class Program
    {
        public class Infection
        {
            public Infection(Node city) //constructor
            {
                this.city = city;
                this.timeInfected = 0;
            }

            public List<Infection> Infected //Kota-kota yang terinfeksi
            {
                get
                {
                    return InfectedList;
                }
            }
            public boolean isInfected(Node child)
            {
                //pake rumus yang S, buat masukin ke list Infected
            }

            public void addInfected(Infection city)
            {
                InfectedList.Add(city);
            }
            List<Infection> InfectedList = new List<Infection>();
            public void setTimeInfected(int time)
            {
                this.timeInfected = time;
            }
        }
        public class BFSAlgorithm
        {
            public BFSAlgorithm(int time, Node root) //default constructor
            {
                this.timeLimit = time;
                this.root = root;
                this.BFSQ.Enqueue(root);
            }
            public boolean isExist(Node q) //if q exist in queue
            {

            }
            Queue<Node> BFSQ = new Queue<Node>(); //bfs queue
            public boolean isInfected(Node parent, Node child);
            public void checkInfection()
            {
                while(BFSQ.Count > 0){
                    Node current = BFSQ.Peek();
                    foreach (Link child in current.NodesList)
                    {
                        if(isInfected(current,child)){
                            //masukin ke list infected
                            if(!isExist(child)){
                                BFSQ.Enqueue(child);
                            }
                        }
                        BFSQ.Dequeue();
                    }
                }
            }

        }
    }
}