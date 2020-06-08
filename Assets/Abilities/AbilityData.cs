using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability Data", menuName = "Gameplay Data/New Ability Data")]
public class AbilityData : ScriptableObject
{
    public FloatReference cooldown;
    public string abilityName;
    [TextArea(3,10)]
    public string description;
    [Expandable]
    public List<ScriptableObject> data;
}
