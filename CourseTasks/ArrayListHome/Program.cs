using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> userList = new List<string>();
            using (StreamReader reader = new StreamReader("file.txt"))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    userList.Add(currentLine);
                }
            }

            foreach (string e in userList)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(new string('-', 100));

            List<int> userIntList = new List<int> { 4, 56, 3, 7, -7, 36, 33 };
            foreach (int e in userIntList)
            {
                Console.Write(e + " ");
            }

            for (int i = 0; i < userIntList.Count(); i++)
            {
                if (userIntList[i] % 2 == 0)
                {
                    userIntList.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine();

            userIntList.TrimExcess();
            foreach (int e in userIntList)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 100));

            List<int> userIntList2 = new List<int> { 4, 4, 56, 4, 7, 7, 36, 56, 4, 100 };
            List<int> userIntListWithoutRepetitions = new List<int>(userIntList2.Count());

            foreach (int e in userIntList2)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            userIntListWithoutRepetitions.Add(userIntList2[0]);
            for (int i = 1; i < userIntList2.Count(); i++)
            {
                bool isNotRepetitions = true;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (userIntList2[j] == userIntList2[i])
                    {
                        isNotRepetitions = false;
                        break;
                    }
                }

                if (isNotRepetitions)
                {
                    userIntListWithoutRepetitions.Add(userIntList2[i]);
                }
            }

            userIntListWithoutRepetitions.TrimExcess();
            foreach (int e in userIntListWithoutRepetitions)
            {
                Console.Write(e + " ");
            }
        }
    }
}
