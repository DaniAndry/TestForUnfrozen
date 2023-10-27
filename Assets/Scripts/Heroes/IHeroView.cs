using System;

public interface IHeroView
{
    void DisplayHeroName(string name);
    void DisplayHeroStatus(bool isSelected);
    void DisplayHeroLevel(int level);
}
