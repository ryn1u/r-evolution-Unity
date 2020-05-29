using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Vector2UnityEvent : UnityEvent<Vector2>
{

}

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(SceneEntity))]
public class SequencerLineIndicator : MonoBehaviour
{
    public Vector2UnityEvent directionEvent;
    public LineRenderer lineRenderer;
    public SceneEntity sceneEntity;
    public float lineLength;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        sceneEntity = GetComponent<SceneEntity>();
        lineRenderer.enabled = false;
    }

    public void ShowLine()
    {
        lineRenderer.enabled = true;
    }
    public Vector2 GetDirAndHide()
    {
        lineRenderer.enabled = false;
        Vector2 dir = (lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1)).normalized;
        directionEvent.Invoke(dir);
        return dir;
    }
    public void HideLine()
    {
        lineRenderer.enabled = false;
        directionEvent.Invoke((lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1)).normalized);
    }
    void Update()
    {
        MoveLine();
    }
    private void MoveLine()
    {
        Vector2 pos1 = sceneEntity.myRigidbody.position;
        float rotation = sceneEntity.myRigidbody.rotation + 90f;
        lineRenderer.SetPosition(0, pos1);
        Vector2 pos2 = new Vector2(pos1.x + lineLength * Mathf.Cos(rotation * Mathf.Deg2Rad), pos1.y + lineLength * Mathf.Sin(rotation * Mathf.Deg2Rad));
        lineRenderer.SetPosition(1, pos2);
    }
}
