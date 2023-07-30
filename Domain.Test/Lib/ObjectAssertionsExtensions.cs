using FluentAssertions;
using FluentAssertions.Primitives;
using FluentResults;

namespace Domain.Test.Lib;

public static class ObjectAssertionsExtensions
{
    public static void BeSuccessfulWithoutErrors(this ObjectAssertions assertions)
    {
        if (assertions.Subject is not IResultBase result)        
            throw new ArgumentException($"Subject is not of type {typeof(Result)}");

        result.Errors.Should().BeEmpty();
        result.IsSuccess.Should().BeTrue();
    }
}