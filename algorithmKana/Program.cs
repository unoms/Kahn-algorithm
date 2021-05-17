using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmKana
{
    class Program
    {
        class Node
        {
            public readonly List<Node> Incidents = new List<Node>();

            public int Number { get; set; }

            public Node(int num)
            {
                Number = num;
            }
            
            public void To(Node node)
            {
                Incidents.Add(node);
            }
        }

        class Graph
        {
            public readonly List<Node> Nodes = new List<Node>();
        }

        static List<Node> KanaSort(Graph graph)
        {
            //Copy nodes into a separate list to handle with them
            List<Node> nodes = graph.Nodes.ToList();

            List<Node> result = new List<Node>();

            while (nodes.Count != 0)
            {
               for(int i = 0; i < nodes.Count; i++)
                {
                   int count = 0;//Количество заходов в вершину 
                   for(int j = 0; j < nodes.Count; j++)
                    {
                        if (i == j) continue; //Не проверяем одну и туже вершину

                        if (nodes[j].Incidents.Contains(nodes[i]))
                            count++;

                    }

                   if(count == 0)// вершина с нулевой степенью захода
                    {
                        result.Add(nodes[i]);//Добавляем в результат
                        nodes.Remove(nodes[i]);//Удаляем из списка и будем опять искать вершину с с нулевой степенью захода
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var n0 = new Node(0);
            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);

            n0.To(n1);
            n0.To(n2);

            n1.To(n3);
            n1.To(n2);

            n2.To(n3);
            n2.To(n4);

            n4.To(n3);

            Graph gr = new Graph();
            gr.Nodes.Add(n0);
            gr.Nodes.Add(n1);
            gr.Nodes.Add(n2);
            gr.Nodes.Add(n3);
            gr.Nodes.Add(n4);

            List<Node> res = KanaSort(gr);

            foreach (var n in res)
                Console.WriteLine(n.Number);
        }
    }
}
