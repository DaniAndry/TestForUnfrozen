using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField] private HeroView _heroPrefab;
    [SerializeField] private Transform _content;

    private HeroPresenter _heroPresenter;
    private HeroesManager _heroes;
    private HeroesButton _button;

    private void Start()
    {
        _heroes = GetComponent<HeroesManager>();
        HeroModel defaultHero = new HeroModel("Воробей", 1);
        SpawnHero(defaultHero);
    }

    public void SpawnNewHero(List<string> heroes)
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            if (!_heroes.IsPresent(heroes[i]))
            {
                HeroModel newHero = new HeroModel(heroes[i], 1);
                SpawnHero(newHero);
            }
        }
    }

    private void SpawnHero(HeroModel model)
    {
        HeroView spawnedHero = Instantiate(_heroPrefab, _content);

        _heroPresenter = new HeroPresenter(spawnedHero, model);
        _button = spawnedHero.GetComponent<HeroesButton>();
        _button.OnButtonClicked += model.ToggleSelect;
        _button.OnButtonClicked += _heroPresenter.InitializeView;
        _heroes.Add(model);
    }
}
