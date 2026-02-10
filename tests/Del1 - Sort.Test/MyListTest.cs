using Algoritmer_Projekt;
using System.Linq;
namespace Del1_Sort.Test
{
    [TestClass]
    public class MyListTest
    {
        [TestMethod]
        public void SortTest_sortereTomListeMedBubble_returnererArgumentException()     //MetodeTest_Scenarie_ForventetResultat
        {
            // Arrange
            var list = new MyList<int>();

            // Assert
            Assert.Throws<ArgumentException>(() => list.Sort(algorithm: 0));            // 0 = bubble sort
        }

        [TestMethod]
        public void SortTest_sortereTomListeMedInsertion_returnererArgumentException()  //MetodeTest_Scenarie_ForventetResultat
        {
            // Arrange
            var list = new MyList<int>();

            // Assert
            Assert.Throws<ArgumentException>(() => list.Sort(algorithm: 1));            // 1 = insertion sort
        }

        [TestMethod]
        public void SortTest_sortereListeMed1ElementBubbleSort_uændretListe()
        {
            // Arrenge
            MyList<int> result = new MyList<int>();
            result.Add(1);
            MyList<int> expected = new MyList<int>();
            expected.Add(1);

            // Act

            result.Sort(algorithm: 0);

            // Assert
            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [TestMethod]
        public void SortTest_sortereListeMed1ElementInsertionSort_uændretListe()
        {
            // Arrenge
            MyList<int> result = new MyList<int>();
            result.Add(1);
            MyList<int> expected = new MyList<int>();
            expected.Add(1);

            // Act

            result.Sort(algorithm: 1);

            // Assert
            Assert.IsTrue(result.SequenceEqual(expected));
        }


        [DataTestMethod]                                                                //Datadriven test, hvor vi kan teste flere scenarier med forskellige input og forventede resultater
        [DynamicData(nameof(GetSortTestData), DynamicDataSourceType.Method)]            //Henter testdata fra GetSortTestData-metoden

        public void SortTest_VariousLists_InsertionSort_SortedCorrectly(List<int> input, List<int> expected)
        {
            //Arrange                                                                   // Konverterer input og expected fra List<int> til MyList<int> for at kunne bruge vores Sort-metode
            MyList<int> result = ConvertToMyList(input);
            MyList<int> expectedList = ConvertToMyList(expected);

            //Act
            result.Sort(algorithm: 1);

            //Assert
            CollectionAssert.AreEqual(expectedList, result);

        }

        [DataTestMethod]
        [DynamicData(nameof(GetSortTestData), DynamicDataSourceType.Method)]
        public void SortTest_VariousLists_BubbleSort_SortedCorrectly(List<int> input, List<int> expected)
        {
            //Arrange
            MyList<int> result = ConvertToMyList(input);
            MyList<int> expectedList = ConvertToMyList(expected);

            //Act
            result.Sort(algorithm: 0);

            //Assert
            CollectionAssert.AreEqual(expectedList, result);
        }

        private static IEnumerable<object[]> GetSortTestData()
        {
            yield return new object[] { new List<int> { 5, 3, 8, 9, 2 }, new List<int> { 2, 3, 5, 8, 9 } };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<int> { 5, 4, 3, 2, 1 }, new List<int> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<int> { 2, 2, 1, 3, 3 }, new List<int> { 1, 2, 2, 3, 3 } };
            yield return new object[] { new List<int> { -1, -3, 2, 3 }, new List<int> { -3, -1, 2, 3 } };
        }

        private MyList<int> ConvertToMyList(List<int> value)
        {
            MyList<int> list = new MyList<int>();
            foreach (var i in value)
                list.Add(i); return list;
        }
    }
}
