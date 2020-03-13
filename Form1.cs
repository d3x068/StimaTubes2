using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
using BreadthFirst;
using System.Windows.Forms;

namespace Graph_Visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.time = 0;
            doneProcess = false;
            //this.dg = new DirectedGraph();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
            tm.Interval = 250;
            tm.Tick += new System.EventHandler(changeGraph);
            tm.Start();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gViewer1.Graph = null;
            this.T = 0;
            this.label8.Text = "Day : ";
            DirectedGraph dg = new DirectedGraph();
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0)
            {
                if (textBox1.TextLength == 0)
                {
                    label5.Text = "Input a file";
                }
                if (textBox2.TextLength == 0)
                {
                    label6.Text = "Input a file";
                }
                if (textBox3.TextLength == 0)
                {
                    label7.Text = "Input Duration";
                }
            }
            else
            {
                bool succLoadNode = true;
                bool succLoadLink = true;
                bool succConvert = true;
                // Node Parsing
                try
                {
                    dg.LoadNode(this.textBox1.Text);
                }
                catch
                {
                    succLoadNode = false;
                    label5.Text = "Invalid File";
                }
                try
                {
                    dg.LoadLink(this.textBox2.Text);
                }
                catch
                {
                    succLoadLink = false;
                    label6.Text = "Invalid File";
                }
                try
                {
                    T = Convert.ToInt32(textBox3.Text);
                }
                catch
                {
                    succConvert = false;
                    label7.Text = "Invalid dataType";
                }

                if (succLoadLink && succLoadNode && succConvert)
                {
                    this.time = 0;
                    bfs = new BFSAlgorithm(T, dg.FindNode(dg.id_root));
                    bfs.checkInfection(dg);

                    this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
                    //create the graph content
                    foreach (Graph.Node node in dg.ListOfNode)
                    {
                        
                        if (graph.FindNode(node.Kota) == null)
                        {
                            graph.AddNode(node.Kota);
                        }
                        foreach (Graph.Link link in node.NodesList)
                        {
                            graph.AddEdge(node.Kota, link.id);
                        }
                    }
                    this.gViewer1.Graph = graph;
                    doneProcess = true;
                    
                    
                    //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    //bind the graph to the viewer 
                }
            }
        }

        private void changeGraph(object sender, EventArgs e)
        {
            if (doneProcess)
            {
                if (bfs.InfectedList.ContainsKey(time))
                {
                    foreach (Graph.Node node in bfs.InfectedList[time])
                    {
                        graph.FindNode(node.Kota).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    //Thread.Sleep(1000);
                }
                this.label8.Text = "Day : " + Convert.ToString(time);
                this.gViewer1.Graph = graph;
                if (time < T)
                {
                    time++;
                }
                else
                {
                    doneProcess = false;
                }
            }
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
