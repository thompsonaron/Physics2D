using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat2
{
    float _11, _12,
          _21, _22;

    void Transpose(float[] srcMat, float[] dstMat, int srcRows, int srcCols)
    {
        for (int i = 0; i < srcRows * srcCols; i++)
        {
            int row = i / srcRows;
            int col = i % srcRows;
            dstMat[i] = srcMat[srcCols * col + row];
        }
    }


    Mat2 Transpose(Mat2 matrix)
    {
        Mat2 result = new Mat2();
        Transpose(matrix.AsArray(), result.AsArray(), 2, 2);
        return result;
    }

    float[] AsArray()
    {
        return new float[] {
            _11,
            _12,
            _21,
            _22
        };
    }
}


public class Mat3
{
    float _11, _12, _13,
          _21, _22, _23,
          _31, _32, _33;

}

public class Mat4
{
    float _11, _12, _13, _14,
          _21, _22, _23, _24,
          _31, _32, _33, _34,
          _41, _42, _43, _44;

}
