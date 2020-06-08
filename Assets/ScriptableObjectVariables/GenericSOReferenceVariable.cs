using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class GenericSOReferenceVariable<T, SVar> where SVar : GenericScriptableObjectVariable<T>
{
    public bool UseConstant = true;
    public T ConstantValue;
    public SVar Variable;

    public T Value
    {
        get
        {
            return UseConstant ? ConstantValue : Variable.Value;
        }
        set
        {
            if(UseConstant)
            {
                ConstantValue = value;
            }
            else
            {
                Variable.Value = value;
            }
        }
    }
}
