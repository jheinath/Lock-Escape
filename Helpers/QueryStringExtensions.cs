namespace LockEscape.Helpers;

public static class QueryStringExtensions
{
    public static Dictionary<string, string> DecodeQueryParameters(this string queryParameterString)
    {
        if (queryParameterString == null)
            throw new ArgumentNullException(nameof(queryParameterString));

        if (queryParameterString.Length == 0)
            return new Dictionary<string, string>();

        return queryParameterString.TrimStart('?')
            .Split(new[] { '&', ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(parameter => parameter.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
            .GroupBy(parts => parts[0],
                parts => parts.Length > 2 ? string.Join("=", parts, 1, parts.Length - 1) : (parts.Length > 1 ? parts[1] : ""))
            .ToDictionary(grouping => grouping.Key,
                grouping => string.Join(",", grouping));
    }
}