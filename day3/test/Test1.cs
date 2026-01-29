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
        string bank = "987654321111111";
        int[] digitBank = [.. bank.Select(c => c - '0')];
        string actual = JoltageCalculator.GetLargestJoltageFromBank(digitBank, 2).ToString();
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
            int[] digitBank = [.. banks[i].Select(c => c - '0')];
            actual[i] = JoltageCalculator.GetLargestJoltageFromBank(digitBank, 2).ToString();
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
        long actual = JoltageCalculator.TotalOutputJoltage(banks, 2);
        long expected = 357;
        Assert.AreEqual(expected, actual);

    }
    [TestMethod]
    public void GetTotalJoltageTwelveDigits()
    {
        JoltageCalculator calculator = new();
        string path = Path.Combine(AppContext.BaseDirectory, "Input", "day3-input-simple.txt");
        string[] banks = JoltageCalculator.GetBanksFromFile(path);
        long actual = JoltageCalculator.TotalOutputJoltage(banks, 12);
        long expected = 3121910778619;
        Assert.AreEqual(expected, actual);
    }
}
