using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : SceneEntity
{
    public Collider2DUnityEvent hitEvent;
    public ProjectileUnityEvent missEvent;
    public float range;
    private float currRange;
    private Vector2 prevPos;
    public void SetDirections(Vector2 dir)
    {
        movementDirection = dir.normalized;
        lookingDirection = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg - 90f;
    }
    public void SetEvents(Collider2DUnityEvent hitEv, ProjectileUnityEvent missEv)
    {
        hitEvent = hitEv;
        missEvent = missEv;
    }
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
