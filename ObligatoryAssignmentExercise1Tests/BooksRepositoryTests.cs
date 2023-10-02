using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoryAssignmentExercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoryAssignmentExercise1.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
        [TestMethod()]
        public void GetTest()
        {
            BooksRepository br = new BooksRepository();

            List<Book> wantTwoResults = br.Get("el");
            Assert.AreEqual(2, wantTwoResults.Count);

            List<Book> wantBookOne0 = br.Get(null, "titlE");
            Assert.AreEqual("A Classic", wantBookOne0[0].Title);

            List<Book> wantBookOne = br.Get(null, "titlEasc");
            Assert.AreEqual("A Classic", wantBookOne[0].Title);

            List<Book> wantBookTwo = br.Get(null, "titledesc");
            Assert.AreEqual("B Sequel", wantBookTwo[0].Title);

            List<Book> wantBookFour0 = br.Get(null, "price");
            Assert.AreEqual("A Reboot", wantBookFour0[0].Title);

            List<Book> wantBookFour = br.Get(null, "priceasc");
            Assert.AreEqual("A Reboot", wantBookFour[0].Title);

            List<Book> wantBookFive = br.Get(null, "pricedesc");
            Assert.AreEqual("A Last Hurrah", wantBookFive[0].Title);

            Assert.ThrowsException<ArgumentException>(() => br.Get(null, "idk"));

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            BooksRepository br = new BooksRepository();

            string expectedResult = "A Prequel";
            string actualResult = br.GetById(3).Title;
            Book? nullResult = br.GetById(9999);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsNull(nullResult);
        }

        [TestMethod()]
        public void AddTest()
        {
            BooksRepository br = new BooksRepository();

            Book b6 = new Book(89, "A Second Chance", 800);
            br.Add(b6);

            Assert.IsNotNull(br.GetById(6));
        }
    }
}