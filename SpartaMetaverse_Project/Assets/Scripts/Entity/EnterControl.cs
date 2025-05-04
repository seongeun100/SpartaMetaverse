using UnityEngine;
using UnityEngine.UI;

public class EnterControl : MonoBehaviour, IInteractable, ICancelable
{
    [SerializeField] private GameObject enterPanel;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private GameObject player;
    private bool isPanelActive = false;

    public void OnInteract()
    {
        if (!isPanelActive) return;
        player.transform.position = targetPosition.position;
        enterPanel.SetActive(false);

    }

    public void OnCancel()
    {
        isPanelActive = false;
        enterPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enterPanel.SetActive(true);
            isPanelActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enterPanel.SetActive(false);
            isPanelActive = false;
        }
    }
}
