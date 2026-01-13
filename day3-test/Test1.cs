using Day3;

namespace day3_test;

[TestClass]
public sealed class Test1
{
    // [TestMethod]
    public void GetBanksFromFile()
    {
        JoltageCalculator calculator = new();
        string path = Path.Combine(AppContext.BaseDirectory, "Input", "day3-input-simple.txt");
        string[] banks = JoltageCalculator.GetBanksFromFile(path);
        string[] expected = ["987654321111111", "811111111111119", "234234234234278", "818181911112111"];
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], banks[i]);
        }

    }
    [TestMethod]
    public void ConvertToIntArray()
    {
        JoltageCalculator calculator = new();
        string banks = "987654321111111";
        string actual = calculator.GetLargestJoltageFromBank(banks);
        string expected = "98";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetLargestVoltageFromSmallBanks()
    {
        JoltageCalculator calculator = new();
        string path = Path.Combine(AppContext.BaseDirectory, "Input", "day3-input-simple.txt");
        string[] banks = JoltageCalculator.GetBanksFromFile(path);
        string[] expected = ["98", "89", "78", "92"];
        string[] actual = new string[banks.Length];
        for (int i = 0; i < banks.Length; i++)
        {
            actual[i] = calculator.GetLargestJoltageFromBank(banks[i]);
        }
        for (int i = 0; i < banks.Length; i++)
        {
            Assert.AreEqual(expected[i], actual[i]);
        }
    }
    [TestMethod]
    public void GetTotalJoltage()
    {
        JoltageCalculator calculator = new();
        string path = Path.Combine(AppContext.BaseDirectory, "Input", "day3-input-simple.txt");
        string[] banks = JoltageCalculator.GetBanksFromFile(path);
        int actual = calculator.TotalOutputJoltage(banks);
        int expected = 357;
        Assert.AreEqual(expected, actual);

    }
}
