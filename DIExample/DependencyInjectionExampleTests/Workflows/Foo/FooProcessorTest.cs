using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjectionExample;
using System.Collections.Generic;

namespace DependencyInjectionExampleTests.Workflows.Foo
{
    [TestClass]
    public class FooProcessorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "items")]
        public void NullItems_Process_Throws()
        {
            IEnumerable<Item> items = null;
            var proc = new FooProcessor();

            proc.ProcessFoos(items);
        }

        [TestMethod]
        public void EmptyItems_Process_ReturnsEmptyResults()
        {
            IEnumerable<Item> items = new Item[]{};
            var proc = new FooProcessor();

            IEnumerable<FooItem> result = proc.ProcessFoos(items);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OneValidItem_Process_ReturnsOneResult()
        {
            IEnumerable<Item> items = new Item[] 
            {
                new Item(){ IsFoo = true }
            };
            var proc = new FooProcessor();

            IEnumerable<FooItem> result = proc.ProcessFoos(items);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void ThreeValidItems_Process_ReturnsThreeResults()
        {
            IEnumerable<Item> items = new Item[] 
            {
                new Item(){ IsFoo = true },
                new Item(){ IsFoo = true },
                new Item(){ IsFoo = true }
            };
            var proc = new FooProcessor();

            IEnumerable<FooItem> result = proc.ProcessFoos(items);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void OneValidItemOneInvalidItem_Process_ReturnsOneResult()
        {
            IEnumerable<Item> items = new Item[] 
            {
                new Item(){ IsFoo = true },
                new Item(){ IsFoo = false }
            };
            var proc = new FooProcessor();

            IEnumerable<FooItem> result = proc.ProcessFoos(items);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void ThreeValidItemsThreeInvalidItems_Process_ReturnsThreeResults()
        {
            IEnumerable<Item> items = new Item[] 
            {
                new Item(){ IsFoo = true },
                new Item(){ IsFoo = false },
                new Item(){ IsFoo = true },
                new Item(){ IsFoo = false },
                new Item(){ IsFoo = true },
                new Item(){ IsFoo = false }
            };
            var proc = new FooProcessor();

            IEnumerable<FooItem> result = proc.ProcessFoos(items);
            Assert.AreEqual(3, result.Count());
        }
    }
}
