using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public class Program
    {

        public static List<string> getSortedLastNameFromFullName(List<string> names, out Dictionary<string, string> pairOfNameAndLastName)
        {
            List<string> lastNames = new List<string>();
            pairOfNameAndLastName = new Dictionary<string, string>();

            foreach (string name in names)
            {
                List<string> wordsPerName = name.Split(' ').ToList();
                int wordsCountPerName = wordsPerName.Count - 1;
                string lastName = wordsPerName[wordsCountPerName];

                lastNames.Add(lastName);
                pairOfNameAndLastName.Add(name, lastName);

            }

            lastNames.Sort();

            return lastNames;

        }

        public static void writeTextToScreenAndFile(string filePath, List<string> lastNames, Dictionary<string, string> pairOfNameAndLastName)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filePath))
            {
                foreach (var eachLastName in lastNames)
                {
                    string fullName = pairOfNameAndLastName.FirstOrDefault(x => x.Value == eachLastName).Key;
                    Console.WriteLine(fullName);
                    file.WriteLine(fullName);
                }
            }
        }

        public static void printFullNameBasedOnSortedLastName(List<string> lastNames, Dictionary<string, string> pairOfNameAndLastName, string outputFilePath)
        {

            if (!File.Exists(outputFilePath))
            {
                File.Create(outputFilePath);

                writeTextToScreenAndFile(outputFilePath, lastNames, pairOfNameAndLastName);

            }
            else if (File.Exists(outputFilePath))
            {

                writeTextToScreenAndFile(outputFilePath, lastNames, pairOfNameAndLastName);

            }

        }

        public static List<string> ReadFileAndReturnContents(string filePath)
        {
            List<string> contents = System.IO.File.ReadAllLines(filePath).ToList();

            return contents;
        }

        public static void Main(string[] args)
        {

            List<string> names = new List<string>();
            string inputFilePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Name Sorter\Sorter\Sorter\Files\unsorted-names-list.txt";
            string outputFilePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Name Sorter\Sorter\Sorter\Files\sorted-names-list.txt";

            Dictionary<string, string> pairOfNameAndLastName = new Dictionary<string, string>();

            //read file content
            List<string> contents = ReadFileAndReturnContents(inputFilePath);

            //add file content to variable names
            contents.ForEach(x => names.Add(x));

            //get sorted last name 
            List<string> lastNames = getSortedLastNameFromFullName(names, out pairOfNameAndLastName);

            //print full name based on sorted last name
            printFullNameBasedOnSortedLastName(lastNames, pairOfNameAndLastName, outputFilePath);

            Console.Read();

        }
    }
}
