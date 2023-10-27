using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] private Button Button;

    public event Action OnButtonClicked;

    protected virtual void Start()
    {
        Button.onClick.AddListener(HandleButtonClick);
    }

    public virtual void OnButtonClick()
    {
        OnButtonClicked?.Invoke();
    }

    protected virtual void OnDestroy()
    {
        Button.onClick.RemoveListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        OnButtonClicked?.Invoke();
    }
}
