using SMS.Dtos;
using SMS.Entities;

namespace SMS.Mappings
{
    public static class EnrollmentsMapping
    {
        public static Enrollment ToEntity(this CreateEnrollmentDto newEnroll)
        {
            return new()
            {
                StudentId = newEnroll.StudentId,
                CourseId = newEnroll.CourseId
            };
        }
        
        public static EnrollmentDto ToDto(this Enrollment enrollment)
        {
            return new(enrollment.Id, enrollment.Student!.ToDto(), enrollment.Course!.ToDto());
        }
    }
}
