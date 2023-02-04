namespace LockEscape.Services.DecodingFromQueryParameters;

public class EscapeGameDto
{
    public string? CreatorPassword { get; init; }
    public string? CultureInfo { get; init; }
    public IEnumerable<GameSolutionForGroupDto> GameSolutionForGroupDtos { get; init; } = null!;
    public IEnumerable<RiddleSolutionDto> RiddleSolutionDtos { get; init; } = null!;
}

public class GameSolutionForGroupDto
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int GroupNumber { get; set; }
    public string? GameSolution { get; init; }
    public bool IsSelected { get; set; }
}

public class RiddleSolutionDto
{
    public bool IsSolved { get; set; }
    public string? RiddleSolution { get; init; }
}