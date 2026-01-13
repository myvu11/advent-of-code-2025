using System.Text.RegularExpressions;

namespace Day2
{
  public class ProductId
  {
    public ProductId() { }
    public bool IsRepeatedTwice(long productId)
    {
      string id = productId.ToString();
      if (id.Length % 2 != 0)
      { return false; }

      string first = id[0..(id.Length / 2)];
      string second = id[(id.Length / 2)..];

      return first.Equals(second);
    }

    public bool IsRepetitive(long productId)
    {
      string id = productId.ToString();
      for (int patternLength = 1; patternLength <= id.Length / 2; patternLength++)
      {

        if (id.Length % patternLength != 0) { continue; }
        bool allMatch = true;
        string pattern = id[..patternLength];

        for (int i = 1; i < id.Length / patternLength; i++)
        {
          int lowerBound = patternLength * i;
          int upperBound = lowerBound + patternLength;
          string toCompare;

          if (lowerBound != upperBound)
          {
            toCompare = id[lowerBound..upperBound];
          }
          else
          {
            toCompare = id[lowerBound].ToString();

          }

          if (pattern != toCompare)
          {
            allMatch = false;
            break;
          }
        }

        if (allMatch)
        {
          return true;
        }
      }
      return false;
    }

    public List<long> GetInvalidIdsFromRange(string range)
    {
      string[] bounds = range.Split('-');
      long lower = long.Parse(bounds[0]);
      long upper = long.Parse(bounds[1]);
      List<long> results = [];

      for (long i = lower; i <= upper; i++)
      {
        if (IsRepeatedTwice(i) || IsRepetitive(i))
        {
          results.Add(i);
        }
      }
      return results;
    }

    public string[] GetRangesFromFile(string path)
    {
      string input = File.ReadAllText(path);
      string[] ranges = input.Split(",");
      return ranges;
    }

    public long GetSumFromRanges(string path)
    {
      string[] ranges = GetRangesFromFile(path);
      List<long> invalidIds = [];
      foreach (string range in ranges)
      {
        List<long> ids = GetInvalidIdsFromRange(range);
        invalidIds.AddRange(ids);
      }
      return invalidIds.Sum();
    }


    public static void Main()
    {
      string path = Path.Combine(AppContext.BaseDirectory, "day2-input.txt");
      ProductId productId = new();
      long sum = productId.GetSumFromRanges(path);
      Console.WriteLine("Sum: {0:G}", sum);
    }
  }
}
