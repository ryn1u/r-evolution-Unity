using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SequencerLineIndicator))]
public class DefaultRangeIndicatorController : MonoBehaviour
{
    public SequencerLineIndicator lineIndicator;
    public bool instantCast = false;

    public void TriggerIndicator(bool input)
    {
        if(instantCast)
        {
            lineIndicator.HideLine();
        }
        else
        {
            if(input)
            {
                lineIndicator.ShowLine();
            }
            else
            {
                lineIndicator.HideLine();
            }
        }
    }
}
