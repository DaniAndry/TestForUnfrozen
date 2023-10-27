using System;

public class HeroModel
{
    private string _name;
    private int _level;

    public event Action OnLevelChanged;

    public int Level => _level;
    public string Name => _name;
    public bool IsSelected { get; private set; } = false;

    public HeroModel(string name, int level)
    {
        _name = name;
        _level = level;
    }

    public void ToggleSelect()
    {
        IsSelected = !IsSelected;
    }

    public void ChangeLevel(int level)
    {
        _level += level;
        OnLevelChanged?.Invoke();
    }
}
