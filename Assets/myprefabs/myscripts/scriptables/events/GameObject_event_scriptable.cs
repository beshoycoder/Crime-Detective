using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameObject_event", menuName = "scriptable/Event/GameObject_Event")]
public class GameObject_event_scriptable : ScriptableObject
{
    private event System.Action<GameObject> listeners;

    public void Raise(GameObject Number)
    {
        listeners?.Invoke(Number);
    }

    public void RegisterListener(System.Action<GameObject> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<GameObject> listener)
    {
        listeners -= listener;
    }

}
