using System.Collections.Generic;
public class MissionPresenter
{
    private IMissionView _view;
    private List<MissionModel> _missionList = new List<MissionModel>();
    private MissionManager _missions;
    private HeroesManager _heroes;
    private HeroSpawner _heroSpawner;
    private MissionModel _selectedMission;

    public MissionPresenter(IMissionView view, MissionManager missions, HeroesManager heroes, HeroSpawner heroSpawner)
    {
        this._view = view;
        this._missions = missions;
        this._heroes = heroes;

        _view.OnStartButtonPressed += StartMissionFromView;
        _heroSpawner = heroSpawner;

        _view.SetStartButtonAction(() => PresentMission(_selectedMission));
        _view.SetCompleteButtonAction(() => CompleteMission(_selectedMission.Id));
        _view.OnMissionDescriptionDisplayed += (mission) =>
        {
            _selectedMission = mission;
        };

        TakeMissions();
    }

    private void StartMissionFromView()
    {
        GetHeroes();
        PresentMission(_selectedMission);
    }

    public void PresentMission(MissionModel mission)
    {
        if (mission.OnHeroSelected()&& !mission.IsLocked)
        {
            _view.DisplayCompletionScreen(mission);
            mission.StartMission();
        }
    }

    public void CompleteMission(float index)
    {
        _selectedMission.EndMission(_heroes);
        _view.CloseMission();
        _heroSpawner.SpawnNewHero(_selectedMission.HeroesToUnlock);
        _selectedMission.LockMission();
        _missions.MissionCompleted(_selectedMission);
    }

    private void TakeMissions()
    {
        for (int i = 0; i < _missions.GetMissionCount(); i++)
        {
            _missionList.Add(_missions.GetMissionByIndex(i));
        }
    }

    private void GetHeroes()
    {
        _selectedMission.ClearHeroes();

        for (int i = 0; i < _heroes.GetHeroCount(); i++)
        {
            _selectedMission.AddHeroes(_heroes.GetHeroByIndex(i));
        }
    }
}
