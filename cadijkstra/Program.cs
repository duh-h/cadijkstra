using System;
using System.Collections.Generic;
using System.Linq;

namespace cadijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Node("Itumbiara");
            var b = new Node("Centralina");
            var c = new Node("Tupaciguara");
            var d = new Node("Capinopolis");
            var e = new Node("Ituiutaba");
            var f = new Node("Douradinhos");
            var g = new Node("Monte Alegre");
            var h = new Node("Uberlandia");
            var i = new Node("Araguari");
            var j = new Node("Cascalho rico");
            var k = new Node("Grupiara");
            var l = new Node("Estrela do sul");
            var m = new Node("Romaria");
            var n = new Node("Sao juliana");
            var o = new Node("Indianopolis");

            a.ConnectTo(b, 20);
            a.ConnectTo(c, 55);
            b.ConnectTo(g, 75);
            b.ConnectTo(d, 40);
            c.ConnectTo(g, 44);
            c.ConnectTo(h, 60);
            d.ConnectTo(e, 30);
            e.ConnectTo(g, 85);
            e.ConnectTo(f, 90);
            f.ConnectTo(g, 28); 
            f.ConnectTo(h, 63);
            g.ConnectTo(h, 60);
            h.ConnectTo(i, 30);
            h.ConnectTo(m, 78);
            h.ConnectTo(o, 45);
            i.ConnectTo(j, 28);
            i.ConnectTo(l, 34);
            j.ConnectTo(k, 32);
            k.ConnectTo(l, 38);
            l.ConnectTo(m, 27);
            m.ConnectTo(n, 28);
            o.ConnectTo(n, 40);


            Console.WriteLine("Insira o nome da primeira cidade:");
            string city1 = Console.ReadLine();

            Console.WriteLine("Insira o nome da segunda cidade:");
            string city2 = Console.ReadLine();

            var cityNodes = new Dictionary<string, Node>
        {
            { "Itumbiara", a },
            { "Centralina", b },
            { "Tupaciguara", c },
            { "Capinopolis", d },
            { "Ituiutaba", e },
            { "Douradinhos", f },
            { "Monte Alegre", g },
            { "Uberlandia", h },
            { "Araguari", i },
            { "Cascalho rico", j },
            { "Grupiara", k },
            { "Estrela do sul", l },
            { "Romaria", m },
            { "Sao juliana", n },
            { "Indianopolis", o }
        };

            if (cityNodes.ContainsKey(city1) && cityNodes.ContainsKey(city2))
            {
                Node from = cityNodes[city1];
                Node to = cityNodes[city2];

                IShortestPathFinder dijkstra = new Dijkstra();
                ShortestPathResult result = dijkstra.FindShortestPath(from, to);

                if (result.Path != null)
                {
                    Console.WriteLine("Menor caminho entre " + city1 + " e " + city2 + ":");
                    foreach (var node in result.Path)
                    {
                        Console.Write(node.Label + " ");
                    }

                    Console.WriteLine("\nDistância: " + result.Distance+"Km");
                }
                else
                {
                    Console.WriteLine("Não há caminho entre " + city1 + " e " + city2 + ".");
                }
            }
            else
            {
                Console.WriteLine("Uma ou ambas as cidades não foram encontradas.");
            }
        }
    }
}
