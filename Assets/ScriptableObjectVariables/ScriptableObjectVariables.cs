using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float Variable", menuName = "ScriptableObjects/Variables/Float", order = 5)]
public class FloatVariable : GenericScriptableObjectVariable<float>
{

}
[CreateAssetMenu(fileName = "Int Variable", menuName = "ScriptableObjects/Variables/Int", order = 5)]
public class IntVariable : GenericScriptableObjectVariable<int>
{

}
[CreateAssetMenu(fileName = "Bool Variable", menuName = "ScriptableObjects/Variables/Bool", order = 5)]
public class BoolVariable : GenericScriptableObjectVariable<bool>
{

}

