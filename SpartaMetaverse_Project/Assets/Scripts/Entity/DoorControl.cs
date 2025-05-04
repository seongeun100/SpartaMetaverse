using UnityEngine;

public class DoorControl : MonoBehaviour, IInteractable
{
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private Animator animator;

    public void OnInteract()
    {
        if (doorCollider.enabled)
        {
            animator.SetBool("IsOpen", true);
            doorCollider.enabled = false;
        }
        else
        {
            animator.SetBool("IsOpen", false);
            doorCollider.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", false);
            doorCollider.enabled = true;
        }
    }

}
