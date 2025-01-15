using SMS.Dtos;
using SMS.Entities;

namespace SMS.Mappings
{
    public static class CoursesMapping
    {
        public static Course ToEntity(this CreateCourseDto newCourse)
        {
            return new()
            {
                Name = newCourse.Name,
                Code = newCourse.Code
            };
        }

        public static CourseDto ToDto(this Course course)
        {
            return new(course.Id, course.Name, course.Code);
        }
    }
}
