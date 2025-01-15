using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Dtos;
using SMS.Entities;
using SMS.Mappings;

namespace SMS.Endpoints
{
    public static class StudentsEndpoints
    {
        public static RouteGroupBuilder MapStudentsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/students");

            group.MapGet("/", async (SMSDbContext dbContext) =>
            {
                return await dbContext.Students.Select(student => student.ToDto()).AsNoTracking().ToListAsync();
            });

            group.MapGet("/{id}", async (int id, SMSDbContext dbContext) =>
            {
                Student? student = await dbContext.Students.FindAsync(id);

                return student == null ? Results.NotFound() : Results.Ok(student.ToDto());
            }).WithName("GetStudent");

            group.MapPost("/", async (CreateStudentDto newStudent, SMSDbContext dbContext) =>
            {
                Student student = newStudent.ToEntity();
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetStudent", new {student.Id}, student.ToDto());
            });

            group.MapDelete("/{id}", async (int id, SMSDbContext dbContext) =>
            {
                await dbContext.Students.Where(student => student.Id == id).ExecuteDeleteAsync();
                return Results.NoContent();
            });

            return group;
        }
    }
}
