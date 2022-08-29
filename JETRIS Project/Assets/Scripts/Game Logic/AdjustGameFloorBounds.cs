using System;
using UnityEngine;

public class AdjustGameFloorBounds : MonoBehaviour
{
    /// <summary>
    /// Fix the ITetromino(Clone)'s y coordinate from an idle drop.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void ITetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(0, 180, 180))
        {
            tetromino.transform.position += Vector3.up;
        }
    }

    /// <summary>
    /// Fix the JTetromino(Clone)'s y coordinate from an idle drop.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void JTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(90, 0, 180) || objectRotation == new Vector3(270, 0, 180))
        {
            tetromino.transform.position += Vector3.up;
        }
    }

    /// <summary>
    /// Fix the LTetromino(Clone)'s y coordinate from an idle drop.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void LTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(90, 0, 0) || objectRotation == new Vector3(270, 0, 0))
        {
            tetromino.transform.position += Vector3.up;   
        }
    }

    /// <summary>
    /// Fix the OTetromino(Clone)'s y coordinate from an idle drop.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void OTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(90, 0, 0) || objectRotation == new Vector3(270, 0, 0))
        {
            tetromino.transform.position += Vector3.up;
        }
    }

    /// <summary>
    /// Fix the STetromino(Clone)'s y coordinate from an idle drop.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void STetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(90, 0, 0))
        {
            tetromino.transform.position += Vector3.up;
        }
    }

    /// <summary>
    /// Fix the TTetromino(Clone)'s y coordinate from an idle drop.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void TTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(90, 0, 0))
        {
            tetromino.transform.position += Vector3.up;
        }
    }

    /// <summary>
    /// Fix the ZTetromino(Clone)'s y coordinate from an idle drop.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void ZTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(90, 180, 0))
        {
            tetromino.transform.position += Vector3.up;
        }
    }
}