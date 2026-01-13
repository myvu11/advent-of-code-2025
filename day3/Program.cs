namespace Day3
{
  public class JoltageCalculator
  {
    public JoltageCalculator() { }
    public string GetLargestJoltageFromBank(string bank)
    {
      List<int> digitBank = [.. bank.Select(c => c - '0')];
      int indexMaxDigit = digitBank.FindIndex(e => e == digitBank.Max());
      if (indexMaxDigit == digitBank.Count - 1)
      {
        List<int> digitBankLastOmitted = [.. digitBank.SkipLast(1)];
        indexMaxDigit = digitBank.FindIndex(e => e == digitBankLastOmitted.Max());
      }
      string highestDigit = digitBank[indexMaxDigit].ToString();
      string max = highestDigit;

      for (int i = indexMaxDigit + 1; i < digitBank.Count; i++)
      {
        string cur = highestDigit + digitBank[i].ToString();
        max = Int32.Parse(cur) < Int32.Parse(max) ? max : cur;
      }

      return max;
    }

    public int TotalOutputJoltage(string[] banks)
    {
      int totalJoltage = 0;
      foreach (string bank in banks)
      {
        totalJoltage += Int32.Parse(GetLargestJoltageFromBank(bank));
      }
      return totalJoltage;
    }


    public static string[] GetBanksFromFile(string path)
    {
      string[] banks = File.ReadAllLines(path);
      return banks;
    }

    public static void Main()
    {
      string path = Path.Combine(AppContext.BaseDirectory, "Input", "day3-input.txt");
      JoltageCalculator calculator = new();
      string[] banks = GetBanksFromFile(path);
      int total = calculator.TotalOutputJoltage(banks);
      Console.WriteLine("Total joltage: {0:G}", total);

    }
  }
}
