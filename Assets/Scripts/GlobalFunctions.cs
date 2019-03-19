using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFunctions : MonoBehaviour
{
    public static Vector2 FaceDirectionToVector2(int faceDirection)
    {
        switch (faceDirection)
        {
            case 1:
                return Vector2.up;
            case 2:
                return Vector2.right;
            case 3:
                return Vector2.down;
            case 4:
                return Vector2.left;
            default:
                return Vector2.zero;
        }
    }
}
