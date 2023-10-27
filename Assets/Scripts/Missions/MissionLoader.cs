using UnityEngine;

public class MissionLoader : MonoBehaviour
{
    [SerializeField] private TextAsset _csvFile;
    [SerializeField] private MissionManager _missionList;

    private void Awake()
    {
        LoadMissions();
    }

    private void LoadMissions()
    {
        var missionsData = MissionParser.ParseMissionsFromCSV(_csvFile);

        foreach (var missionData in missionsData)
        {
            MissionModel mission = new MissionModel(missionData);
            _missionList.Add(mission);
        }
    }
}
