using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Quest_Manager))]
public class QuestManagerEditor : Editor
{
    private SerializedProperty questsProperty;
    private SerializedProperty onQuestStartProperty;
    private SerializedProperty onQuestEndProperty;
    private SerializedProperty uI_Quest_Event_Scriptable;
    private Texture2D reorderHandleIcon;

   
    bool isFoldoutOn;

    private void OnEnable()
    {
        questsProperty = serializedObject.FindProperty("Quests");
        onQuestStartProperty = serializedObject.FindProperty("ON_Quest_Start");
        onQuestEndProperty = serializedObject.FindProperty("ON_Quest_End");
        reorderHandleIcon = EditorGUIUtility.FindTexture("MoveTool");
        uI_Quest_Event_Scriptable = serializedObject.FindProperty("uI_Quest_Event_Scriptable");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Quests", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        // Draw quests list without default buttons
        for (int i = 0; i < questsProperty.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("^", GUILayout.Width(20)))
            {
                MoveObjectiveUp(i);
            }

            if (GUILayout.Button("v", GUILayout.Width(20)))
            {
                MoveObjectiveDown(i);
            }
            EditorGUILayout.PropertyField(questsProperty.GetArrayElementAtIndex(i), GUIContent.none);
            if (GUILayout.Button("remove", GUILayout.Width(60)))
            {
                RemoveQuest(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUI.indentLevel--;

        
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Add Quest", GUILayout.Width(100)))
            {
                AddQuest();
            }
            EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.EndFoldoutHeaderGroup();
        isFoldoutOn = EditorGUILayout.BeginFoldoutHeaderGroup(isFoldoutOn, "Events");

        if (isFoldoutOn)
        {
            EditorGUILayout.PropertyField(onQuestStartProperty);
            EditorGUILayout.PropertyField(onQuestEndProperty);
            EditorGUILayout.PropertyField(uI_Quest_Event_Scriptable);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();


        serializedObject.ApplyModifiedProperties();
    }

    private void AddQuest()
    {
        serializedObject.Update();
        questsProperty.InsertArrayElementAtIndex(questsProperty.arraySize);
        serializedObject.ApplyModifiedProperties();
    }

    private void RemoveQuest(int index)
    {
        serializedObject.Update();
        questsProperty.DeleteArrayElementAtIndex(index);
        serializedObject.ApplyModifiedProperties();
    }
    private void MoveObjectiveUp(int index)
    {
        if (index > 0)
        {
            questsProperty.MoveArrayElement(index, index - 1);
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void MoveObjectiveDown(int index)
    {
        if (index < questsProperty.arraySize - 1)
        {
            questsProperty.MoveArrayElement(index, index + 1);
            serializedObject.ApplyModifiedProperties();
        }

    }
}
