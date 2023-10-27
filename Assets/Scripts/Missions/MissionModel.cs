using System.Collections.Generic;

[System.Serializable]
public class MissionModel
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

    public RewardInfo RewardInfo;
    public List<string> HeroesToUnlock;
    public bool IsLocked = true;
    public HeroModel _selectedHero;
    public HeroModel _rightHero;
    public List<float> MissionsToUnlock = new List<float>();
    public List<float> MissionsToBlock = new List<float>();

    private List<HeroModel> _selectedHeroes = new List<HeroModel>();
    private List<HeroModel> _heroes = new List<HeroModel>();
    protected string[] values;

    public MissionModel(MissionData data)
    {
        Id = data.Id;
        xCoord = data.xCoord;
        yCoord = data.yCoord;

        Name = data.Name;
        Description = data.Description;
        Situation = data.Situation;
        Allies = data.Allies;
        Enemies = data.Enemies;
        Unlock = data.Unlock;
        Reward = data.Reward;
        RewardInfo = data.RewardInfo;
        HeroesToUnlock = data.HeroesToUnlock;
        MissionsToUnlock = data.MissionForUnlock;
        MissionsToBlock = data.MissionForBlock;
    }

    public void StartMission()
    {
        _selectedHero.ChangeLevel(RewardInfo.DefaultHeroLevelChange);
    }

    public void EndMission(HeroesManager heroesManager)
    {
        heroesManager.RewardAdditionalHero(this.RewardInfo);
    }

    public bool OnHeroSelected()
    {
        if (_selectedHeroes.Count == 1)
        {
            _selectedHero = _selectedHeroes[0];
            return true;
        }

        return false;
    }

    public void LockMission()
    {
        IsLocked = true;
    }

    public void UnlockMission()
    {
        IsLocked = false;
    }

    public void ClearHeroes()
    {
        _heroes.Clear();
    }

    public void AddHeroes(HeroModel heroModel)
    {
        _heroes.Add(heroModel);
        AddSelectedHeroes();
    }

    private void AddSelectedHeroes()
    {
        _selectedHeroes.Clear();

        foreach (var hero in _heroes)
        {
            if (hero.IsSelected)
                _selectedHeroes.Add(hero);
        }
    }
}

