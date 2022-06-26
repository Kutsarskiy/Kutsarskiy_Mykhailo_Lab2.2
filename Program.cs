using System;
using System.Collections.Generic;

namespace lab2csh2
{


    class tarif1
    {
        public int cost, gb, min;
        public string name;

        public tarif1(int cost, int gb, int min, string name)
        {
            this.min = min;
            this.gb = gb;
            this.cost = cost;
            this.name = name;
        }
        public tarif1()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.Write("Price = ");
            cost = int.Parse(Console.ReadLine());

            Console.Write("Amount of GB = ");
            gb = int.Parse(Console.ReadLine());

            Console.Write("Amount of minutes = ");
            min = int.Parse(Console.ReadLine());

            Console.Write("Name = ");
            name = Console.ReadLine();

        }


    }
    class tarif2 : tarif1
    {
        public int roum;
        public tarif2()
        {
            Console.WriteLine("[Additional]");
            Console.Write("Amout of roaming minutes = ");
            roum = Convert.ToInt32(Console.ReadLine());
 
        }
    }
    class tarif3 : tarif1
    {
        public int sms;
        public tarif3()
        {
            Console.WriteLine("[Additional]");
            Console.Write("Amount of SMS = ");
            sms = Convert.ToInt32(Console.ReadLine());

        }

    }

    class Mob
    {
        static public void Swap(tarif1 t1, tarif1 t2)
        {
            tarif1 tmp = new tarif1(t1.cost, t1.gb, t1.min, t1.name);
            t1.cost = t2.cost;
            t1.gb = t2.gb;
            t1.min = t2.min;
            t1.name = t2.name;

            t2.cost = tmp.cost;
            t2.gb = tmp.gb;
            t2.min = tmp.min;
            t2.name = tmp.name;
        }
        public List<tarif1> lt = new List<tarif1>();
        public Mob(int n1, int n2, int n3)
        {
            for (int i = 0; i < n1; i++)
            {
                tarif1 t1 = new tarif1();
                lt.Add(t1);
            }
            for (int i = 0; i < n2; i++)
            {
                tarif2 t1 = new tarif2();
                lt.Add(t1);
            }
            for (int i = 0; i < n3; i++)
            {
                tarif3 t1 = new tarif3();
                lt.Add(t1);
            }
        }

        public void Search(int costl, int costr, int gbl)
        {
            for (int i = 0; i < lt.Count; i++)
            {
                if (lt[i].cost <= costr &&
                    lt[i].cost >= costl &&
                    lt[i].gb >= gbl)
                    Console.WriteLine("You can use " + lt[i].name + ", it costs " + lt[i].cost + " and has " + lt[i].gb + " GB");
            }

        }


        public void Calculate()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("There are " + lt.Count + " members");
            Console.Write("------------------------------------------------------------------------------------------------------------------------");
        }

        public void Sort()
        {
            for (int i = 1; i < lt.Count; i++)
            {
                for (int j = 0; j < lt.Count - i; j++)
                {
                    if (lt[j].cost < lt[j + 1].cost)
                    {
                        Mob.Swap(lt[j], lt[j + 1]);
                    }
                }
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Sorted array]");

            for (int i = lt.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(lt[i].name + " - " + lt[i].cost);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2, n3;
            Console.Write("Input amount of 1st mobile tariff: ");
            n1 = int.Parse(Console.ReadLine());
            Console.Write("Input amount of 2nd mobile tariff: ");
            n2 = int.Parse(Console.ReadLine());
            Console.Write("Input amount of 3rd mobile tariff: ");
            n3 = int.Parse(Console.ReadLine());
            Mob t = new Mob(n1, n2, n3);
            t.Sort();
            Console.Write("Input min. price: ");
            n3 = int.Parse(Console.ReadLine());
            Console.Write("input max. price: ");
            n2 = int.Parse(Console.ReadLine());
            Console.Write("input min. amount of GB: ");
            n1 = int.Parse(Console.ReadLine());

            t.Search(n3, n2, n1);
            t.Calculate();
        }
    }
}