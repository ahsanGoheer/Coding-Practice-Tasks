using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDay1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(2);
            linkedList.Add(6);
            linkedList.Add(8);
            
            Console.WriteLine(linkedList);

            HashTable<int> newTable = new HashTable<int>(5);

            newTable.Add("One", 1);
            newTable.Add("Two", 2);
            newTable.Add("Three", 3);
            newTable.Add("Four", 4);

            Console.WriteLine(newTable.Get("Four"));
            Console.ReadKey();

        }
    }
}
