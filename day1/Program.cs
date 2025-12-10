
namespace Day1
{
  public class Password(int start)
  {
    public int CountZero{get; set;} = 0;
    public int CurDial{get; set;} = start;
    public int PrevDial{get; set;}
    public int TurnLeft(int dialNo)
    {
      CurDial = (CurDial - dialNo) % 100;
      return CurDial;
    }

    public int TurnRight(int dialNo)
    {
      CurDial = (CurDial + dialNo) % 100;
      return CurDial;
    }
    public int NormalizeDial(int cur)
    {
      return cur < 0 ? cur + 100 : cur;
    }

    public static int GetDialNo(string dial)
    {
      int dialNo = int.Parse(dial[1..]);
      return dialNo;
    }

    public void CountFullPass(int dialNo)
    {
      if (dialNo > 100)
      {
        int passingZero = dialNo / 100;
        CountZero += passingZero;
      }
    }
    public void CountPass(int dialNo, int prevDial, bool isLeftDial)
    {

      int holdDial = dialNo % 100;

      if(isLeftDial && prevDial > 0 && (prevDial - holdDial) < 0)
      {
        CountZero++;
      }
        else if(!isLeftDial && (prevDial + holdDial) > 100)
      {
        CountZero++;
      }

    }
    public void Rotate(string line)
      {
      int dialNo = GetDialNo(line);
      bool isLeftDial = Equals(line[0], 'L');
      PrevDial = CurDial;

      CurDial = isLeftDial ? TurnLeft(dialNo) : TurnRight(dialNo);

      if (CurDial == 0)
      {
        CountZero++;
      }

      CountFullPass(dialNo);
      CountPass(dialNo, PrevDial, isLeftDial);
      CurDial = NormalizeDial(CurDial);
    }

    public int GetPassWord(string path)
    {
      StreamReader sr = new(path);
      string? line = sr.ReadLine();
      while (line!=null)
      {
        Rotate(line);
        line = sr.ReadLine();
        // Console.WriteLine("dial: {0:G}; cur: {1:G}; prev: {2:G}", line, CurDial, PrevDial);
      }
      return CountZero;
    }

    public static void Main()
    {
      string path = "C:\\Users\\My Anh\\Documents\\Project\\AdventOfCode2025\\day1\\day1-input.txt";
      Password password = new(50);
      int count = password.GetPassWord(path);
      Console.WriteLine("count: {0:G}", count);
    }
  }
}
