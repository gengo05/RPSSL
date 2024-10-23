namespace RockPaperScissorsSpockLizard.API.DTOs
{
    public class GameResultDto
    {
        public string PlayerMove { get; set; } = string.Empty;
        public string Player { get; set; } = string.Empty;
        public string OpponentMove { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
    }
}
