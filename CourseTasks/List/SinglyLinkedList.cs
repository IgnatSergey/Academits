using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;
        private int count;

        public SinglyLinkedList()
        {
        }

        public int GetLength()
        {
            return count;
        }

        public void AddItem(T element)
        {
            ListItem<T> p = new ListItem<T>(element, head);
            head = p;
            count++;
        }

        public override string ToString()
        {
            StringBuilder lineList = new StringBuilder();
            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                lineList.Append(p + Environment.NewLine);
            }

            return lineList.ToString();
        }

        public T GetFirsItem()
        {
            if (count == 0)
            {
                throw new ArgumentException("Список пуст");
            }

            return head.Data;
        }
    }
}
