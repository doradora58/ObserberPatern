using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserberPatern;
using System;

namespace ObserberPaternTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new WarningTimerMock();
            var vm = new MainViewModel(null, mock);
            Assert.AreEqual("aaa", vm.WarningLabelText);
            mock.Change(true);
            Assert.AreEqual("Warning", vm.WarningLabelText);
            mock.Change(false);
            Assert.AreEqual("Normal", vm.WarningLabelText);

        }
    }
    internal class WarningTimerMock : WarningTimerBase
    {
        internal void Change(bool isWarning)
        {
            this.IsWarning = isWarning;
        }
    }
}
