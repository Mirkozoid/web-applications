using System;
using System.Collections.Generic;
using LinkedList;

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
            foreach (var item in linkedList)
            {
               Console.Write(item + " ");
            }
            linkedList.Insert(7, 6);
            Console.WriteLine();
            foreach (var item in linkedList)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
                //  Console.WriteLine("Enter the number of the desired operation: \n" +
                //      "1: See the number under the index \n" +
                //      "2: Delete the number with the index \n" +
                //      "3: Delete an data with the value \n" +
                //      "4: Sorting list \n" +
                //      "5: Reverse list \n" +
                //      "6: Add a number to a specific index \n" +
                //      "7: Add new number");
                //  switch (Console.ReadLine())
                //  {
                //      case "1":

                //          break;
                //      case "2":

                //          break;
                //      case "3":

                //          break;
                //      case "4":

                //          break;
                //      case "5":

                //          break;
                //      case "6":

                //          break;
                //      case "7":

                //          break;
                //      default:
                //          break;
                //  }
        }
    }
}
