namespace e07.domain.model;

public enum DeveloperType
{
    Junior = 1,
    Intermediate = 2,
    Senior = 3,
    Lead = 4
}

static class DeveloperTypeExtensions
{
    public static DeveloperType FromId(int id)
    {
        return id switch
        {
            1 => DeveloperType.Junior,
            2 => DeveloperType.Intermediate,
            3 => DeveloperType.Senior,
            4 => DeveloperType.Lead,
            _ => throw new ArgumentException("Invalid developer type id")
        };
    }
}
