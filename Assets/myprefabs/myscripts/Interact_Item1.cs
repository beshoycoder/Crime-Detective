using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Events;
public class interact_item : MonoBehaviour, interactionAI
{
    [SerializeField] private GameObject outlined;
    public UnityEvent OnInteraction;

    public void disable_Outline()
    {
        outlined.SetActive(false);
    }

    public void enable_Outline()
    {
        outlined.SetActive(true);
    }

    public void Interact()
    {
        IINteract();
    }
    void Start()
    {
        outlined.SetActive(false);
    }
    private void IINteract()
    {
        OnInteraction.Invoke();

    }

}
