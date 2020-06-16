using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class DatabaseUtility
{
    public static List<T> GetAssetsFromDatabase<T>(string typeName) where T : UnityEngine.Object
    {
        List<T> output = new List<T>();
        string[] guids = AssetDatabase.FindAssets("t:" + typeName);
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            T data = AssetDatabase.LoadAssetAtPath<T>(path);
            output.Add(data);
        }

        return output;
    }

    public static string animalsDataFilesPath = "Assets/Animals/Database/Animal Data Files/";
    public static string animalsDatabasePath = "Assets/Animals/Database/";

    public static string PathToAnimalDataFile(AnimalData data)
    {
        return animalsDataFilesPath + data.animalName + ".asset";
    }
    public static string PathToAnimalDatabseFiles(AnimalData data)
    {
        return animalsDatabasePath + data.animalName + "Data/";
    }
}
