using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<MissionModel> _missions = new List<MissionModel>();

    private void Start()
    {
        UnlockMission();
    }

    private void UnlockMission()
    {
        _missions[0].UnlockMission();
    }

    public void MissionCompleted(MissionModel completedMission)
    {
        for (int i = 0; i < _missions.Count; i++)
        {
            if (completedMission.MissionsToUnlock.Contains(_missions[i].Id))
            {
                _missions[i].UnlockMission();
            }
            else if (completedMission.MissionsToBlock.Contains(_missions[i].Id))
            {
                _missions[i].LockMission();
            }
        }
    }

    public void Add(MissionModel mission)
    {
        _missions.Add(mission);
    }

    public MissionModel GetMissionByIndex(int index)
    {
        return _missions[index];
    }

    public int GetMissionCount()
    {
        return _missions.Count;
    }

    public MissionModel GetMissionById(int id)
    {
        return _missions.FirstOrDefault(m => m.Id == id);
    }
}
