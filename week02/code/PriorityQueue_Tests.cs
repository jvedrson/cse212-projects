using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:  Enqueue multiple items with different priorities and then Dequeue all items
    // in order of priority.
    // Expected Result:  "D", "E", "A", "C", "B"
    // Defect(s) Found:
    // 1. The for loop condition should be index < _queue.Count and not index < _queue.Count - 1,
    //    because it skips the last item in the list.
    // 2. It was required to call _queue.RemoveAt(highPriorityIndex) to remove the high priority
    //    item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 4);

        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different and equal priorities and then Dequeue all items
    // in order of priority and insertion.
    // Expected Result:  "C", "D", "A", "B", "E"
    // Defect(s) Found:
    // 1. It was required the previous changes in TestPriorityQueue_1 to make this test work.
    // 2. The comparison in the if statement should be > instead of >= to ensure that items with the same
    // priority are dequeued in the order they were enqueued.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 4);
        priorityQueue.Enqueue("D", 4);
        priorityQueue.Enqueue("E", 2);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result:  Exception should be thrown with appropriate error message.
    // Defect(s) Found: None detected.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}