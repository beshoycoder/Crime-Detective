using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UI_Quest_Event", menuName = "scriptable/Event/UI_Quest_Event")]
public class UI_Quest_event_scriptable :ScriptableObject
{

    private event System.Action<Quest_Manager.Quest_UI> listeners;

    public void Raise(Quest_Manager.Quest_UI Number)
    {
        listeners?.Invoke(Number);
    }

    public void RegisterListener(System.Action<Quest_Manager.Quest_UI> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<Quest_Manager.Quest_UI> listener)
    {
        listeners -= listener;
    }

}
