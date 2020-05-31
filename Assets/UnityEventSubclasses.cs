﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Vector2Vector2UnityEvent : UnityEvent<Vector2, Vector2> { }
[System.Serializable]
public class Vector2UnityEvent : UnityEvent<Vector2> { }
[System.Serializable]
public class BoolUnityEvent : UnityEvent<bool> { }
[System.Serializable]
public class GameObjectUnityEvent : UnityEvent<GameObject> { }