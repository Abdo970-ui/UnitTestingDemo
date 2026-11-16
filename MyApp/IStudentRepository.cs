using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public interface IStudentRepository
    {
        Student? GetById(int id);
        void Save(Student student);
    }
}
