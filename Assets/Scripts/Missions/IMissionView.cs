using System;

public interface IMissionView
{
    event Action OnStartButtonPressed;
    event Action OnCompleteButtonPressed;
    event Action<MissionModel> OnMissionDescriptionDisplayed;

    void DisplayDescriptions(MissionModel mission);
    void DisplayCompletionScreen(MissionModel mission);
    void CloseMission();
    void SetStartButtonAction(Action callback);
    void SetCompleteButtonAction(Action callback);
}