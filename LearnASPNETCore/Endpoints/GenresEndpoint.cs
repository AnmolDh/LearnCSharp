using LearnASPNETCore.Data;
using LearnASPNETCore.Dtos;
using LearnASPNETCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LearnASPNETCore.Endpoints
{
    public static class GenresEndpoint
    {
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/genres");

            group.MapGet("/", async (GameStoreContext dbContext) =>
            {
                return await dbContext.Genres.Select(genre => genre.ToGenreDto())
                                             .AsNoTracking().ToListAsync();
            }).WithName("GetGenre");

            group.MapPost("/", async (CreateGenreDto newGenre, GameStoreContext dbContext) =>
            {
                var genre = newGenre.ToGenreEntity();

                await dbContext.Genres.AddAsync(genre);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetGenre", new { genre.Id }, genre.ToGenreDto());
            });

            return group;
        }
    }
}
