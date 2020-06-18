using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Here are declared sub-classes of generic UnityEvents.
//These declarations are required to allow serialization and editing in the Unity Inspector.

[System.Serializable]
public class Vector2Vector2UnityEvent : UnityEvent<Vector2, Vector2> { }
[System.Serializable]
public class Vector2UnityEvent : UnityEvent<Vector2> { }
[System.Serializable]
public class BoolUnityEvent : UnityEvent<bool> { }
[System.Serializable]
public class GameObjectUnityEvent : UnityEvent<GameObject> { }
[System.Serializable]
public class Collider2DUnityEvent : UnityEvent<Collider2D> { }
[System.Serializable]
public class ProjectileUnityEvent : UnityEvent<Projectile> { }
