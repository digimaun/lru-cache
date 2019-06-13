using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using LRU;

namespace LRU
{
    [TestClass]
    public class LRUCacheTests
    {
        [TestMethod]
        public void BasicTests()
        {
            LRUCache cache = new LRUCache(2);         //capacity

            cache.Put("1", "1");
            cache.Put("2", "2");
            Assert.AreEqual("1", cache.Get("1"));     // returns 1
            
            cache.Put("3", "3");                      // evicts key 2
            Assert.IsNull(cache.Get("2"));            // returns null (not found)
            
            cache.Put("4", "4");                      // evicts key 1
            Assert.IsNull(cache.Get("1"));            // returns null (not found)
            
            Assert.AreEqual("3", cache.Get("3"));     // returns 3
            Assert.AreEqual("4", cache.Get("4"));     // returns 4

            var seq = cache.GetKeySequence();
            Assert.IsTrue(seq.SequenceEqual(new string[] { "4", "3" }));
        }
    }
}
