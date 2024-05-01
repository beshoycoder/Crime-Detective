using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Int_event", menuName = "scriptable/Event/Int_Event")]
public class Int_event_scriptables : ScriptableObject
{
    private event System.Action<int> listeners;

    public void Raise(int Number)
    {
        listeners?.Invoke(Number);
    }

    public void RegisterListener(System.Action<int> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<int> listener)
    {
        listeners -= listener;
    }
}
