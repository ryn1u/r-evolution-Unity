using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SceneEntity : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Vector2 movementDirection;
    public float lookingDirection;
    public float speed;

    private bool aiming = false;
    public void TakeAim()
    {
        aiming = !aiming;
    }
    public void SetDirections(Vector2 moveDir, Vector2 cntrlPos)
    {
        movementDirection = (moveDir.x != 0 && moveDir.y != 0) ? moveDir * 0.707f : moveDir;

        float lookDir = Mathf.Atan2(cntrlPos.y - myRigidbody.position.y, cntrlPos.x - myRigidbody.position.x) * Mathf.Rad2Deg - 90f;
        if(aiming)
        {
            lookingDirection = lookDir;
        }
        else
        {
            lookingDirection = moveDir != Vector2.zero ? Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg - 90f : lookingDirection;
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + movementDirection * speed * Time.fixedDeltaTime);
        myRigidbody.rotation = lookingDirection;
    }
}
