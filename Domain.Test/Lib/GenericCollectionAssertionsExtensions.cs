using FluentAssertions.Collections;
using FluentResults;

namespace Domain.Test.Lib;

public static class GenericCollectionAssertionsExtensions
{
    public static void BeSingleErrorListWith(this GenericCollectionAssertions<IError> assertions, Error error)
    {
        assertions.BeEquivalentTo(new[] { error });
    }
}