using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool_event", menuName = "scriptable/Event/Bool_Event")]
public class Bool_event_scriptables : ScriptableObject
{
    private event System.Action<bool> listeners;

    public void Raise(bool Bool)
    {
        listeners?.Invoke(Bool);
    }

    public void RegisterListener(System.Action<bool> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<bool> listener)
    {
        listeners -= listener;
    }
}
