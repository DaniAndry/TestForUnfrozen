using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionSpawner : MonoBehaviour
{
    [SerializeField] private MissionButton _buttonPrefab;
    [SerializeField] private RectTransform _background;
    [SerializeField] private MissionView _missionView;

    private MissionManager _missionList;
    private List<MissionModel> _missions = new List<MissionModel>();
    private List<MissionButton> _missionButtons = new List<MissionButton>();

    private void Start()
    {
        _missionList = GetComponent<MissionManager>();

        TakeMissions();
        SpawnButtons();
    }

    private void TakeMissions()
    {
        for (int i = 0; i < _missionList.GetMissionCount(); i++)
        {
            _missions.Add(_missionList.GetMissionByIndex(i));
        }
    }

    private void SpawnButtons()
    {
        for (int i = 0; i < _missions.Count; i++)
        {
            Vector2 coord = new Vector2(_missions[i].xCoord, _missions[i].yCoord);
            SpawnButton(coord, _missions[i].Id);
        }
    }

    private void SpawnButton(Vector2 coordinate, float id)
    {
        MissionButton newButton = Instantiate(_buttonPrefab, _background);
        RectTransform newButtonRectTransform = newButton.GetComponent<RectTransform>();
        newButtonRectTransform.anchoredPosition = coordinate;
        newButton.SetMissionID(id);
        newButton.OnButtonClicked += () => _missionView.DisplayDescriptions(_missions.FirstOrDefault(m => m.Id == id));

        _missionButtons.Add(newButton);
    }
}
