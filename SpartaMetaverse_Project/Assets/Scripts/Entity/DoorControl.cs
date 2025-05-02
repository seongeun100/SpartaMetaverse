using UnityEngine;
using UnityEngine.InputSystem;

public class DoorControl : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private Collider2D triggerCollider;
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private Animator animator;


    private void Awake()
    {
    }

    public void OnInteract()
    {
        if (isPlayerInRange)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            animator.SetBool("IsOpen", false);
            doorCollider.enabled = true;
        }
    }
}
