using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseEntityController : MonoBehaviour
{
    public Vector2Vector2UnityEvent movementEvent;
    public BoolUnityEvent abilityOneEvent;//emit pass true on press, false on release
}
