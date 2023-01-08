namespace LockEscape.Services.DecodingFromQueryParameters;

public class EscapeGameDto
{
    public string? CreatorPassword { get; set; }
    public string? CultureInfo { get; set; }
    public IEnumerable<GameSolutionForGroupDto> GameSolutionForGroupDtos { get; set; }
    public IEnumerable<RiddleSolutionDto> RiddleSolutionDtos { get; set; }
}

public class GameSolutionForGroupDto
{
    public int GroupNumber { get; set; }
    public string? GameSolution { get; set; }
}

public class RiddleSolutionDto
{
    public bool IsSolved { get; set; }
    public string? RiddleSolution { get; set; }
}