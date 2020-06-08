using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GenericScriptableObjectVariable<T> : ScriptableObject
{
    public T Value;
}
