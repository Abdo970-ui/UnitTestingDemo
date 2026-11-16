namespace MyApp;

public class Student
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public List<int> Grades { get; set; } = new();

    public double GetAverage()
    {
        if (Grades.Count == 0) return 0;
        return Grades.Average();
    }

    public bool IsAdult() => Age >= 18;

    public string? GetNickname() => null;

    public void SetAge(int age)
    {
        if (age < 0)
            throw new ArgumentException("Age cannot be negative");
        Age = age;
    }
}