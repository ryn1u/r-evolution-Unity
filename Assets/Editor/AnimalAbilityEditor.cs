using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;
using System.Linq;
using NUnit.Framework;

public class AnimalAbilityEditor : EditorWindow
{
    [MenuItem("Window/Animal Ability Editor")]
    public static void OpenWindow()
    {
        GetWindow<AnimalAbilityEditor>("Animal Data Editor");
    }

    Vector2 scrollPos;
    private List<AbilityData> abilityDatabase;
    private List<AnimalData> animalDatabase;
    private Dictionary<string, AnimalData> animalList;
    private AnimalData currentAnimal;
    private AbilityData currentAbility;
    private string[] names;

    private bool hasAbility
    {
        get
        {
            if(currentAnimal != null && currentAbility != null)
            {
                return currentAnimal.abilities.Contains(currentAbility);
            }
            else
            {
                return false;
            }
        }
        set
        {
            if (currentAnimal != null && currentAbility != null)
            {
                if (value && !hasAbility)
                {
                    currentAnimal.abilities.Add(currentAbility);
                }
                else if(!value && hasAbility)
                {
                    currentAnimal.abilities.Remove(currentAbility);
                }
            }
        }
    }

    int index = 0;
    private void OnGUI()
    {
        float windowWidth = position.width;
        float nameFieldWidth = windowWidth * 0.6f;
        float elseFieldWidth = (windowWidth - nameFieldWidth) / 3;
        //str, def, pwr, will, agi, hp
        //name, id
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        index = EditorGUILayout.Popup(index, names);

        currentAnimal = animalList[names[index]];
        titleContent = new GUIContent(currentAnimal.animalName + " Abiliy Editor");

        foreach(AbilityData ability in abilityDatabase)
        {
            currentAbility = ability;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(ability.abilityName, GUILayout.Width(elseFieldWidth));
            EditorGUILayout.LabelField(ability.description, GUILayout.Width(nameFieldWidth));
            hasAbility = EditorGUILayout.Toggle(hasAbility);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();
    }
    private void OnEnable()
    {
        abilityDatabase = GetAbilityDatabase();
        animalDatabase = GetAnimalDatabase();
        animalList = GetAnimalList(animalDatabase);
        names = GetAnimalNamesArray(animalDatabase);
    }
    private void OnProjectChange()
    {
        abilityDatabase = GetAbilityDatabase();
        animalDatabase = GetAnimalDatabase();
        animalList = GetAnimalList(animalDatabase);
        names = GetAnimalNamesArray(animalDatabase);
    }

    public static List<AbilityData> GetAbilityDatabase()
    {
        List<AbilityData> output = new List<AbilityData>();
        string[] guids = AssetDatabase.FindAssets("t:AbilityData");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            AbilityData data = AssetDatabase.LoadAssetAtPath<AbilityData>(path);
            output.Add(data);
            Debug.Log("abi data: " + data.abilityName);
        }
        return output;
    }

    public static Dictionary<string, AnimalData> GetAnimalList(List<AnimalData> database)
    {
        Dictionary<string, AnimalData> output = new Dictionary<string, AnimalData>();

        foreach(AnimalData data in database)
        {
            output.Add(data.animalName, data);
        }

        return output; ;
    }
    public static List<AnimalData> GetAnimalDatabase()
    {
        List<AnimalData> output = new List<AnimalData>();
        string[] guids = AssetDatabase.FindAssets("t:AnimalData");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            AnimalData data = AssetDatabase.LoadAssetAtPath<AnimalData>(path);
            output.Add(data);
        }
        return output;
    }
    public static string[] GetAnimalNamesArray(List<AnimalData> database)
    {
        List<string> names = new List<string>();
        foreach(AnimalData a in database)
        {
            names.Add(a.animalName);
        }
        return names.ToArray();
    }

    public void SetCurrentAnimal(AnimalData animal)
    {
        if(names.Count() != 0)
        {
            currentAnimal = animal;
            for(int i = 0; i < names.Count(); i++)
            {
                if(animal.animalName == names[i])
                {
                    index = i;
                    return;
                }
            }
        }
    }
}
