using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challange2_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime claim = new DateTime(2021, 08, 21);
            DateTime incident1 = new DateTime(2021, 08, 1);
            DateTime incident2 = new DateTime(2021, 07, 1);

            TimeSpan length = claim - incident1;
            TimeSpan length2 = claim - incident2;

            bool greaterThan30 = length2.TotalDays > 30;
            Console.WriteLine(length);
            Console.WriteLine(length2);

            Assert.IsTrue(greaterThan30);
        }
    }
}
