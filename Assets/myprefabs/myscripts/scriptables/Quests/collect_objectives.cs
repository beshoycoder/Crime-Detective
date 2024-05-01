using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "collect_objectives", menuName= "scriptable/Quest_objectives/collect_objectives")]
public class collect_objectives : Quest_Objectives
{
    [SerializeField] private int currently_collected;
    [SerializeField] private int required_amount;
    [SerializeField] private int maximum_collected;
    [SerializeField] private Int_event_scriptables Int_event;
    private void OnEnable()
    {
        base.OnEnable();
        currently_collected = 0;
        Int_event.RegisterListener(Collect_ittems);
        
    }
    private void OnDisable()
    {
        base.OnDisable();
        Int_event.UnregisterListener(Collect_ittems);
    }
    private void Collect_ittems(int number)
    {
        if (is_active)
        {
            currently_collected += number;
            if (required_amount <= currently_collected && currently_collected <= maximum_collected)
            {
                Finish_objective(true);
            }
        }
    }
    protected override void Finish_objective(bool Is_done)
    {
        if (is_active)
        {
            base.Finish_objective(Is_done);
            
        }
    }

    
}
