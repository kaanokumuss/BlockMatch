public static class MatchHelpers
{
    public const int MinMatchCount = 2;
    public const int MinSpecialMatchCount = 5;
    
    public static bool CanMatch(int amount)
    {
        return amount >= MinMatchCount;
    }
    
    public static bool IsRocketMatch(int amount)
    {
        return amount is 5 or 6 or 7;
    }
    
    public static bool IsBombMatch(int amount)
    {
        return amount is 8 or 9;
    }
    
    public static bool IsDiscoMatch(int amount)
    {
        return amount > 9;
    }
    
    public static bool IsMinSpecialMatch(int amount)
    {
        return amount >= 5;
    }
}