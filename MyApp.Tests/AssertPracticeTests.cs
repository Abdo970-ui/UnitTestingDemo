namespace MyApp.Tests;

public class AssertPracticeTests
{
    // 1) Equal
    [Fact]
    public void Equal_Example()
    {
        var calc = new Calculator();
        Assert.Equal(5, calc.Add(2, 3));
    }

    // 2) NotEqual
    [Fact]
    public void NotEqual_Example()
    {
        var calc = new Calculator();
        Assert.NotEqual(10, calc.Add(2, 3));
    }

    // 3) True
    [Fact]
    public void True_Example()
    {
        var student = new Student { Age = 20 };
        Assert.True(student.IsAdult());
    }

    // 4) False
    [Fact]
    public void False_Example()
    {
        var student = new Student { Age = 15 };
        Assert.False(student.IsAdult());
    }

    // 5) Null
    [Fact]
    public void Null_Example()
    {
        var student = new Student();
        Assert.Null(student.GetNickname());
    }

    // 6) NotNull
    [Fact]
    public void NotNull_Example()
    {
        var student = new Student { Name = "Ahmed" };
        Assert.NotNull(student.Name);
    }

    // 7) Contains (نص + list)
    [Fact]
    public void Contains_Example()
    {
        var student = new Student { Name = "Ahmed Ali" };
        Assert.Contains("Ali", student.Name);

        student.Grades.AddRange(new[] { 80, 90, 70 });
        Assert.Contains(90, student.Grades);
    }

    // 8) Empty / NotEmpty
    [Fact]
    public void Empty_Example()
    {
        var student = new Student();
        Assert.Empty(student.Grades);

        student.Grades.Add(100);
        Assert.NotEmpty(student.Grades);
    }

    // 9) Single
    [Fact]
    public void Single_Example()
    {
        var student = new Student();
        student.Grades.Add(95);
        Assert.Single(student.Grades);
    }

    // 10) Throws
    [Fact]
    public void Throws_Example()
    {
        var student = new Student();
        var ex = Assert.Throws<ArgumentException>(() => student.SetAge(-5));
        Assert.Equal("Age cannot be negative", ex.Message);
    }
}