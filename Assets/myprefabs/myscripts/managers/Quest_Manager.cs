using System.Collections.Generic;
using UnityEngine;



public class Quest_Manager : MonoBehaviour
{
    [SerializeField] private List<Quest> Quests;
    [SerializeField] private String_event_scriptable ON_Quest_Start;
    [SerializeField] private event_scriptables ON_Quest_End;
    [SerializeField] private UI_Quest_event_scriptable uI_Quest_Event_Scriptable;
    private Quest_UI quest_UI;
    private int currentQuestIndex;

    private void OnEnable()
    {
        ON_Quest_End.RegisterListener(UpdateQuest);
    }

    private void OnDisable()
    {
        ON_Quest_End.UnregisterListener(UpdateQuest);
    }

    private void Start()
    {
        quest_UI = new Quest_UI();
        currentQuestIndex = 0;
        StartQuest(currentQuestIndex);
    }

    private void StartQuest(int index)
    {
        //get name and description for UI
        quest_UI.Quest_UI_name = Quests[index].Get_name();
        quest_UI.Quest_UI_Objectives = Quests[index].Get_Objs_Description();
        //get name to start quest by indexs
        string questName = Quests[index].Get_name();
        //start quest
        ON_Quest_Start.Raise(questName);
        //send quest data to UI
        uI_Quest_Event_Scriptable.Raise(quest_UI);
       // Debug.Log(questName);
    }

    private void UpdateQuest()
    {
        currentQuestIndex++;
        if (currentQuestIndex == Quests.Count)
        {
        }
        else
        {
            Debug.Log($"Starting Quest{currentQuestIndex}");
            StartQuest(currentQuestIndex);
            
            
        }
    }
    public class Quest_UI
    {
        public string Quest_UI_name;
        public List<string> Quest_UI_Objectives;

    }
}
