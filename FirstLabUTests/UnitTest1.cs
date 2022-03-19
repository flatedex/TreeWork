using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using FirstLab;

namespace FirstLabUTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string expectation1 = "49 40 35 34 23 55 92 98 ";
        private const string expectation2 = "49 15 2 1 71 ";
        [TestMethod]
        public void TestMethod1()
        {
            List<Int32> data = new List<Int32> { 34, 92, 98, 23, 40, 35, 55, 49 };
            Tree tree = new Tree();
            foreach (Int32 i in data)
            {
                tree.InsertNode(i);
            }
            List<Int32> check = new List<Int32>();
            FileWork.PreOrder(tree.root, check);
            String text = "";
            foreach (Int32 item in check)
            {
                text += item.ToString() + " ";
            }
            Assert.AreEqual(expectation1, text);
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<Int32> data = new List<Int32> { 71, 49, 15, 56, 2, 1 };
            Tree tree = new Tree();
            foreach (Int32 i in data)
            {
                tree.InsertNode(i);
            }
            tree.DeleteNode(56);
            List<Int32> check = new List<Int32>();
            FileWork.PreOrder(tree.root, check);
            String text = "";
            foreach (Int32 item in check)
            {
                text += item.ToString() + " ";
            }
            Assert.AreEqual(expectation2, text);
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<Int32> data = new List<Int32> { };
        }
    }
}
