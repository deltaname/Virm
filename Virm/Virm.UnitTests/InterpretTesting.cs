using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Virm.Core;
using Virm.Core.Entities;
using Virm.Core.Interfaces;

namespace Virm.UnitTests
{
    [TestCategory("Interpreter")]
    [TestClass]
    public class InterpretTesting
    {
        [TestMethod]
        [Description("Check int input")]
        public void InputNumInt()
        {
            VirmInterpreter intp = new VirmInterpreter();
            IVirmUnit value;

            int numb = 32;

            value = intp.InterpretLine($"num {numb}");

            Assert.AreEqual(typeof(VirmNum), value.GetType());
            Assert.AreEqual(numb, ((VirmNum)value).Data);
        }

        [TestMethod]
        [Description("Check float input")]
        public void InputNumFloat()
        {
            VirmInterpreter intp = new VirmInterpreter();
            IVirmUnit value;

            float numb = 33.35f;
            value = intp.InterpretLine($"num {numb}");

            Assert.AreEqual(typeof(VirmNum), value.GetType());
            Assert.AreEqual(numb, ((VirmNum)value).Data);
        }

        [TestMethod]
        [Description("Check command input")]
        public void InputCommand()
        {

        }


    }
}
