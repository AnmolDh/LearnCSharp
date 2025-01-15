using System.ComponentModel.DataAnnotations;

namespace LearnASPNETCore.Dtos
{
    public record class CreateGameDto(
        [Required][StringLength(50)]string Name,
        int GenreId,
        int PlayTime,
        [Range(1, 100)] float Price
        );
}
