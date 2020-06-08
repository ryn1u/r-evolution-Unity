using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloatReference : GenericSOReferenceVariable<float, FloatVariable> { }

[Serializable]
public class IntReference : GenericSOReferenceVariable<int, IntVariable> { }

[Serializable]
public class BoolReference : GenericSOReferenceVariable<bool, BoolVariable> { }