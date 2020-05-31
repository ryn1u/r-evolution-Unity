using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    public Vector2Vector2UnityEvent movementEvent;
    public BoolUnityEvent abilityOneEvent;//emit pass true on press, false on release
    public Camera cam;

    private Vector2 movementInput;
    private Vector2 mouseInput;

    private void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        mouseInput = cam.ScreenToWorldPoint(Input.mousePosition).AsVector2();

        movementEvent.Invoke(movementInput, mouseInput);

        if (Input.GetKeyDown(KeyCode.Q)) { abilityOneEvent.Invoke(true); }
        if (Input.GetKeyUp(KeyCode.Q)) { abilityOneEvent.Invoke(false); }
    }
}
