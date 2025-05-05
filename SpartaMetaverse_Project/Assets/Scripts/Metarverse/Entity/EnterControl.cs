using UnityEngine;

public class EnterControl : MonoBehaviour, IInteractable, ICancelable
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private GameObject player;

    private bool isInRange = false;

    public void OnInteract()
    {
        if (isInRange)
        {
            player.transform.position = targetPosition.position;
            UIManager.instance.ChangeState(UIState.None);
        }
    }

    public void OnCancel()
    {
        if (isInRange)
        {
            UIManager.instance.ChangeState(UIState.None);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            UIManager.instance.ChangeState(UIState.Enter);
            UIManager.instance.GetEnterUI().SetEnterAction(() =>
            {
                player.transform.position = targetPosition.position;
                UIManager.instance.ChangeState(UIState.None);
            });
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            UIManager.instance.ChangeState(UIState.None);
        }
    }
}
