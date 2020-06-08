using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal Data", menuName = "Gameplay Data/New Animal Data")]
public class AnimalData : ScriptableObject
{
    public int id;
    public string animalName;
    public int STR, DEF, PWR, WILL, AGI, HP;

    public List<AbilityData> abilities;
}
