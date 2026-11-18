using AwesomeAssertions;

namespace MyApp.Tests;

public class FluentPracticeTests
{
    // قيم وأرقام
    [Fact]
    public void Numbers_Example()
    {
        var account = new BankAccount();
        account.Deposit(100);

        account.Balance.Should().Be(100);
        account.Balance.Should().BeGreaterThan(50);
        account.Balance.Should().NotBe(0);
    }

    // true / false
    [Fact]
    public void Boolean_Example()
    {
        new Student { Age = 20 }.IsAdult().Should().BeTrue();
        new Student { Age = 15 }.IsAdult().Should().BeFalse();
    }

    // null
    [Fact]
    public void Null_Example()
    {
        var student = new Student { Name = "Ahmed" };

        student.GetNickname().Should().BeNull();
        student.Name.Should().NotBeNull();
    }

    // نصوص
    [Fact]
    public void String_Example()
    {
        var student = new Student { Name = "Ahmed Ali" };

        student.Name.Should().Contain("Ali");
        student.Name.Should().StartWith("Ahmed");
    }

    // collections
    [Fact]
    public void Collection_Example()
    {
        var student = new Student();
        student.Grades.Should().BeEmpty();

        student.Grades.AddRange(new[] { 80, 90, 70 });

        student.Grades.Should().NotBeEmpty();
        student.Grades.Should().HaveCount(3);
        student.Grades.Should().Contain(90);
    }

    // أرقام عشرية
    [Fact]
    public void Double_Example()
    {
        var student = new Student();
        student.Grades.AddRange(new[] { 80, 90, 85 });

        student.GetAverage().Should().BeApproximately(85, 0.01);
    }

    // exceptions
    [Fact]
    public void Exception_Example()
    {
        var account = new BankAccount();

        Action act = () => account.Withdraw(500);

        act.Should().Throw<InvalidOperationException>()
           .WithMessage("Insufficient funds");
    }
}