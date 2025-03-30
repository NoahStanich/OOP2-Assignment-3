using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LinkedListTest
{
    public class LinkedListTest
    {
        private SLL list;

        [SetUp]
        public void SetUp()
        {
            list = new SLL();
        }

        [TearDown]
        public void TearDown()
        {
            list = null;
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestAppend()
        {
            list.Append("A");
            Assert.That(list.Retrieve(0), Is.EqualTo("A"));
        }

        [Test]
        public void TestPrepend()
        {
            list.Prepend("B");
            list.Prepend("A");
            Assert.That(list.Retrieve(0), Is.EqualTo("A"));
        }

        [Test]
        public void TestInsert()
        {
            list.Append("A");
            list.Append("C");
            list.Insert("B", 1);
            Assert.That(list.Retrieve(1), Is.EqualTo("B"));
        }

        [Test]
        public void Replace()
        {
            list.Append("A");
            list.Append("B");
            list.Replace("C", 1);
            Assert.That(list.Retrieve(1), Is.EqualTo("C"));
        }

        [Test]
        public void TestDelete()
        {
            list.Append("A");
            list.Append("B");
            list.Delete(0);
            Assert.That(list.Retrieve(0), Is.EqualTo("B"));
        }

        //[Test]
        //public void TestSerialization()
        //{
        //    list.Append("A");
        //    byte[] data = list.Serialize();
        //    SLL deserializedList = SLL.Deserialize(data);
        //    Assert.AreEqual("A", deserializedList.GetAt(0));
        //}
    }

}
