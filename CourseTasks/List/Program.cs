using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> userList = new SinglyLinkedList<int>();

            //userList.AddItem(3);
            //userList.AddItem(7);
            //userList.AddItem(10);
            //userList.AddItem(8);
            //userList.AddItem(1);

            Console.WriteLine(userList);
            Console.WriteLine(userList.GetLength());
            Console.WriteLine(userList.GetFirsItem());
        }
    }
}
