using LearnASPNETCore.Data;
using LearnASPNETCore.Dtos;
using LearnASPNETCore.Entities;
using LearnASPNETCore.Mapping;

namespace LearnASPNETCore.Endpoints
{
    public static class GamesEndpoint
    {
        private static readonly List<GameSummaryDto> games = [
            new (1, "GTA V", "Role-Playing", 400, 59.99F),
            new (2, "RDR 2", "Role-Playing", 500, 69.99F),
            new (3, "NFS", "Racing", 200, 29.99F),
            new (4, "FIFA", "Sport", 400, 49.99F),
            new (5, "RWC", "Sport", 300, 19.99F),
            new (6, "MS Flight Simulator", "Simulation", 1100, 59.99F)
        ];

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games")
                           .WithParameterValidation();


            group.MapGet("/", () => games);


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


            group.MapDelete("/{id}", (int id) =>
            {
                games.RemoveAll(game => game.Id == id);

                return Results.NoContent();
            });

            return group;
        }
    }
}
