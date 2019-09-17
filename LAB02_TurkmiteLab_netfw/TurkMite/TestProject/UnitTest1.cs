using System;
using TurkMite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWhiteFieldStep()
        {
            var t = new Turkmite();
            var ret = t.Step(t.White);
            Assert.AreEqual(-1, ret.deltaDirection);
            Assert.AreEqual(t.Black, ret.newColor);

              
        }
    }
}
