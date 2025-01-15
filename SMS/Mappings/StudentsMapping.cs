using SMS.Dtos;
using SMS.Entities;

namespace SMS.Mappings
{
    public static class StudentsMapping
    {
        public static Student ToEntity(this CreateStudentDto newStudent)
        {
            return new()
            {
                Name = newStudent.Name, 
                RollNo = newStudent.RollNo, 
                Age = newStudent.Age, 
                Batch = newStudent.Batch
            };
        }

        public static StudentDto ToDto(this Student student)
        {
            return new(student.Id, student.Name, student.RollNo, student.Age, student.Batch);
        }

    }
}
