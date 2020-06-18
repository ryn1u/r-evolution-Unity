using UnityEngine;

/// <summary> Convert Vector3 to Vector2 with x and y values only. </summary>
public static class Vector3Extension
{
    public static Vector2 AsVector2(this Vector3 _v)
    {
        return new Vector2(_v.x, _v.y);
    }
}

/// <summary>
/// Convert Vector2 to Vector3 with z equalto 0.
/// </summary>
public static class Vector2Extension
{
    public static Vector3 AsVector3(this Vector2 _v)
    {
        return new Vector3(_v.x, _v.y);
    }
}