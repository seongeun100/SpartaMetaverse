using UnityEngine;
using System;

public abstract class BaseUI<TEnum, TManager> : MonoBehaviour where TEnum : Enum
{
    protected TManager uiManager;

    public virtual void Init(TManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract TEnum GetUIState();

    public void SetActive(TEnum state)
    {
        gameObject.SetActive(GetUIState().Equals(state));
    }
}
