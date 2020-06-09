using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;

public class AnimalDataEditor : EditorWindow
{
    [MenuItem("Window/Animal Data Editor")]
    public static void OpenWindow()
    {
        GetWindow<AnimalDataEditor>("Animal Data Editor");
    }

    string newName = "";
    Vector2 scrollPos;
    private List<AnimalData> animalDatabase;
    private void OnGUI()
    {
        float windowWidth = position.width;
        float nameFieldWidth = windowWidth * 0.3f;
        float elseFieldWidth = (windowWidth - nameFieldWidth) / 8;
        //str, def, pwr, will, agi, hp
        //name, id
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        Rect topLabels = EditorGUILayout.BeginHorizontal("Label", GUILayout.MinWidth(10),GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField("Id", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.LabelField("Name", GUILayout.Width(nameFieldWidth));
        EditorGUILayout.LabelField("STR", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.LabelField("DEF", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.LabelField("PWR", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.LabelField("WILL", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.LabelField("AGI", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.LabelField("HP", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.EndHorizontal();

        foreach(AnimalData entry in animalDatabase)
        {
            EditorGUILayout.BeginHorizontal();
            entry.id = EditorGUILayout.IntField(entry.id, GUILayout.Width(elseFieldWidth/2));
            entry.animalName = EditorGUILayout.TextField(entry.animalName, GUILayout.Width(nameFieldWidth));
            entry.STR = EditorGUILayout.IntField(entry.STR, GUILayout.Width(elseFieldWidth));
            entry.DEF = EditorGUILayout.IntField(entry.DEF, GUILayout.Width(elseFieldWidth));
            entry.PWR = EditorGUILayout.IntField(entry.PWR, GUILayout.Width(elseFieldWidth));
            entry.WILL = EditorGUILayout.IntField(entry.WILL, GUILayout.Width(elseFieldWidth));
            entry.AGI = EditorGUILayout.IntField(entry.AGI, GUILayout.Width(elseFieldWidth));
            entry.HP = EditorGUILayout.IntField(entry.HP, GUILayout.Width(elseFieldWidth));
            if(GUILayout.Button("Abilities"))
            {
                AnimalAbilityEditor.OpenWindow();
                AnimalAbilityEditor abiEditor = GetWindow<AnimalAbilityEditor>();
                abiEditor.SetCurrentAnimal(entry);
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.BeginHorizontal(GUILayout.Width(nameFieldWidth + elseFieldWidth/2));
        newName = EditorGUILayout.TextField(newName, GUILayout.Width(nameFieldWidth));
        if(GUILayout.Button("+"))
        {
            CreateNewAnimal(newName);
            newName = "";
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndScrollView();
    }
    private void OnEnable()
    {
        animalDatabase = GetAnimalDatabase();
    }
    private void OnProjectChange()
    {
        animalDatabase = GetAnimalDatabase();
    }

    public void CreateNewAnimal(string name)
    {
        AnimalData animalData = ScriptableObject.CreateInstance<AnimalData>();
        animalData.animalName = name;
        AssetDatabase.CreateAsset(animalData, "Assets/Animals/" + name + ".asset");
    }
    public List<AnimalData> GetAnimalDatabase()
    {
        List<AnimalData> output = new List<AnimalData>();
        string[] guids = AssetDatabase.FindAssets("t:AnimalData");
        foreach(string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            AnimalData data = AssetDatabase.LoadAssetAtPath<AnimalData>(path);
            output.Add(data);
        }

        return output;
    }
}
