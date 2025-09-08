using System.Diagnostics;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Iterate from 1 to "length"
        // 2. Save the new value after multiplying it on each iteration into a list called "results"
        // 3. Return "results" List as Array using spread method

        List<double> results = [];

        for (int i = 1; i <= length; i++)
        {
            results.Add(number * i);
        }

        return [.. results];
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Validate "amount" is not greater than List.Count
        // 2. Get lastElements according to the "amount" using getRange.
        // 3. Remove elements from the List with RemoveRange.
        // 4. Add the lastElements at the beginning using InsertRange

        if (amount > data.Count)
        {
            Console.WriteLine("Error: According to 'data', the 'amount' value must be <= " + data.Count);
            return;
        }

        var startFromIndex = data.Count - amount;
        var lastElements = data.GetRange(startFromIndex, amount);
        data.RemoveRange(startFromIndex, amount);
        data.InsertRange(0, lastElements);
    }
}
