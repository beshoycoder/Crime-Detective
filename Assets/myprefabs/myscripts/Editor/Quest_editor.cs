using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditorInternal;

#if UNITY_EDITOR
[CustomEditor(typeof(Quest))]
[CanEditMultipleObjects]
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
    bool isFoldoutOn2;
    public VisualTreeAsset VisualTreeAsset;
    private ReorderableList reorderableList;

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        VisualTreeAsset.CloneTree(root);

        return root;

    }
    private void OnEnable()
    {
        questNameProperty = serializedObject.FindProperty("Quest_Name");
        questObjectivesProperty = serializedObject.FindProperty("Quest_Objectives");
        onQuestStartProperty = serializedObject.FindProperty("ON_Quest_start");
        onObjectiveStartProperty = serializedObject.FindProperty("ON_Objective_start");
        questFinishEventProperty = serializedObject.FindProperty("Quest_finish_event");
        objFinishEventProperty = serializedObject.FindProperty("obj_finish_event");

        reorderableList = new ReorderableList(serializedObject, questObjectivesProperty, true, true, false, false);

        reorderableList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Quest Objectives");
        };

        reorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            SerializedProperty element = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, rect.width - 60, EditorGUIUtility.singleLineHeight),
                element, GUIContent.none);
            if (GUI.Button(new Rect(rect.x + rect.width - 60, rect.y, 60, EditorGUIUtility.singleLineHeight), "Remove"))
            {
                RemoveQuest(index);
            }
        };

        reorderableList.onAddCallback = (ReorderableList list) =>
        {
            AddQuest();
        };

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
        if (GUILayout.Button("Add objectives", GUILayout.Width(100)))
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
#endif