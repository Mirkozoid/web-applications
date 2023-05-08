using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {         
            var linkedList = new LinkedList<int>();
            Console.WriteLine("How many datas do you wanna enter ?");
            int quantity = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < quantity; i++)
            {
               linkedList.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("default");
            PrintLinkedList(linkedList);
            linkedList.Insert(2, 4);
            Console.WriteLine("after insert");
            PrintLinkedList(linkedList);
            linkedList.Sort();
            Console.WriteLine("aster sort");
            PrintLinkedList(linkedList);
            linkedList.Reverse();
            Console.WriteLine("after reverse");
            PrintLinkedList(linkedList);
            linkedList.Delete(2);
            Console.WriteLine("after delete");
            PrintLinkedList(linkedList);
            Console.ReadKey();
                
        }
        private static void PrintLinkedList(LinkedList<int> linkedList)
        {
            foreach (var item in linkedList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
