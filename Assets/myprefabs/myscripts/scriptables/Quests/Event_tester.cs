using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_tester : MonoBehaviour
{
    [SerializeField] private Int_event_scriptables IntEvent;

    private void OnEnable()
    {
        IntEvent.RegisterListener(recive);
    }
    private void OnDisable()
    {
        IntEvent.UnregisterListener(recive);
    }
    private void recive(int num)
    {
        Debug.Log("recvived");
    }
}
