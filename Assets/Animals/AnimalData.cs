using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Animal Data", menuName = "Gameplay Data/New Animal Data")]
public class AnimalData : ScriptableObject
{
    public int id;
    public string animalName;

    [Expandable]
    public AnimalStats stats;

    [Expandable]
    public List<AbilityData> abilities;

}
