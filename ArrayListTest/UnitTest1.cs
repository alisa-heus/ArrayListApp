using NUnit.Framework;
using ArrayListLib;

namespace ArrayListTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Append_WhenAppendElement_ShouldAddElementToEnd(int element)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Append(element);
            int lastElementIndex = arrayList.GetLength() - 1;
            Assert.AreEqual(element, arrayList.GetElementByIndex(lastElementIndex));
        }
        
        [TestCase(1, new[] { 1, 2, 3, 4 }, new[] { 1, 1, 2, 3, 4 })]
        [TestCase(0, new int[0], new[] {0})]
        public void Prepend_WhenPrependElement_ShouldAddElementToBeginnng(int element, int[] sourceArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                arrayList.Append(sourceArray[i]);
            }

            arrayList.Prepend(element);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], arrayList.GetElementByIndex(i));
            }
        }

        [TestCase(1, 3, new[] {1, 2, 3, 4}, new[] {1, 2, 3, 1, 4 })]
        [TestCase(0, 0, new int[0], new[] { 0 })]
        public void AddValueByIndex_ShouldAddValueByIndex(int element, int index, int[] sourceArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                arrayList.Append(sourceArray[i]);
            }

            arrayList.AddValueByIndex(element, index);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], arrayList.GetElementByIndex(i));
            }
        }

        [TestCase(new[] {1, 2, 3, 4 }, new[] {1, 2, 3})]
        [TestCase(new int[0], new int [0])]
        public void EraseLastElement_ShouldEraseLastElementInArray(int[] sourceArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                arrayList.Append(sourceArray[i]);
            }

            arrayList.EraseLastElement();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], arrayList.GetElementByIndex(i));
            }
        }

        [TestCase(new[] {1, 2, 3, 4}, new[] {2, 3, 4})]
        [TestCase(new int[0], new int[0])]
        public void EraseFirstElement_ShouldEraseFirstElementInArray(int[] sourceArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                arrayList.Append(sourceArray[i]);
            }

            arrayList.EraseFirstElement();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], arrayList.GetElementByIndex(i));
            }
        }

        [TestCase(1, new[] { 1, 2, 3, 4 }, new[] { 1, 3, 4})]
        public void EraseByIndex_ShouldEraseElementByIndex(int index, int[] sourceArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                arrayList.Append(sourceArray[i]);
            }

            arrayList.EraseByIndex(index);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], arrayList.GetElementByIndex(i));
            }
        }

        [TestCase(3, new[] { 1, 2, 3, 4 }, new[] {1})]
        [TestCase(4, new[] { 1, 2, 3, 4 }, new int [0])]
        public void EraseElementsFromEnd_ShouldEraseCertainAmountOfElementsByFromEnd(int elements, int[] sourceArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                arrayList.Append(sourceArray[i]);
            }

            arrayList.EraseElementsFromEnd(elements);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], arrayList.GetElementByIndex(i));
            }
        }
    }
}