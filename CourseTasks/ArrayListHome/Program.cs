using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ArrayListHome
{
    class Program
    {
        public static void DeleteEvenNumbers(List<int> userList)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i] % 2 == 0)
                {
                    userList.RemoveAt(i);
                    i--;
                }
            }
            userList.TrimExcess();
        }

        public static List<int> GetListWithoutRepetitions(List<int> userList)
        {
            List<int> userIntListWithoutRepetitions = new List<int>(userList.Count);

            for (int i = 0; i < userList.Count; i++)
            {
                if (!userIntListWithoutRepetitions.Contains(userList[i]))
                {
                    userIntListWithoutRepetitions.Add(userList[i]);
                }
            }
            userIntListWithoutRepetitions.TrimExcess();

            return userIntListWithoutRepetitions;
        }

        static void Main(string[] args)
        {
            List<string> userList = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader("file.txt"))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        userList.Add(currentLine);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
            Console.WriteLine();

            DeleteEvenNumbers(userIntList);
            foreach (int e in userIntList)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 100));

            List<int> userIntList2 = new List<int> { 3, 4, 4, 56, 7, 3, 88, 3, 45 };
            foreach (int e in userIntList2)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            List<int> userIntListWithoutRepetitions = GetListWithoutRepetitions(userIntList2);
            foreach (int e in userIntListWithoutRepetitions)
            {
                Console.Write(e + " ");
            }
        }
    }
}
