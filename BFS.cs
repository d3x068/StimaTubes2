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
            public BFSAlgorithm(int time, Infection root) //default constructor
            {
                this.timeLimit = time;
                this.root = root;
                this.BFSQ.Enqueue(root.city);
            }

            Queue<Node> BFSQ = new Queue<Node>();

            public void checkInfection()
            {
                
            }

        }
    }
}