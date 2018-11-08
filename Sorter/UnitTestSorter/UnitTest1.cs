using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Sorter;
using System.Linq;

namespace UnitTestSorter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInputContent()
        {
            //Arrange
            string inputFilePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Name Sorter\Sorter\Sorter\Files\unsorted-names-list.txt";
            List<string> expectedContents = new List<string> { "Orson Milka Iddins", "Erna Dorey Battelle", "Flori Chaunce Franzel", "Odetta Sue Kaspar", "Roy Ketti Kopfen", "Madel Bordie Mapplebeck", "Selle Bellison", "Leonerd Adda Mitchell Monaghan", "Debra Micheli", "Hailey Avie Annakin" };

            //Act
            List<string> contents = Program.ReadFileAndReturnContents(inputFilePath);

            //Assert
            CollectionAssert.AreEqual(expectedContents, contents);

        }


        [TestMethod]
        public void TestOutputContent()
        {
            //Arrange
            string inputFilePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Name Sorter\Sorter\Sorter\Files\unsorted-names-list.txt";
            List<string> names = new List<string>();
            Dictionary<string, string> pairOfNameAndLastName = new Dictionary<string, string>();
            List<string> expectedOutput = new List<string> { "Hailey Avie Annakin", "Erna Dorey Battelle", "Selle Bellison", "Flori Chaunce Franzel", "Orson Milka Iddins", "Odetta Sue Kaspar", "Roy Ketti Kopfen", "Madel Bordie Mapplebeck", "Debra Micheli", "Leonerd Adda Mitchell Monaghan" };
            List<string> output = new List<string>();

            //Act
            List<string> contents = Program.ReadFileAndReturnContents(inputFilePath);
            contents.ForEach(x => names.Add(x));
            List<string> lastNames = Program.getSortedLastNameFromFullName(names, out pairOfNameAndLastName);


            foreach (var eachLastName in lastNames)
            {
                string fullName = pairOfNameAndLastName.FirstOrDefault(x => x.Value == eachLastName).Key;
                output.Add(fullName);
            }

            //Assert
            CollectionAssert.AreEqual(expectedOutput, output);

        }

    }
}
