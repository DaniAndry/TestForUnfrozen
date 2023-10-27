using System.Collections.Generic;
[System.Serializable]
public struct MissionData
{
    public float xCoord;
    public float yCoord;
    public float Id;

    public string Name;
    public string Description;
    public string Situation;
    public string Allies;
    public string Enemies;
    public string Unlock;
    public string Reward;

    public List<float> MissionForUnlock { get; set; }
    public List<float> MissionForBlock { get; set; }

    public List<string> HeroesToUnlock { get; set; }

    public RewardInfo RewardInfo;
}
