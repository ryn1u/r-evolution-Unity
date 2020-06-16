using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimalStats : ScriptableObject
{
    [Expandable]
    public STR str;
    [Expandable]
    public DEF def;
    [Expandable]
    public PWR pwr;
    [Expandable]
    public WILL will;
    [Expandable]
    public AGI agi;
    [Expandable]
    public END end;

    public void SetStats(int str, int def, int pwr, int will, int agi, int end)
    {
        SetStat<STR>(str);
        SetStat<DEF>(def);
        SetStat<PWR>(pwr);
        SetStat<WILL>(will);
        SetStat<AGI>(agi);
        SetStat<END>(end);
    }
    public void SetStat<T>(int amount) where T :AnimalStat
    {
        string type = typeof(T).ToString();
        switch (type)
        {
            case "STR":
                str.amount = amount;
                break;
            case "DEF":
                def.amount = amount;
                break;
            case "PWR":
                pwr.amount = amount;
                break;
            case "WILL":
                will.amount = amount;
                break;
            case "AGI":
                agi.amount = amount;
                break;
            case "END":
                end.amount = amount;
                break;
        }
    }
    public void SetStat(AnimalStat stat)
    {
        string type = stat.GetType().ToString();
        switch (type)
        {
            case "STR":
                str = stat as STR;
                break;
            case "DEF":
                def = stat as DEF;
                break;
            case "PWR":
                pwr = stat as PWR;
                break;
            case "WILL":
                will = stat as WILL;
                break;
            case "AGI":
                agi = stat as AGI;
                break;
            case "END":
                end = stat as END;
                break;
        }
    }
}
