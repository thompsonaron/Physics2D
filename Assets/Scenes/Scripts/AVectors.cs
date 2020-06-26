using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVector2
{
    float x;
    float y;

    public AVector2()
    {
        x = .0f;
        y = .0f;
    }

    public AVector2(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    public static AVector2 operator +(AVector2 lVec, AVector2 rVec)
    {
        AVector2 vecResult = new AVector2
        {
            x = lVec.x + rVec.x,
            y = lVec.y + rVec.y
        };
        return vecResult;
    }

    public static AVector2 operator -(AVector2 lVec, AVector2 rVec)
    {
        AVector2 vecResult = new AVector2
        {
            x = lVec.x - rVec.x,
            y = lVec.y - rVec.y
        };
        return vecResult;
    }

    public static AVector2 operator *(AVector2 lVec, AVector2 rVec)
    {
        AVector2 vecResult = new AVector2
        {
            x = lVec.x * rVec.x,
            y = lVec.y * rVec.y
        };
        return vecResult;
    }

    // Scalar multiplication
    public static AVector2 operator *(AVector2 lVec, float r)
    {
        AVector2 vecResult = new AVector2
        {
            x = lVec.x * r,
            y = lVec.y * r
        };
        return vecResult;
    }

    public static bool operator ==(AVector2 lVec, AVector2 rVec)
    {
        return (Math.Round(lVec.x, 2) == Math.Round(rVec.x, 2) && (Math.Round(lVec.y, 2) == Math.Round(rVec.y, 2)));
    }

    public static bool operator !=(AVector2 lVec, AVector2 rVec)
    {
        return !(lVec == rVec);
    }

    public float Dot(AVector2 lVec, AVector2 rVec)
    {
        return lVec.x * rVec.x + lVec.y * rVec.y;
    }

    public float Magnitude(AVector2 vec2)
    {
        return Mathf.Sqrt(Dot(vec2, vec2));
    }

    public float MagnitudeSq(AVector2 vec2)
    {
        return Dot(vec2, vec2);
    }

    public void Normalize()
    {
        AVector2 aVector2 = new AVector2(x, y);
        aVector2 = aVector2 * (1.0f / Magnitude(aVector2));
        this.x = aVector2.x;
        this.y = aVector2.y;
    }

    public AVector2 Normalized(AVector2 vec2)
    {
        return vec2 * (1.0f / Magnitude(vec2));
    }

    public float Angle(AVector2 lVec, AVector2 rVec)
    {
        float m = Mathf.Sqrt(MagnitudeSq(lVec) * MagnitudeSq(rVec));
        return Mathf.Acos(Dot(lVec, rVec) / m);
    }

    public AVector2 Projection(AVector2 length, AVector2 direction)
    {
        float dot = Dot(length, direction);
        float magSq = MagnitudeSq(direction);
        return direction * (dot / magSq);
    }

    public AVector2 Perpendicular(AVector2 len, AVector2 dir)
    {
        return len - Projection(len, dir);
    }

    public AVector2 Reflection(AVector2 sourceVector, AVector2 normal)
    {
        return sourceVector - normal * (Dot(sourceVector, normal) * 2.0f);
    }
}

public class AVector3
{
    float x;
    float y;
    float z;

    public AVector3()
    {
        x = .0f;
        y = .0f;
        z = .0f;
    }

    public AVector3(float _x, float _y, float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public static AVector3 operator +(AVector3 lVec, AVector3 rVec)
    {
        AVector3 vecResult = new AVector3
        {
            x = lVec.x + rVec.x,
            y = lVec.y + rVec.y,
            z = lVec.z + rVec.z
        };
        return vecResult;
    }

    public static AVector3 operator -(AVector3 lVec, AVector3 rVec)
    {
        AVector3 vecResult = new AVector3
        {
            x = lVec.x - rVec.x,
            y = lVec.y - rVec.y,
            z = lVec.z - rVec.z
        };
        return vecResult;
    }

    // Scalar multiplication
    public static AVector3 operator *(AVector3 lVec, float r)
    {
        AVector3 vecResult = new AVector3
        {
            x = lVec.x * r,
            y = lVec.y * r,
            z = lVec.z * r
        };
        return vecResult;
    }

    public static bool operator ==(AVector3 lVec, AVector3 rVec)
    {
        return (Math.Round(lVec.x, 2) == Math.Round(rVec.x, 2) && (Math.Round(lVec.y, 2) == Math.Round(rVec.y, 2)) && (Math.Round(lVec.z, 2) == Math.Round(rVec.z, 2)));
    }

    public static bool operator !=(AVector3 lVec, AVector3 rVec)
    {
        return !(lVec == rVec);
    }

    public float Dot(AVector3 lVec, AVector3 rVec)
    {
        return lVec.x * rVec.x + lVec.y * rVec.y + lVec.z + rVec.z;
    }

    public float Magnitude(AVector3 vec3)
    {
        return Mathf.Sqrt(Dot(vec3, vec3));
    }

    public float MagnitudeSq(AVector3 vec3)
    {
        return Dot(vec3, vec3);
    }

    public void Normalize()
    {
        AVector3 aVector3 = new AVector3(x, y, z);
        aVector3 = aVector3 * (1.0f / Magnitude(aVector3));
        this.x = aVector3.x;
        this.y = aVector3.y;
        this.z = aVector3.z;
    }

    public AVector3 Normalized(AVector3 vec3)
    {
        return vec3 * (1.0f / Magnitude(vec3));
    }

    public AVector3 CrossProd(AVector3 lVec, AVector3 rVec)
    {
        AVector3 result = new AVector3();
        result.x = lVec.y * rVec.z - lVec.z * rVec.y;
        result.y = lVec.z * rVec.x - lVec.x * rVec.z;
        result.z = lVec.x * rVec.y - lVec.y * rVec.x;
        return result;
    }

    public float Angle(AVector3 lVec, AVector3 rVec)
    {
        float m = Mathf.Sqrt(MagnitudeSq(lVec) * MagnitudeSq(rVec));
        return Mathf.Acos(Dot(lVec, rVec) / m);
    }

    public AVector3 Projection(AVector3 length, AVector3 direction)
    {
        float dot = Dot(length, direction);
        float magSq = MagnitudeSq(direction);
        return direction * (dot / magSq);
    }

    public AVector3 Perpendicular(AVector3 len, AVector3 dir)
    {
        return len - Projection(len, dir);
    }

    public AVector3 Reflection(AVector3 sourceVector, AVector3 normal)
    {
        return sourceVector - normal * (Dot(sourceVector, normal) * 2.0f);
    }
}