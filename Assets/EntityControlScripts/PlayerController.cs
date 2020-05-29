using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityMovementEvent : UnityEvent<Vector2, Vector2>
{

}
public class PlayerController : MonoBehaviour
{
    public UnityMovementEvent movementEvent;
    public UnityEvent aimEvent;
    public UnityEvent getAim;
    public Camera cam;

    private Vector2 movementInput;
    private Vector2 mouseInput;

    private void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        mouseInput = cam.ScreenToWorldPoint(Input.mousePosition).AsVector2();

        movementEvent.Invoke(movementInput, mouseInput);

        if (Input.GetKeyDown(KeyCode.Q)) { aimEvent.Invoke(); }
        if (Input.GetKeyDown(KeyCode.E)) { getAim.Invoke(); }
    }
}
