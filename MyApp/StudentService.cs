namespace MyApp;

public class StudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public bool IsStudentAdult(int id)
    {
        var student = _repository.GetById(id);
        if (student == null)
            throw new InvalidOperationException("Student not found");
        return student.IsAdult();
    }
    public string GetStudentName(int id)
    {
        var student = _repository.GetById(id);
        if (student == null)
            throw new InvalidOperationException("Student not found");
        return student.Name;
    }

    public void RegisterStudent(Student student)
    {
        _repository.Save(student);
    }
}