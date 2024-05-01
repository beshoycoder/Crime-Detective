using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Talk_objectives", menuName = "scriptable/Quest_objectives/Talk_objectives")]
public class Talk_to_Objectives : Quest_Objectives
{
    
    [SerializeField] private String_event_scriptable Talked_to;
    [SerializeField] private List<NPC> Npcs;
    private bool Talked_to_all;
    private void OnEnable()
    {
        base.OnEnable();
        Reset_npcs();
        Talked_to.RegisterListener(Check_Npc);
    }
    private void OnDisable()
    {
        base.OnDisable();
        Talked_to.UnregisterListener(Check_Npc);
        
    }
    private void Reset_npcs()
    {
        foreach (NPC npc in Npcs)
        {
            npc.Talked_to = false;
        }
    }
    private void Check_Npc(string npc_name)
    {
        if (is_active)
        {
            int npcIndex = Npcs.FindIndex(required => required.Npc_name == npc_name);
            //Debug.Log(npcIndex);
            if (npcIndex >= 0)
            {
                Npcs[npcIndex].Talked_to = true;
                Check_of_all_TalkedTo();
            }
        }
    }
    private void Check_of_all_TalkedTo()
    {
        if (Npcs.Count>0) 
        {
            for (int i = 0; i < Npcs.Count; i++)
            {
                if (Npcs[i].Talked_to == false)
                {
                    Talked_to_all=false;
               
                    break;
                }
                else
                {
                   Talked_to_all= true;


                }
            }
        }
        else
        {
            Talked_to_all = true;
          
        }

        Finish_objective(Talked_to_all);
        

    }
    protected override void Finish_objective(bool Is_done)
    {
        if (is_active)
        {
            base.Finish_objective(Is_done);
            Reset_npcs();
            
            
        }
    }

}

[Serializable]
class NPC
{
    public string Npc_name;
    public bool Talked_to;
    public void Set_talked(bool value)
    {
        Talked_to = value;
    }
}
