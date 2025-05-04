using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcControl : MonoBehaviour, IInteractable, ICancelable
{
    [SerializeField] private int id;
    public int Id => id;

    public void OnInteract()
    {
        GameManager.instance.Interaction(gameObject);
    }

    public void OnCancel()
    {
        GameManager.instance.CancelTalk();
    }
}
