using System.Collections.Generic;

public class RewardInfo
{
    public int DefaultHeroLevelChange { get; set; }
    public Dictionary<string, int> SpecificHeroChanges { get; set; } = new Dictionary<string, int>();
}