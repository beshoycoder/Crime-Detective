using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "String_event", menuName = "scriptable/Event/String_Event")]
public class String_event_scriptable : ScriptableObject
{
    private event System.Action<string> listeners;

    public void Raise(string Number)
    {
        listeners?.Invoke(Number);
    }

    public void RegisterListener(System.Action<string> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<string> listener)
    {
        listeners -= listener;
    }
}
