using System.Text;

namespace Day3
{
  public class JoltageCalculator
  {
    public JoltageCalculator() { }
    public static StringBuilder GetLargestJoltageFromBank(int[] digits, int targetLength)
    {
      var maxJoltage = new StringBuilder();
      int startIndex = -1;

      for (int digitsUsed = 0; digitsUsed < targetLength; digitsUsed++)
      {
        startIndex += 1;
        int endIndex = digits.Length - targetLength + digitsUsed;

        for (int i = startIndex; i <= endIndex; i++)
        {
          if (digits[i] > digits[startIndex])
          {
            startIndex = i;
          }
        }
        maxJoltage.Append(digits[startIndex]);
      }

      return maxJoltage;
    }

    public static long TotalOutputJoltage(string[] banks, int joltageLength)
    {
      long totalJoltage = 0;
      foreach (string bank in banks)
      {
        int[] digitBank = [.. bank.Select(c => c - '0')];
        totalJoltage += long.Parse(GetLargestJoltageFromBank(digitBank, joltageLength).ToString());
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
      int partOneJoltageLength = 2;
      int partTwoJoltageLength = 12;
      long partOneTotal = TotalOutputJoltage(banks, partOneJoltageLength);
      long partTwoTotal = TotalOutputJoltage(banks, partTwoJoltageLength);
      Console.WriteLine("Part 1 Total Joltage: {0:G}", partOneTotal);
      Console.WriteLine("Part 2 Total Joltage: {0:G}", partTwoTotal);

    }
  }
}
