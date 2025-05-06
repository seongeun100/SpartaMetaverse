using UnityEngine;
using System;

// 제네릭을 사용해서 확정성 있게 받음 (TEnum은 무조건 Enum만 가능)
public abstract class BaseUI<TEnum, TManager> : MonoBehaviour where TEnum : Enum
{
    // 상속받은 UIManager를 저장
    protected TManager uiManager;

    // UIManager에서 이 UI에 전달하여 내부에서 참조 가능
    public virtual void Init(TManager uiManager)
    {
        // UIManager를 내부에 저장
        this.uiManager = uiManager;
    }

    // 이 UI가 어떤 상태인지 자식 클래스에서 정의
    protected abstract TEnum GetUIState();

    // 현재 상태와 UI가 일치하면 활성화
    public void SetActive(TEnum state)
    {
        gameObject.SetActive(GetUIState().Equals(state));
    }
}
