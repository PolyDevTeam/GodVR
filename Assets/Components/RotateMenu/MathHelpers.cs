using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathHelpers
{
    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
    public static Vector2 RadianToVector2(float radian, float length)
    {
        return RadianToVector2(radian) * length;
    }
    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    public static Vector2 DegreeToVector2(float degree, float length)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad) * length;
    }

    public static float Distance2Points(Vector2 p1, Vector2 p2)
    {
        float pow1 = Mathf.Pow((p2.x - p1.x), 2);
        float pow2 = Mathf.Pow((p2.y - p1.y), 2);
        return ( Mathf.Sqrt( pow1 + pow2 ) );
    }
}