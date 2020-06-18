using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Projectile is asub-class of SceneEntity used for abilities as a projectile. It is usually spawned and despawned using ObjectPools.
/// </summary>
public class Projectile : SceneEntity
{
    //Two events that invoke methods if projectile hit or misses it's shot. 
    //These events can invoke things like explosions, demage dealing and so on...
    //They are invoked by this Projectile but we use '=' assignment with SetEvents method, so that we can do it in Unity Inspector.
    private Collider2DUnityEvent hitEvent;
    private ProjectileUnityEvent missEvent;

    //These 3 variables are used to claculate how far projectile will travel and far it has traveled so far.
    public float range;
    private float currRange;
    private Vector2 prevPos;

    public void SetDirections(Vector2 dir)
    {
        movementDirection = dir.normalized;
        lookingDirection = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg - 90f;
    }

    /// <summary>
    /// Set events for what happens on hit or miss.
    /// </summary>
    /// <param name="hitEv">Event for Projectile hit with Colider2D for hit target.</param>
    /// <param name="missEv">Event for Projectile miss that usually passes</param>
    public void SetEvents(Collider2DUnityEvent hitEv, ProjectileUnityEvent missEv)
    {
        hitEvent = hitEv;
        missEvent = missEv;
    }

    /// <summary>
    /// Spawn projectile and activate at given position.
    /// </summary>
    public void Spawn(Vector2 position)
    {
        myRigidbody.position = position;
        prevPos = position;
        currRange = range;
        gameObject.SetActive(true);
    }
    public void Spawn(Vector2 position, Vector2 direction)
    {
        gameObject.transform.position = position;
        SetDirections(direction);
        gameObject.transform.rotation = Quaternion.AngleAxis(lookingDirection, Vector3.forward);
        prevPos = position;
        currRange = range;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitEvent.Invoke(collision);
    } 
    protected override void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + movementDirection * speed * Time.fixedDeltaTime);
        myRigidbody.rotation = lookingDirection;

        currRange -= (prevPos - myRigidbody.position).sqrMagnitude;
        prevPos = myRigidbody.position;
        if(currRange <= 0)
        {
            missEvent.Invoke(this);
        }
    }
}
