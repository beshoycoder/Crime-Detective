using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Void_event", menuName = "scriptable/Event/Void_Event")]
public class event_scriptables : ScriptableObject
{
    private UnityEvent listeners = new UnityEvent();

    public void Raise()
    {
        listeners?.Invoke();
    }

    public void RegisterListener(UnityAction listener)
    {
        listeners.AddListener(listener);
    }

    public void UnregisterListener(UnityAction listener)
    {
        listeners.RemoveListener(listener);
    }
}


