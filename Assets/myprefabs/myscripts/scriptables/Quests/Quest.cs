using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Quest", menuName = "scriptable/QuestInfo/Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string Quest_Name;
    [SerializeField] private List<Quest_Objectives> Quest_Objectives;
    [SerializeField] private String_event_scriptable ON_Quest_start;
    [SerializeField] private String_event_scriptable ON_Objective_start;
    [SerializeField] private event_scriptables Quest_finish_event;
    [SerializeField] private event_scriptables obj_finish_event;
    private int current_obj;
    private bool Is_Current_quest;
    /// <properties>
    public string Quest_Name1 { get => Quest_Name; set => Quest_Name = value; }
    public List<Quest_Objectives> Quest_Objectives1 { get => Quest_Objectives; set => Quest_Objectives = value; }
    public String_event_scriptable ON_Quest_start1 { get => ON_Quest_start; set => ON_Quest_start = value; }
    public String_event_scriptable ON_Objective_start1 { get => ON_Objective_start; set => ON_Objective_start = value; }
    public event_scriptables Quest_finish_event1 { get => Quest_finish_event; set => Quest_finish_event = value; }
    public event_scriptables Obj_finish_event { get => obj_finish_event; set => obj_finish_event = value; }
    /// </properties>


    private void OnEnable()
    {
        Is_Current_quest = false;
        current_obj=0;
        ON_Quest_start1.RegisterListener(Start_quest);
        Obj_finish_event.RegisterListener(Update_quest);
        
        
    }
    private void OnDisable()
    {
        ON_Quest_start1.UnregisterListener(Start_quest);
        Obj_finish_event.UnregisterListener(Update_quest);
        
    }
    public string Get_name()
    {
        return Quest_Name1;
    }
    public List<string> Get_Objs_Description()
    {
        List<string> objs = new List<string>();
        foreach(Quest_Objectives _Objective in Quest_Objectives1)
        {
            objs.Add(_Objective.Get_description());
        }
        return objs;

    }
    private void Start_quest(string name)
    {
        if(name == Quest_Name1)
        {

            Is_Current_quest= true;
            Start_Obj(current_obj);
        }
        
    }
    private void Start_Obj(int index)
    {
        if (Is_Current_quest)
        {
            //Debug.Log($"quest{Quest_Name1},obj{current_obj}");
            Quest_Objectives1[index].Set_obj_active();
        }

    }
    private void Update_quest()
    {
        if (Is_Current_quest)
        {
            current_obj = current_obj + 1;
            //Debug.Log(current_obj);
            //Debug.Log(Quest_Objectives1.Count);

            if (current_obj == Quest_Objectives1.Capacity)
            {
                Finish_Quest();
                Debug.Log("no more objectives");
            }
            else
            {
                Debug.Log("next objective coming up");
                Start_Obj(current_obj);
            }
        }
    }
    private void Finish_Quest()
    {
        if (Is_Current_quest)
        {
            Quest_finish_event1.Raise();
            Is_Current_quest = false;
        }

        
    }
   
}
