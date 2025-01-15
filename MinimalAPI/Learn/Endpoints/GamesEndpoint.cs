using LearnASPNETCore.Data;
using LearnASPNETCore.Dtos;
using LearnASPNETCore.Entities;
using LearnASPNETCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LearnASPNETCore.Endpoints
{
    public static class GamesEndpoint
    {
        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games")
                           .WithParameterValidation();


            group.MapGet("/", async (GameStoreContext dbContext) => {
                return await dbContext.Games.Include(game => game.Genre)
                                      .Select(game => game.ToGameSummaryDto())
                                      .AsNoTracking().ToListAsync();
            });


            group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                Game? game = await dbContext.Games.FindAsync(id);

                return game == null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());

            }).WithName("GetGame");


            group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();

                await dbContext.Games.AddAsync(game);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game.ToGameDetailsDto());
            });


            group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);

                if (existingGame is null) return Results.NotFound();

                Game game = updatedGame.ToEntity(id);

                dbContext.Entry(existingGame).CurrentValues.SetValues(game);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });


            group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
