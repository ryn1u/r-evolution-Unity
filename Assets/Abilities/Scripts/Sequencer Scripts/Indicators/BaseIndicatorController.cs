using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIndicatorController : MonoBehaviour
{
    public AbilityIndicator indicator;
    public SceneEntity entity;

    [Range(0,2)]
    public int mode = 1; //0 - instancast, 1 - quickcast, 2 - normalcast
    public virtual void TriggerIndicator(bool input)
    {
        switch(mode)
        {
            case 0:
                InstantCast(input);
                break;
            case 1:
                QuickCast(input);
                break;
            case 2:
                NormalCast(input);
                break;
        }
    }

    protected virtual void InstantCast(bool input)
    {
        if (input)
        {
            indicator.TriggerEvents();
        }
    }
    protected virtual void QuickCast(bool input)
    {
        if(!indicator.isShowing && input)
        {
            indicator.ShowIndicator();
            indicator.isShowing = true;
        }
        else if(indicator.isShowing && !input)
        {
            indicator.HideIndicator();
            indicator.TriggerEvents();
            indicator.isShowing = false;
        }
    }
    protected virtual void NormalCast(bool input)
    {
        if(!indicator.isShowing && input)
        {
            indicator.isShowing = true;
            indicator.ShowIndicator();
        }
        else if(indicator.isShowing && input)
        {
            indicator.HideIndicator();
            indicator.TriggerEvents();
            indicator.isShowing = false;
        }
    }
}
