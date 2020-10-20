
using System.Collections.Generic;
using System.Threading.Tasks;
using L02.Entities;

public interface IStudentRepository
{
    public Task<List<Student>> GetAllStudents();

    Task CreateStudent(Student student);
} 