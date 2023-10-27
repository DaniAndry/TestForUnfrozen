using System.Collections.Generic;

public class UnlockMissionModel : MissionModel
{
    public List<float> UnlockedMissionsIds { get; private set; }

    public UnlockMissionModel(MissionData data) : base(data)
    {
        UnlockedMissionsIds = data.MissionForUnlock;
    }
}
