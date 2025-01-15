using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Dtos;
using SMS.Entities;
using SMS.Mappings;

namespace SMS.Endpoints
{
    public static class CoursesEndpoints
    {
        public static RouteGroupBuilder MapCoursesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/courses");

            group.MapGet("/", async (SMSDbContext dbContext) =>
            {
                return await dbContext.Courses.Select(course => course.ToDto()).AsNoTracking().ToListAsync();
            });

            group.MapGet("/{id}", async (int id, SMSDbContext dbContext) =>
            {
                Course? course = await dbContext.Courses.FindAsync(id);

                return course == null ? Results.NotFound() : Results.Ok(course.ToDto());
            });

            group.MapPost("/", async (CreateCourseDto newCourse, SMSDbContext dbContext) =>
            {
                Course course = newCourse.ToEntity();
                await dbContext.Courses.AddAsync(course);
                await dbContext.SaveChangesAsync();

                return Results.Created();
            });

            group.MapDelete("/{id}", async (int id, SMSDbContext dbContext) =>
            {
                await dbContext.Courses.Where(course => course.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
