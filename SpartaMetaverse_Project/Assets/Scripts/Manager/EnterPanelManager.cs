using UnityEngine;
using UnityEngine.UI;

public class EnterPanelManager : MonoBehaviour
{
    public static EnterPanelManager instance;

    public GameObject panel;
    public Button enterButton;
    public Button cancelButton;
    public Transform destinationPoint; // 입장 위치
    public GameObject player;

    private void Awake()
    {
        instance = this;
        panel.SetActive(false);

        enterButton.onClick.AddListener(Enter);
        cancelButton.onClick.AddListener(HidePanel);
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }

    public void Enter()
    {
        player.transform.position = destinationPoint.position;
        HidePanel();
    }

    void Update()
    {
        if (!panel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.F))
            Enter();

        if (Input.GetKeyDown(KeyCode.C))
            HidePanel();
    }
}
