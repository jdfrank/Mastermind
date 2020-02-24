using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mastermind
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_TargetNumber_Creation()
        {
            // won't compile, that's good
            //var tn = new TargetNumber();

            var tn = new TargetNumber(4,1,6);
            //4, 1, 6);

            //position too low
            Assert.ThrowsException<ArgumentException>(() => tn.CheckDigit(-1, 4));

            // position too high
            Assert.ThrowsException<ArgumentException>(() => tn.CheckDigit(12, 4));

            // number too low
            Assert.ThrowsException<ArgumentException>(() => tn.CheckDigit(12, -1));

            // number too high
            Assert.ThrowsException<ArgumentException>(() => tn.CheckDigit(12, 8));
        }
    }
}
