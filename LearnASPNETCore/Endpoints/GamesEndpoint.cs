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


            group.MapGet("/", (GameStoreContext dbContext) => {
                return dbContext.Games.Include(game => game.Genre)
                                      .Select(game => game.ToGameSummaryDto())
                                      .AsNoTracking();
            });


            group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
            {
                Game? game = dbContext.Games.Find(id);

                return game == null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());

            }).WithName("GetGame");


            group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();

                dbContext.Games.Add(game);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game.ToGameDetailsDto());
            });


            group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = dbContext.Games.Find(id);

                if (existingGame is null) return Results.NotFound();

                Game game = updatedGame.ToEntity(id);

                dbContext.Entry(existingGame).CurrentValues.SetValues(game);
                dbContext.SaveChanges();

                return Results.NoContent();
            });


            group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
            {
                dbContext.Games.Where(game => game.Id == id).ExecuteDelete();

                return Results.NoContent();
            });

            return group;
        }
    }
}
