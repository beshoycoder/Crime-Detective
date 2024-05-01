using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Quest_Manager;
using Unity.VisualScripting;


public class UI_manager : MonoBehaviour
{
    //event to recive quest details class or struct in the quest manager
    //event to recive on obj done with string
    [SerializeField] private UI_Quest_event_scriptable Current_Quest_Event;
    [SerializeField] private String_event_scriptable On_Obj_finished;
    [SerializeField] private TextMeshProUGUI Obj_text;
    //this is for the scroll view used to add the quest objectives
    [SerializeField] private Transform content;
    //is a UI component that contains a white image and text to display objectives
    [SerializeField] private GameObject OBJ_UI;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject quests_done;
    [SerializeField] private List<GameObject> Quest_Obj_UI;

    private void OnEnable()
    {
        Current_Quest_Event.RegisterListener(Update_Quest_UI);
        On_Obj_finished.RegisterListener(UPdate_Obj_UI);
    }
    private void OnDisable()
    {
        Current_Quest_Event.UnregisterListener(Update_Quest_UI);
        On_Obj_finished.UnregisterListener(UPdate_Obj_UI);
    }
    void Start()
    {
        panel.SetActive(true);
        quests_done.SetActive(false);
        
    }
    void Update() 
    { 
        
    
    
    }

    private void Update_Quest_UI(Quest_Manager.Quest_UI quest_UI)
    {
        if (content.childCount > 0)
        {
            Clear_Ui();
            Display_quest(quest_UI);
        }
        else
        {
            Display_quest(quest_UI);
        }
        //Debug.Log($"quest revived= {quest_UI.Quest_UI_name}");
    }
    private void Clear_Ui()
    {
        for (int i = 0; i < Quest_Obj_UI.Count; i++)
        {
            Destroy(Quest_Obj_UI[i]);
        }
    }
    private void Display_quest(Quest_Manager.Quest_UI quest_)
    {
        Obj_text.text = quest_.Quest_UI_name;
        for (int i = 0; i <= quest_.Quest_UI_Objectives.Count - 1; i++)
        {
            GameObject desc_text = Instantiate(OBJ_UI, content);
            TextMeshProUGUI textMeshPro = desc_text.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = quest_.Quest_UI_Objectives[i];
            Quest_Obj_UI.Add(desc_text);
        }

    }
    private void UPdate_Obj_UI(string name)
    {
        for (int i = 0; i < Quest_Obj_UI.Count; i++)
        {
           string OBj_text= Quest_Obj_UI[i].GetComponentInChildren<TextMeshProUGUI>().text;
          if(OBj_text ==name)
          {
                Image Obj_image = Quest_Obj_UI[i].GetComponentInChildren<Image>();
                Obj_image.color = Color.green;
          }
           
           
        }
        // Debug.Log($"obj finished= {name}");
    }
    public void Quest_Done()
    {
        quests_done.SetActive(true);
        panel.SetActive(false);
    }
    
   
}
