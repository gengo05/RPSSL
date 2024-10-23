using RockPaperScissorsSpockLizard.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace RockPaperScissorsSpockLizard.API.DTOs
{
    public class GameRequestDto
    {
        [Required]
        public GameMove PlayerMove { get; set; }
    }
}
