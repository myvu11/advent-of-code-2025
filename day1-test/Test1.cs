using Day1;

namespace day1_test;

[TestClass]
public sealed class Test1
{
  // [TestMethod]
  public void TestBigDial()
  {
    Password password = new(0);
    int curDial;

    curDial = password.NormalizeDial(password.TurnLeft(99));
    Assert.AreEqual(1, curDial);

    curDial = password.NormalizeDial(password.TurnLeft(799));
    Assert.AreEqual(2, curDial);

    curDial = password.NormalizeDial(password.TurnRight(800));
    Assert.AreEqual(2, curDial);
  }
  // [TestMethod]
   public static void TestExampleDialPoint()
  {
    List<string> rotations = new(["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"]);
    List<int> dialPoint = new([82, 52, 0, 95, 55, 0, 99, 0, 14, 32]);
    Password password = new(50);
    int curDial;

    for(int i = 0; i < rotations.Count; i++)
    {
      int dialNo = int.Parse(rotations[i][1..]);
      bool isLeftDial = Equals(rotations[i][0], 'L');
      Console.WriteLine("dial: {0:G}", rotations[i]);
      if(isLeftDial)
      {
        curDial = password.TurnLeft(dialNo);
      }
      else
      {
        curDial = password.TurnRight(dialNo);
      }
      if(curDial < 0)
      {
        curDial += 100;
      }

      Assert.AreEqual(dialPoint[i], curDial);
    }
  }

  // [TestMethod]
  public void TestExampleCount()
  {
    string path = "C:\\Users\\My Anh\\Documents\\Project\\AdventOfCode2025\\day1-test\\test-example.txt";
    Password password = new(50);
    int actual = password.GetPassWord(path);
    Assert.AreEqual(3, actual);
  }

  [TestMethod]
  public void TestPart2RotateRight()
  {
    string line = "R1";
    Password password = new(99);
    password.Rotate(line);
    Assert.AreEqual(0, password.CurDial);
    Assert.AreEqual(1, password.CountZero);
  }
  [TestMethod]
  public void TestPart2RotateLeft()
  {
    string line = "L1";
    Password password = new(0);
    password.Rotate(line);
    Assert.AreEqual(99, password.CurDial);
    Assert.AreEqual(0, password.CountZero);
  }
  [TestMethod]
  public void TestPart2RotateBigRight()
  {
    string line = "R749";
    Password password = new(50);
    password.Rotate(line);
    Assert.AreEqual(99, password.CurDial);
    Assert.AreEqual(7, password.CountZero);
  }
  [TestMethod]
  public void TestPart2RotateBigLeft()
  {
    string line = "L749";
    Password password = new(50);
    password.Rotate(line);
    Assert.AreEqual(1, password.CurDial);
    Assert.AreEqual(7, password.CountZero);
  }
  [TestMethod]
  public void TestPart2RotateBigPassTwiceLeft()
  {
    string line = "L769";
    Password password = new(50);
    password.Rotate(line);
    Assert.AreEqual(81, password.CurDial);
    Assert.AreEqual(8, password.CountZero);
  }
  [TestMethod]
  public void TestPart2CountSmallPassZeroRight()
  {
    int dial = 1;
    bool isLeftDial = false;
    int start = 99;
    Password password = new(start);
    password.CountPass(dial, start, isLeftDial);
    Assert.AreEqual(0, password.CountZero);
  }
  [TestMethod]
  public void TestPart2CountPassZeroRight()
  {
    int dial = 2;
    bool isLeftDial = false;
    int start = 99;
    Password password = new(start);
    password.CountPass(dial, start, isLeftDial);
    Assert.AreEqual(1, password.CountZero);
  }
  [TestMethod]
  public void TestPart2CountPassZeroLeft()
  {
    int dial = 1;
    bool isLeftDial = true;
    int start = 0;
    Password password = new(start);
    password.CountPass(dial, start, isLeftDial);
    Assert.AreEqual(0, password.CountZero);
  }
  [TestMethod]
  public void TestPart2PassSmallRight()
  {
    int dial = 60;
    int start = 95;
    bool isLeftDial = false;
    Password password = new(start);
    password.CountPass(dial, 95, isLeftDial);
    Assert.AreEqual(1, password.CountZero);
  }
  [TestMethod]
  public void TestPart2PassSmallLeft()
  {
    int dial = 60;
    int start = 35;
    bool isLeftDial = true;
    Password password = new(start);
    password.CountPass(dial, start, isLeftDial);
    Console.WriteLine("cur, count: {0}", password.CountZero);
    Assert.AreEqual(1, password.CountZero);
  }
  [TestMethod]
  public void TestPart2PassBigLeft()
  {
    int dial = 666;
    int start = 95;
    Password password = new(start);
    password.CountFullPass(dial);
    Console.WriteLine("cur, count: {0}", password.CountZero);

    Assert.AreEqual(6, password.CountZero);
  }

  [TestMethod]
  public void TestPart2SimpleDial()
  {
    List<string> rotations = ["R1000", "L1000", "L50", "R1", "L1", "L1", "R1", "R100", "R1"];
    List<int> dials = [50, 50, 0, 1, 0, 99, 0, 0, 1];
    List<int> counts = [10, 20, 21, 21, 22, 22, 23, 24, 24];
    Password password = new(50);

    for(int i = 0; i < rotations.Count; i++)
    {
      password.Rotate(rotations[i]);
      Console.WriteLine("dial: {0:G}, curDial: {1:G}; count: {2:G}", rotations[i], password.CurDial, password.CountZero);
      Assert.AreEqual(dials[i], password.CurDial);
      Assert.AreEqual(counts[i], password.CountZero);
    }
  }

  [TestMethod]
  public void TestPart2SimpleCount()
  {
    string path = "C:\\Users\\My Anh\\Documents\\Project\\AdventOfCode2025\\day1-test\\test-part2.txt";
    Password password = new(50);
    int actual = password.GetPassWord(path);
    Assert.AreEqual(24, actual);
  }

  [TestMethod]
  public void TestPart2Example()
  {
    string path = "C:\\Users\\My Anh\\Documents\\Project\\AdventOfCode2025\\day1-test\\test-example.txt";
    Password password = new(50);
    int actual = password.GetPassWord(path);
    Assert.AreEqual(6, actual);
  }
}
