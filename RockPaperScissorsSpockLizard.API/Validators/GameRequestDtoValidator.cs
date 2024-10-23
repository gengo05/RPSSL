using FluentValidation;
using RockPaperScissorsSpockLizard.API.DTOs;
using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.API.Validators
{
    public class GameRequestDtoValidator : AbstractValidator<GameRequestDto>
    {
        public GameRequestDtoValidator()
        {
            _ = RuleFor(x => x.PlayerMove).IsInEnum().WithMessage($"Move must be a valid GameMove: {GameMoveExtensions.GetAllMovesAsString()}.");
        }
    }
}
