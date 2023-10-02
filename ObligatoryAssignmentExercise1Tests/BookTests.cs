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
    public class BookTests
    {
        [TestMethod()]
        public void ValidateTests()
        {
            /// Validate Id
            Book c0 = new Book(0, "A Car of Sorts", 28);
            Book cneg1 = new Book(-1, "Not a Car", 28);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c0.ValidateId());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cneg1.ValidateId());

            /// Validate Title
            Book c1 = new Book(1, null, 28);
            Book c2 = new Book(2, "j", 28);

            Book c3 = new Book(3, "A Pretty Good Car", 28);

            Assert.ThrowsException<ArgumentNullException>(() => c1.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => c2.ValidateTitle());

            c3.ValidateTitle();

            /// Validate Price
            Book c4 = new Book(4, "A Pretty Bad Car", -63);
            Book ISWEARTHISUSEDTOBEABOUTCARS = new Book(99999, "Something About A Car", 100000);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c4.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ISWEARTHISUSEDTOBEABOUTCARS.ValidatePrice());

            c3.ValidatePrice();

            /// Validate All
            c3.Validate();

            /// It should catch the different exceptions too without crashing
            c1.Validate(); /// Null
            c2.Validate(); /// Basic
            c4.Validate(); /// OutOfRange
        }
    }
}