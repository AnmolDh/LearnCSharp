using System.ComponentModel.DataAnnotations;

namespace LearnASPNETCore.Dtos
{
    public record class CreateGenreDto([Required][StringLength(50)] string Name);
}
