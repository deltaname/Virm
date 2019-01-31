using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Virm.Core;
using Virm.Core.LangStructures;
using Virm.Core.LangStructures.Exceptions;

namespace Virm.UnitTests
{
    [TestCategory("Lang Structures")]
    [TestClass]
    public class LangStructuresTesting
    {
        [TestMethod]
        public void VirmNumFromFloat()
        {
            float num = 5.252f;
            var virm = new VirmNum().Create(num);

            Assert.AreEqual(num, virm.Data);
        }

        [TestMethod]
        public void VirmNumFromInt()
        {
            int num = 1324;
            var virm = new VirmNum().Create(num);

            Assert.AreEqual(num, Convert.ToInt16(virm.Data));
        }
        
        [TestMethod]
        public void VirmStringFromString()
        {
            string str = "Hello, Test!";
            var virm = new VirmString().Create(str);

            Assert.AreEqual(str, virm.Data);
        }

        [ExpectedException(typeof(VirmArgumentException))]
        [TestMethod]
        public void VirmNullSetData()
        {
            var virm = new VirmNull();
            virm.Data = 1;
        }

        [ExpectedException(typeof(VirmCreationException))]
        [TestMethod]
        public void VirmNullCreation()
        {
            var virm = new VirmNull().Create(null);
        }

        [ExpectedException(typeof(VirmArgumentException))]
        [TestMethod]
        public void VirmNullGetData()
        {
            var virm = new VirmNull();
            var a = virm.Data;
        }

        [TestMethod]
        public void VirmMethodCreationAndUsing()
        {
            Func<int, int, int> func = delegate (int x, int y)
            {
                return x + y;
            };
            
            var virm = new VirmMethod("Addition")
                .Create(func) 
                as VirmMethod;

            Assert.AreEqual(typeof(int), virm.GetReturnType());
            Assert.AreEqual(17, virm.Execute(new object[] { 10, 7 }));
        }

    }
}
