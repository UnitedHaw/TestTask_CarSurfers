using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Forward,
    Back,
    Top,
    Bottom,
    Left,
    Right,
}

public static class VectorExtension
{
    public static Vector3 GetBorderPosition(this Transform transform, Side side)
    {
        switch (side)
        {
            case Side.Forward:
                return transform.position + new Vector3(0, 0, transform.localScale.z / 2);
            case Side.Back:
                return transform.position - new Vector3(0, 0, transform.localScale.z / 2);
            case Side.Top:
                return transform.position + new Vector3(0, transform.localScale.y / 2, 0);
            case Side.Bottom:
                return transform.position - new Vector3(0, transform.localScale.y / 2, 0);
            case Side.Right:
                return transform.position + new Vector3(transform.localScale.x / 2, 0, 0);
            case Side.Left:
                return transform.position - new Vector3(transform.localScale.x / 2, 0, 0);
            default:
                return Vector3.zero;
        }
    }

    public static Vector3 GetBorderPosition(this Transform transform)
    {
        return transform.forward + new Vector3(0, 0, transform.localScale.z);
    }
}
