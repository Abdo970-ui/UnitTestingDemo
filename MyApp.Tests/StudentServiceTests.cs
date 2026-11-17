using Moq;

namespace MyApp.Tests;

public class StudentServiceTests
{
    [Fact]
    public void IsStudentAdult_AdultStudent_ReturnsTrue()
    {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        mockRepo.Setup(r => r.GetById(1))
                .Returns(new Student { Age = 19 });

        var service = new StudentService(mockRepo.Object);

        // Act
        var result = service.IsStudentAdult(1);

        // Assert
        Assert.True(result);
    }
    [Fact]
    public void IsStudentAdult_StudentNotFound_ThrowsException()
    {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        mockRepo.Setup(r => r.GetById(99))
                .Returns((Student?)null);

        var service = new StudentService(mockRepo.Object);

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() => service.IsStudentAdult(99));
    }
    [Fact]
    public void RegisterStudent_CallsSaveOnce()
    {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        var service = new StudentService(mockRepo.Object);
        var student = new Student { Name = "Ahmed" };

        // Act
        service.RegisterStudent(student);

        // Assert
        mockRepo.Verify(r => r.Save(student), Times.Once);
    }
    [Fact]
    public void IsStudentAdult_MinorStudent_ReturnsFalse()
    {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        mockRepo.Setup(r => r.GetById(2))
                .Returns(new Student { Age = 17 });
        var service = new StudentService(mockRepo.Object);
        // Act
        var result = service.IsStudentAdult(2);
        // Assert
        Assert.False(result);
    }
    [Fact]
    public void GetStudentName_StudentExists_ReturnsName()
    {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        mockRepo.Setup(r => r.GetById(1))
                .Returns(new Student { Name = "Ahmed" });
        var service = new StudentService(mockRepo.Object);
        // Act
        var result = service.GetStudentName(1);
        // Assert
        Assert.Equal("Ahmed", result);
    }
    [Fact]
    public void GetStudentName_StudentNotFound_ThrowsException()
    {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        mockRepo.Setup(r => r.GetById(99))
                .Returns((Student?)null);
        var service = new StudentService(mockRepo.Object);
        // Act + Assert
        Assert.Throws<InvalidOperationException>(() => service.GetStudentName(99));
    }
}