using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionView : MonoBehaviour, IMissionView
{
    [SerializeField] private GameObject _descriptionPanel;
    [SerializeField] private GameObject _completionPanel;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _situationText;
    [SerializeField] private TextMeshProUGUI _alliesText;
    [SerializeField] private TextMeshProUGUI _rewardText;
    [SerializeField] private TextMeshProUGUI _enemyText;
    [SerializeField] private TextMeshProUGUI _unlockText;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _completeButton;
    [SerializeField] private MissionManager _missions;

    [SerializeField] private HeroesManager _heroes;
    [SerializeField] private HeroSpawner _spawner;

    private MissionPresenter _presenter;

    public event Action OnStartButtonPressed;
    public event Action OnCompleteButtonPressed;
    public event Action<MissionModel> OnMissionDescriptionDisplayed;


    private void Awake()
    {
        _presenter = new MissionPresenter(this, _missions, _heroes, _spawner);
    }
    public void SetStartButtonAction(Action action)
    {
        _startButton.onClick.AddListener(() =>
        {
            action?.Invoke();
            OnStartButtonPressed?.Invoke();
        });
    }


    public void SetCompleteButtonAction(Action action)
    {
        _completeButton.onClick.AddListener(() => action?.Invoke());
    }

    public void DisplayDescriptions(MissionModel mission)
    {
        if (!mission.IsLocked)
        {
            _descriptionPanel.SetActive(true);
            _completionPanel.SetActive(false);

            _nameText.text = mission.Name;
            _descriptionText.text = mission.Description;

            OnMissionDescriptionDisplayed?.Invoke(mission);
        }
    }

    public void DisplayCompletionScreen(MissionModel mission)
    {
        _descriptionPanel.SetActive(false);
        _completionPanel.SetActive(true);
        _situationText.text = mission.Situation;
        _alliesText.text = mission.Allies;
        _enemyText.text = mission.Enemies;
        _unlockText.text = mission.Unlock;
        _rewardText.text = mission.Reward;
    }

    public void CloseMission()
    {
        _completionPanel.SetActive(false);
    }

    public void DisplayError(string message)
    {
        Debug.LogError(message);
    }

    public void DisplayVictory()
    {
        Debug.Log("Victory!");
    }

    public void DisplayHeroLevelUp(string heroName, int level)
    {
        Debug.Log($"{heroName} has leveled up to level {level}!");
    }

}
