namespace SMS.Dtos
{
    public record class EnrollmentDto(
        int Id,
        StudentDto Student,
        CourseDto Course
    );
}
