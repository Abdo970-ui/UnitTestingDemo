using AwesomeAssertions;
namespace MyApp.Tests;

public class BankAccountTests
{
    [Fact]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        var account = new BankAccount();

        // Act
        account.Deposit(100);

        // Assert
        //Assert.Equal(100, account.Balance);

        // Fluent Assertions
        account.Balance.Should().Be(100);
    }
    [Theory]
    [InlineData(-50)]
    [InlineData(0)]
    public void Deposit_ZeroOrNegativeAmount_ThrowsException(decimal amount)
    {
        // Arrange
        var account = new BankAccount();

        // Act + Assert
        Assert.Throws<ArgumentException>(() => account.Deposit(amount));

    }
    [Fact]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        var account = new BankAccount();
        account.Deposit(100);

        // Act
        account.Withdraw(30);

        // Assert
        //Assert.Equal(70, account.Balance);
        
        // OR

        // Fluent Assertions
        account.Balance.Should().Be(70);
    }
    [Fact]
    public void Deposit_PositiveAmount_IncreasesBalance_Fluent()
    {
        var account = new BankAccount();

        account.Deposit(100);

        account.Balance.Should().Be(100);
    }
}