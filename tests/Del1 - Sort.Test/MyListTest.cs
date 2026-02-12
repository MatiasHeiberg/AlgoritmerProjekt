using Algoritmer_Projekt;
using System.Linq;
namespace Del1_Sort.Test
{
    /// <summary>
    /// Test-klasse for MyList sorteringsfunktionalitet.
    /// Tester både BubbleSort og InsertionSort algoritmer med forskellige scenarier.
    /// </summary>
    [TestClass]
    public class MyListTest
    {
        /// <summary>
        /// Tester at BubbleSort kaster ArgumentException når listen er tom.
        /// </summary>
        [TestMethod]
        public void SortTest_sortereTomListeMedBubble_returnererArgumentException()     //MetodeTest_Scenarie_ForventetResultat
        {
            // Arrange
            var list = new MyList<int>();

            // Assert
            Assert.Throws<ArgumentException>(() => list.Sort(algorithm: 0));            // 0 = bubble sort
        }

        /// <summary>
        /// Tester at InsertionSort kaster ArgumentException når listen er tom.
        /// </summary>
        [TestMethod]
        public void SortTest_sortereTomListeMedInsertion_returnererArgumentException()  
        {
            // Arrange
            var list = new MyList<int>();

            // Assert
            Assert.Throws<ArgumentException>(() => list.Sort(algorithm: 1));            // 1 = insertion sort
        }

        /// <summary>
        /// Tester at BubbleSort håndterer en liste med kun ét element korrekt.
        /// Listen skal forblive uændret.
        /// </summary>
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

        /// <summary>
        /// Tester at InsertionSort håndterer en liste med kun ét element korrekt.
        /// Listen skal forblive uændret.
        /// </summary>
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


        /// <summary>
        /// Datadrevet test for InsertionSort med forskellige scenarier.
        /// Tester average case, allerede sorteret, reverse sorteret, dubletter og negative tal.
        /// </summary>
        /// <param name="input">Input-listen der skal sorteres.</param>
        /// <param name="expected">Den forventede sorterede liste.</param>
        [DataTestMethod]                                                                
        [DynamicData(nameof(GetSortTestData), DynamicDataSourceType.Method)]            //Henter testdata fra GetSortTestData-metoden

        public void SortTest_VariousLists_InsertionSort_SortedCorrectly(List<int> input, List<int> expected)
        {
            //Arrange                                                                   
            MyList<int> result = ConvertToMyList(input);
            MyList<int> expectedList = ConvertToMyList(expected);

            //Act
            result.Sort(algorithm: 1);

            //Assert
            CollectionAssert.AreEqual(expectedList, result);

        }

        /// <summary>
        /// Datadrevet test for BubbleSort med forskellige scenarier.
        /// Tester average case, allerede sorteret, reverse sorteret, dubletter og negative tal.
        /// </summary>
        /// <param name="input">Input-listen der skal sorteres.</param>
        /// <param name="expected">Den forventede sorterede liste.</param>
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

        /// <summary>
        /// Leverer testdata til de datadrevne tests.
        /// Inkluderer scenarier for tilfældige tal, sorterede lister, reverse sorterede lister,
        /// dubletter og negative tal.
        /// </summary>
        /// <returns>En samling af test-cases with input og forventet output.</returns>
        private static IEnumerable<object[]> GetSortTestData()
        {
            yield return new object[] { new List<int> { 5, 3, 8, 9, 2 }, new List<int> { 2, 3, 5, 8, 9 } }; // Tilfældige tal, average case
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 } }; // Sorteret 
            yield return new object[] { new List<int> { 5, 4, 3, 2, 1 }, new List<int> { 1, 2, 3, 4, 5 } }; // Sorteret reverse
            yield return new object[] { new List<int> { 2, 2, 1, 3, 3 }, new List<int> { 1, 2, 2, 3, 3 } }; // Flere ens tal
            yield return new object[] { new List<int> { -1, -3, 2, 3 }, new List<int> { -3, -1, 2, 3 } };   // Minus tal
        }

        /// <summary>
        /// Hjælpemetode til at konvertere en standard List til MyList.
        /// Bruges til at forberede testdata.
        /// </summary>
        /// <param name="value">Listen der skal konverteres.</param>
        /// <returns>En MyList med samme elementer.</returns>
        private MyList<int> ConvertToMyList(List<int> value)
        {
            MyList<int> list = new MyList<int>();
            foreach (var i in value)
                list.Add(i); return list;
        }
    }
}
