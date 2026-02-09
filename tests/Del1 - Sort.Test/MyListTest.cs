using Algoritmer_Projekt;
using System.Linq;
namespace Del1_Sort.Test
{
    [TestClass]
    public class MyListTest
    {
        [TestMethod]
        public void SortTest_sortereTomListeMedBubble_returnererArgumentException() //MetodeTest_Scenarie_ForventetResultat
        {
            // Arrange
            var list = new MyList<int>();

            // Assert
            Assert.Throws<ArgumentException>(() => list.Sort(algorithm: 0));
        }

        [TestMethod]
        public void SortTest_sortereTomListeMedInsertion_returnererArgumentException() //MetodeTest_Scenarie_ForventetResultat
        {
            // Arrange
            var list = new MyList<int>();

            // Assert
            Assert.Throws<ArgumentException>(() => list.Sort(algorithm: 1));
        }

        [TestMethod]
        public void SortTest_sortereListeMed1Element_uændretListe()
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
    }
}
