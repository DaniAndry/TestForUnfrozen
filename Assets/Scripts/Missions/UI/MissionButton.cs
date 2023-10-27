using TMPro;
using UnityEngine;

public class MissionButton : BaseButton
{
    [SerializeField] private TextMeshProUGUI _missionIDText;

    private float _missionID;

    public void SetMissionID(float id)
    {
        _missionID = id;
        _missionIDText.text = _missionID.ToString();
    }

    protected override void Start()
    {
        base.Start();
    }
}