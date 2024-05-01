using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_managers : MonoBehaviour
{
    [SerializeField] private Int_event_scriptables IntEvent;
    [SerializeField] private String_event_scriptable Npc_name_event;
    [SerializeField] private String_event_scriptable talk_to_sara;


    public void collect_item()
    {
        IntEvent.Raise(1);
    }
    public void Talk_TO(string name)
    {
        Npc_name_event.Raise(name);
    }
    public void Talk_TO_sara(string name)
    {
        talk_to_sara.Raise(name);
    }
}
