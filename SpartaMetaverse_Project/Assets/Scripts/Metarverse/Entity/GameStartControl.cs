using UnityEngine;

public class GameStartControl : MonoBehaviour, IInteractable, ICancelable
{
    private bool isInRange = false;

    public void OnInteract()
    {
        // if (isInRange)
        // {
        //     UIManager.instance.ChangeState(UIState.GameStart);
        //     UIManager.instance.GetGameStartUI().SetGameStartAction(() =>
        //     {
        //         UIManager.instance.ChangeState(UIState.None);
        //     });
        // }
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
            UIManager.instance.ChangeState(UIState.GameStart);
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
