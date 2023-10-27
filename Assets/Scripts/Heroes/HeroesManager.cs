using System.Collections.Generic;
using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    [SerializeField] public List<HeroModel> _heroes = new List<HeroModel>();

    public void Add(HeroModel hero)
    {
        _heroes.Add(hero);
    }

    public HeroModel GetHeroByIndex(int index)
    {
        return _heroes[index];
    }

    public int GetHeroCount()
    {
        return _heroes.Count;
    }

    public bool IsPresent(string name)
    {
        foreach (var model in _heroes)
        {
            if (model.Name == name)
            {
                return true;
            }
        }

        return false;
    }

    public void RewardAdditionalHero(RewardInfo rewardInfo)
    {
        foreach (var heroModel in _heroes)
        {
            foreach (var heroChange in rewardInfo.SpecificHeroChanges)
            {
                if (heroChange.Key == heroModel.Name)
                {
                    heroModel.ChangeLevel(heroChange.Value);
                }
            }
        }
    }

}
