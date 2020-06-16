using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class AnimalStat : ScriptableObject
{
    public int amount;
    public float multiplier;
    public bool isMultiplier;

    public AnimalStat()
    {
        amount = 0;
        multiplier = 1;
        isMultiplier = false;
    }
    public AnimalStat(int amount)
    {
        this.amount = amount;
        multiplier = 1;
        isMultiplier = false;
    }
    public AnimalStat(float multiplier)
    {
        this.multiplier = multiplier;
        amount = 0;
        isMultiplier = true;
    }

    public static AnimalStat operator +(AnimalStat a, AnimalStat b)
    {
        if(a.isMultiplier && !b.isMultiplier)
        {
            int output = (int)(a.multiplier * b.amount + b.amount);
            return new AnimalStat(output);
        }
        else if(b.isMultiplier && !a.isMultiplier)
        {
            int output = (int)(a.multiplier * b.amount + b.amount);
            return new AnimalStat(output);
        }
        else if(a.isMultiplier && b.isMultiplier)
        {
            return new AnimalStat(a.multiplier + b.multiplier);
        }
        else
        {
            return new AnimalStat(a.amount + b.amount);
        }
    }
}
