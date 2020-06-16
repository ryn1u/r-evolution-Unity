using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;
using System.Linq;
using System.IO;

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
        EditorGUILayout.LabelField("END", GUILayout.Width(elseFieldWidth));
        EditorGUILayout.EndHorizontal();

        foreach(AnimalData entry in animalDatabase)
        {
            EditorGUILayout.BeginHorizontal();
            entry.id = EditorGUILayout.IntField(entry.id, GUILayout.Width(elseFieldWidth/2));
            entry.animalName = EditorGUILayout.TextField(entry.animalName, GUILayout.Width(nameFieldWidth));
            StatField(entry.stats.str, elseFieldWidth);
            StatField(entry.stats.def, elseFieldWidth);
            StatField(entry.stats.pwr, elseFieldWidth);
            StatField(entry.stats.will, elseFieldWidth);
            StatField(entry.stats.agi, elseFieldWidth);
            StatField(entry.stats.end, elseFieldWidth);

            if(GUILayout.Button("Abilities"))
            {
                AnimalAbilityEditor.OpenWindow();
                AnimalAbilityEditor abiEditor = GetWindow<AnimalAbilityEditor>();
                abiEditor.SetCurrentAnimal(entry);
            }
            if(GUILayout.Button("delete"))
            {
                DeleteAnimal(entry);
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.BeginHorizontal(GUILayout.Width(nameFieldWidth + elseFieldWidth/2));
        newName = EditorGUILayout.TextField(newName, GUILayout.Width(nameFieldWidth));
        if(GUILayout.Button("+"))
        {
            int id = GetAvaibleAnimalID(animalDatabase);
            CreateNewAnimal(newName, id);
            newName = "";
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndScrollView();
    }
    private void OnEnable()
    {
        animalDatabase = DatabaseUtility.GetAssetsFromDatabase<AnimalData>("AnimalData");
        animalDatabase.Sort(AnimalIDComparator);
    }
    private void OnProjectChange()
    {
        animalDatabase = DatabaseUtility.GetAssetsFromDatabase<AnimalData>("AnimalData");
        animalDatabase.Sort(AnimalIDComparator);
    }

    public void CreateNewAnimal(string name, int id)
    {
        AnimalData data = CreateInstance<AnimalData>();
        data.animalName = name;
        data.id = id;

        string folderName = name + "Data";
        AssetDatabase.CreateFolder(DatabaseUtility.animalsDatabasePath.TrimEnd('/'), folderName);
        Debug.Log(DatabaseUtility.animalsDatabasePath);
        Debug.Log(folderName);

        data.stats = CreateNewStats(data);
        AssetDatabase.CreateAsset(data, DatabaseUtility.PathToAnimalDataFile(data));
    }
    public AnimalStats CreateNewStats(AnimalData data)
    {
        AnimalStats stats = CreateInstance<AnimalStats>();
        stats.str = CreateStat<STR>(data);
        stats.def = CreateStat<DEF>(data);
        stats.pwr = CreateStat<PWR>(data);
        stats.will = CreateStat<WILL>(data);
        stats.agi = CreateStat<AGI>(data);
        stats.end = CreateStat<END>(data);
        AssetDatabase.CreateAsset(stats, DatabaseUtility.PathToAnimalDatabseFiles(data) + data.animalName + "_Stats.asset");
        return stats;
    }
    public T CreateStat<T>(AnimalData data) where T : AnimalStat
    {
        T stat = CreateInstance<T>();
        stat.amount = 0;
        stat.isMultiplier = false;
        stat.multiplier = 1;
        string assetName = data.animalName + "_" + stat.GetType().ToString() + "stat.asset";
        AssetDatabase.CreateAsset(stat, DatabaseUtility.PathToAnimalDatabseFiles(data) + assetName);
        return stat;
    }

    public void StatField<T>(T stat, float fieldWidth) where T : AnimalStat
    {
        stat.amount = EditorGUILayout.IntField(stat.amount, GUILayout.Width(fieldWidth));
    }

    public void DeleteAnimal(AnimalData data)
    {
        AssetDatabase.DeleteAsset(DatabaseUtility.PathToAnimalDataFile(data));
        FileUtil.DeleteFileOrDirectory(DatabaseUtility.PathToAnimalDatabseFiles(data));
    }

    public int GetAvaibleAnimalID(List<AnimalData> database)
    {
        int output = 0;
        
        while(true)
        {
            if(database.Any(x => x.id == output))
            {
                output++;
            }
            else
            {
                return output;
            }
        }
    }

    private int AnimalIDComparator(AnimalData x, AnimalData y)
    {
        if(x.id == y.id)
        {
            return 0;
        }
        else
        {
            return x.id < y.id ? -1 : 1;
        }
    }
}
