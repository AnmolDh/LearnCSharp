using LearnASPNETCore.Dtos;
using LearnASPNETCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnASPNETCore.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game)
        {
            return new()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                PlayTime = game.PlayTime,
                Price = game.Price
            };
        }

        public static Game ToEntity(this UpdateGameDto game, int id)
        {
            return new()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                PlayTime = game.PlayTime,
                Price = game.Price
            };
        }

        public static GameSummaryDto ToGameSummaryDto(this Game game)
        {
            return new
            (
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.PlayTime,
                game.Price
            );
        }

        public static GameDetailsDto ToGameDetailsDto(this Game game)
        {
            return new
            (
                game.Id,
                game.Name,
                game.GenreId,
                game.PlayTime,
                game.Price
            );
        }
    }
}
