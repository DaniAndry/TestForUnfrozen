using TMPro;
using UnityEngine;

public class HeroView : MonoBehaviour, IHeroView
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private TextMeshProUGUI _levelText;

    public void DisplayHeroName(string name)
    {
        _nameText.text = name;
    }

    public void DisplayHeroStatus(bool isSelected)
    {
        _statusText.text = isSelected ? "Выбран" : "Выбрать";
    }

    public void DisplayHeroLevel(int level)
    {
        _levelText.text = $"Уровень: {level}";
    }
}
