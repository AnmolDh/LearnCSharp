using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Dtos;
using SMS.Entities;
using SMS.Mappings;

namespace SMS.Endpoints
{
    public static class EnrollmentsEndpoints
    {
        public static RouteGroupBuilder MapEnrollmentsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/enrollments");

            group.MapGet("/", async (SMSDbContext dbContext) =>
            {
                return await dbContext.Enrollments.Include(en => en.Course)
                                                    .Include(en => en.Student)
                                                    .Select(en => en.ToDto())
                                                    .AsNoTracking().ToListAsync();
            });

            group.MapGet("/{id}", async (int id, SMSDbContext dbContext) =>
            {
                Enrollment? enrollment = await dbContext.Enrollments.Include(en => en.Course)
                                                                    .Include(en => en.Student)
                                                                    .FirstOrDefaultAsync(en => en.Id == id);

                return enrollment == null ? Results.NotFound() : Results.Ok(enrollment.ToDto());
            });

            group.MapPost("/", async (CreateEnrollmentDto newEnroll, SMSDbContext dbContext) =>
            {
                Enrollment enrollment = newEnroll.ToEntity();
                await dbContext.Enrollments.AddAsync(enrollment);
                await dbContext.SaveChangesAsync();

                return Results.Created();
            });

            return group;
        }
    }
}
