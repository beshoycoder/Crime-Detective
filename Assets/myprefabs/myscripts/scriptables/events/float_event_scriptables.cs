using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Float_event", menuName = "scriptable/Event/Float_Event")]
public class Float_event_scriptables : ScriptableObject
{
    private event System.Action<float> listeners;

    public void Raise(float Number)
    {
        listeners?.Invoke(Number);
    }

    public void RegisterListener(System.Action<float> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<float> listener)
    {
        listeners -= listener;
    }
}
