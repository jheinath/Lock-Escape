namespace Domain.Extensions;

public static class ListExtensions
{
    public static void Replace<T>(this List<T> list, int itemIndex , T newItem)
    {
        list[itemIndex] = newItem;
    }
}