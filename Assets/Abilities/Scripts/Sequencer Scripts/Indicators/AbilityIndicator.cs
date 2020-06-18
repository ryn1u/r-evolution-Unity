using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityIndicator : MonoBehaviour
{
    public bool isShowing;
    public abstract void ShowIndicator();
    public abstract void TriggerEvents();
    public abstract void HideIndicator();
}
