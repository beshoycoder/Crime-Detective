using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    private SerializedProperty questNameProperty;
    private SerializedProperty questObjectivesProperty;
    private SerializedProperty onQuestStartProperty;
    private SerializedProperty onObjectiveStartProperty;
    private SerializedProperty questFinishEventProperty;
    private SerializedProperty objFinishEventProperty;
    private Texture2D reorderHandleIcon;
    bool isFoldoutOn;

    private void OnEnable()
    {
        questNameProperty = serializedObject.FindProperty("Quest_Name");
        questObjectivesProperty = serializedObject.FindProperty("Quest_Objectives");
        onQuestStartProperty = serializedObject.FindProperty("ON_Quest_start");
        onObjectiveStartProperty = serializedObject.FindProperty("ON_Objective_start");
        questFinishEventProperty = serializedObject.FindProperty("Quest_finish_event");
        objFinishEventProperty = serializedObject.FindProperty("obj_finish_event");

        reorderHandleIcon = EditorGUIUtility.FindTexture("MoveTool");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(questNameProperty);
        EditorGUILayout.LabelField("Quest Objectives", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        for (int i = 0; i < questObjectivesProperty.arraySize; i++)
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
            EditorGUILayout.PropertyField(questObjectivesProperty.GetArrayElementAtIndex(i), GUIContent.none);
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
            EditorGUILayout.PropertyField(onObjectiveStartProperty);
            EditorGUILayout.PropertyField(questFinishEventProperty);
            EditorGUILayout.PropertyField(objFinishEventProperty);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
    private void AddQuest()
    {
        serializedObject.Update();
        questObjectivesProperty.InsertArrayElementAtIndex(questObjectivesProperty.arraySize);
        serializedObject.ApplyModifiedProperties();
    }

    private void RemoveQuest(int index)
    {
        serializedObject.Update();
        questObjectivesProperty.DeleteArrayElementAtIndex(index);
        serializedObject.ApplyModifiedProperties();
    }
    private void MoveObjectiveUp(int index)
    {
        if (index > 0)
        {
            questObjectivesProperty.MoveArrayElement(index, index - 1);
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void MoveObjectiveDown(int index)
    {
        if (index < questObjectivesProperty.arraySize - 1)
        {
            questObjectivesProperty.MoveArrayElement(index, index + 1);
            serializedObject.ApplyModifiedProperties();
        }

    }
}
