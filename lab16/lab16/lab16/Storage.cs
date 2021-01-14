using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace lab16
{
    class Storage
    {
        public static void Start()
        {
            BlockingCollection<int> appliances = new BlockingCollection<int>();
            Thread tprod = new Thread(() => AllProd());
            Thread tcust = new Thread(() => AllCust());
            tprod.Start();
            tcust.Start();
            void AllProd()
            {
                Task.Run(() => Provider(appliances, 1000, 1));
                Task.Run(() => Provider(appliances, 900, 2));
                Task.Run(() => Provider(appliances, 200, 3));
                Task.Run(() => Provider(appliances, 700, 4));
                Task.Run(() => Provider(appliances, 100, 5));
            }
            void AllCust()
            {
                Task.Run(() => Customer(appliances, 100));
                Task.Run(() => Customer(appliances, 500));
                Task.Run(() => Customer(appliances, 3000));
                Task.Run(() => Customer(appliances, 300));
                Task.Run(() => Customer(appliances, 400));
                Task.Run(() => Customer(appliances, 230));
                Task.Run(() => Customer(appliances, 100));
                Task.Run(() => Customer(appliances, 423));
                Task.Run(() => Customer(appliances, 110));
                Task.Run(() => Customer(appliances, 600));
            }
        }

        public static void Provider(BlockingCollection<int> blockingCollection, int timeMs, int id)
        {
            Thread.Sleep(timeMs);
            blockingCollection.Add(id);
            int[] a = blockingCollection.ToArray();
            string tmp = $"+{id} Storage: ";
            for (int z = 0; z < a.Length; z++)
            {
                tmp += $"{a[z]} ";
            }
            Console.WriteLine(tmp);

        }

        public static void Customer(BlockingCollection<int> blockingCollection, int timeMs)
        {
            Thread.Sleep(timeMs);
            if (blockingCollection.Count != 0)
            {
                blockingCollection.TryTake(out int i);
                string tmp = $"-{i} Storage: ";

                int[] a = blockingCollection.ToArray();
                for (int z = 0; z < a.Length; z++)
                {
                    tmp += $"{a[z]} ";
                }
                Console.WriteLine(tmp);
            }
            else { Console.WriteLine("Customer leave"); }

        }
    }
}
