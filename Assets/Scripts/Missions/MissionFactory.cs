public static class MissionFactory
{
    public static MissionModel CreateMission(MissionData data)
    {
        if (data.MissionForUnlock?.Count > 0) 
        {
            return new UnlockMissionModel(data);
        }
        else
        {
            return new MissionModel(data);
        }
    }
}
