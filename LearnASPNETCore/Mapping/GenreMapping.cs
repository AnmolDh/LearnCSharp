using LearnASPNETCore.Dtos;
using LearnASPNETCore.Entities;

namespace LearnASPNETCore.Mapping
{
    public static class GenreMapping
    {
        public static GenreDto ToGenreDto(this Genre genre)
        {
            return new(genre.Id, genre.Name);
        }

        public static Genre ToGenreEntity(this CreateGenreDto genreDto)
        {
            return new()
            {
                Name = genreDto.Name
            };
        }
    }
}
