using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The kiinematic entity used for control the player avatar in game space.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class SceneEntity : MonoBehaviour
{
    //Rigidbody is used by UnityEngine for Physics Movement and Collisions.
    public Rigidbody2D myRigidbody;

    //Vector used for calculating in which direction the body is going to move. 
    //This vector is supposed to normalized to 1 and a multitude of 45deg.
    protected Vector2 movementDirection;

    //The rotation of player avatar. Unless the player is aiming his ability this value is alligned with movementDirection.
    protected float lookingDirection;

    //This value is used to controll how far player will move.
    [SerializeField]
    protected float speed;
    protected bool overrideController = false;
    protected bool aiming = false;



    public Vector2 myMovement { get { return movementDirection; } }
    public float mySpeed { get { return speed; } }
    public float myRotation { get { return lookingDirection; } }


    /// <summary>Trigger aim mode. Method used mainly by UnityEvents to controll the Entity butcan also be used by other scripts.</summary>
    public void TakeAim()
    {
        aiming = !aiming;
    }

    /// <summary>Trigger aim mode. Method used mainly by UnityEvents to controll the Entity butcan also be used by other scripts.</summary>
    public void TakeAim(bool aim)
    {
        aiming = aim;
    }

    /// <summary>Trigger controll ovveride. Method used mainly by UnityEvents to controll the Entity but can also be used by other scripts.
    /// During override movementDirection Vector and lookingDirection are blocked from being changed inside of SetDirections method,
    /// which effectively blocks  EntityControllers(be it AI or Player Input) from sending input and allows for other sources of control. 
    /// Use SetDirectionsOverriden to controll the Entity in override.
    /// </summary>
    public void TriggerControllOverride(bool ctrl)
    {
        overrideController = ctrl;
    }

    /// <summary>
    /// Used by UnityEvents from EntityControllers to move and rotate this Entity.
    /// </summary>
    /// <param name="moveDir">Direction in which the player will move. This method normailzes the Vector.</param>
    /// <param name="cntrlPos">The position towards which the Entity will rotate if aiming.</param>
    public void SetDirections(Vector2 moveDir, Vector2 cntrlPos)
    {
        //This line effectively blocks the controller if in override.
        if (overrideController) return; 
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

    /// <summary>
    /// Used by other scripts than AI or PLayer EntityControllers to override the movement and rotation of Entity.
    /// Keep in mind that this method just moves to Entity to given position, so it doesn't normilze it, multiply by speed and frame time!
    /// </summary>
    public void SetDirectionsOverriden(Vector2 moveDir, float rotation)
    {
        if (!overrideController) return; //Blocks from overriding controll if it's not supposed to.
        movementDirection = moveDir;
        lookingDirection = rotation;
    }

    protected virtual void FixedUpdate()
    {
        //To collisions Unity doesn't use velocity control, but positional movement. I might be wrong, but t least that's what works here...
        myRigidbody.MovePosition(myRigidbody.position + movementDirection * speed * Time.fixedDeltaTime);
        myRigidbody.rotation = lookingDirection;
    }
}