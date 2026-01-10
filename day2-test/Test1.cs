using Day2;

namespace day2_test;

[TestClass]

public sealed class Test1
{
  // [TestMethod]
  public void CheckRepeat()
  {
    long input = 11;
    ProductId productID = new();
    bool actual = productID.IsRepeatedTwice(input);
    Assert.IsTrue(actual);
  }

  // [TestMethod]
  public void CheckRepeatLongId()
  {
    long input = 5145678951456789;
    ProductId productID = new();
    bool actual = productID.IsRepeatedTwice(input);
    Assert.IsTrue(actual);
  }

  // [TestMethod]
  public void ReadInputFile()
  {
    string path = "C:\\Users\\My Anh\\Documents\\Project\\AdventOfCode2025\\day2-test\\test-example.txt";
    ProductId productId = new();
    string[] ranges = productId.GetRangesFromFile(path);
    string[] expected = ["11-22", "95-115", "998-1012", "1188511880-1188511890", "222220-222224", "1698522-1698528", "446443-446449", "38593856-38593862", "565653-565659", "824824821-824824827", "2121212118-2121212124"];
    for (int i = 0; i > ranges.Length; i++)
    {
      Assert.AreEqual(expected[i], ranges[i]);
    }

  }
  [TestMethod]
  public void IsRepetitivePatternLengthTwice()
  {
    long input = 11;
    ProductId productId = new();
    bool actual = productId.IsRepetitive(input);
    Assert.IsTrue(actual);
  }
  [TestMethod]
  public void IsRepetitivePatternLengthOne()
  {
    long input = 111;
    ProductId productId = new();
    bool actual = productId.IsRepetitive(input);
    Assert.IsTrue(actual);
  }
  [TestMethod]
  public void IsRepetitivePatternLengthTwo()
  {
    long input = 565656565656565656;
    ProductId productId = new();
    bool actual = productId.IsRepetitive(input);
    Assert.IsTrue(actual);
  }
  [TestMethod]
  public void IsRepetitivePatternLengthFive()
  {
    long input = 118851188511885;
    ProductId productId = new();
    bool actual = productId.IsRepetitive(input);
    Assert.IsTrue(actual);
  }

  [TestMethod]
  public void IsRepetitivePatternFalse()
  {
    long input = 1698528;
    ProductId productId = new();
    bool actual = productId.IsRepetitive(input);
    Assert.IsFalse(actual);
  }
  [TestMethod]
  public void IsRepetitivePatternFalseLong()
  {
    long input = 9227775554;
    ProductId productId = new();
    bool actual = productId.IsRepetitive(input);
    Assert.IsFalse(actual);
  }
  [TestMethod]
  public void IsRepetitivePatternFalseAtEnd()
  {
    long input = 565656565656565611;
    ProductId productId = new();
    bool actual = productId.IsRepetitive(input);
    Assert.IsFalse(actual);
  }

}
