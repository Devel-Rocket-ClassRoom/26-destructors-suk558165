using System;
book();
GC.Collect();
GC.WaitForPendingFinalizers();
Seat.ShowStatus();
void book()
{
    Seat s1 = new Seat("김민수");
    Seat s2 = new Seat("이지영");
    Seat s3 = new Seat("박서준");

    s1.Study();
    s2.Study();
    s3.Study();
}
class Seat
{
    private static int _nextId = 1;
    private static int _totalUsage = 0;
    private static int _currentOccupancy = 0;

    private readonly int _id;
    private string _studentName;

    public Seat(string studentName)
    {
        this._id = _nextId++;
        this._studentName = studentName;

        _totalUsage++;
        _currentOccupancy++;
        Console.WriteLine($"좌석 {_id}번 착석: {this._studentName}");
    }
    public void Study()
    {
        Console.WriteLine($"{_studentName}이(가) 좌석 {_id}번에서 공부 중...");
    }
    ~Seat()
    {
        _currentOccupancy--;
        Console.WriteLine($"좌석 {_id}번 반납: {_studentName}");
    }

    public static void ShowStatus()
    {
        Console.WriteLine($"\n총 이용: {_totalUsage}명, 현재 착석: {_currentOccupancy}명");
    }
}


