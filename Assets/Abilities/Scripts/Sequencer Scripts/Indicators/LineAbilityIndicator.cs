using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(SceneEntity))]
public class LineAbilityIndicator : AbilityIndicator
{
    public Vector2UnityEvent directionEv;
    public Vector2Vector2UnityEvent posAndDirEv;

    public LineRenderer lineRenderer;
    public SceneEntity sceneEntity;
    public float lineLength;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        sceneEntity = GetComponent<SceneEntity>();
        lineRenderer.enabled = false;
    }
    private void Update()
    {
        Vector2 pos1 = sceneEntity.myRigidbody.position;
        float rotation = sceneEntity.myRigidbody.rotation + 90f;
        lineRenderer.SetPosition(0, pos1);
        Vector2 pos2 = new Vector2(pos1.x + lineLength * Mathf.Cos(rotation * Mathf.Deg2Rad), pos1.y + lineLength * Mathf.Sin(rotation * Mathf.Deg2Rad));
        lineRenderer.SetPosition(1, pos2);
    }

    public override void HideIndicator()
    {
        lineRenderer.enabled = false;
        sceneEntity.TakeAim(false);
    }

    public override void ShowIndicator()
    {
        lineRenderer.enabled = true;
        sceneEntity.TakeAim(true);
    }

    public override void TriggerEvents()
    {
        Vector2 dir = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).normalized;
        directionEv.Invoke(dir);
        posAndDirEv.Invoke(lineRenderer.GetPosition(0), dir);
    }
}
