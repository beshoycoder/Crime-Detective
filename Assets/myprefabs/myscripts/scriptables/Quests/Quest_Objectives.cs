using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Quest_Objectives : ScriptableObject
{
    [SerializeField] protected string Name;
    [SerializeField] private string descriptions;
    [SerializeField] protected String_event_scriptable Obj_finish;
    [SerializeField] protected event_scriptables obj_finish_event;
    protected bool is_active;

    protected virtual void OnEnable()
    {
        is_active = false;
        
    }
    protected virtual void OnDisable()
    {
        is_active = false;
    }
    public void Set_obj_active()
    {
        is_active = true;
    }
    public string Get_description() { return descriptions; }
    private void Set_obj_Inactive()
    {
        is_active = false;
    }
    private void Awake()
    {
       
        is_active = false;
    }
    protected virtual void Finish_objective(bool Is_done)
    {
        Set_obj_Inactive();
        //inform quest that the objective is finished
        obj_finish_event.Raise();
        //inform UI that the objective is finished
        Obj_finish.Raise(descriptions);
    }
}
