using System;
using UnityEngine;

public class AdjustLeftBounds : MonoBehaviour
{
    /// <summary>
    /// Fix the ITetromino(Clone)'s x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void ITetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(0, 180, 180))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(90, 0, 0))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 0, 0))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(270, 0, 0))
        {
            if(tetromino.transform.position.z > 5f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
    }

    /// <summary>
    /// Fix the JTetromino(Clone)'s x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void JTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(90, 180, 0))
        {
            if(tetromino.transform.position.z > 5f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 0, 180))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(270, 180, 0))
        {
            if(tetromino.transform.position.z > 2f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 180, 0))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
    }

    /// <summary>
    /// Fix the LTetromino(Clone)'s x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void LTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(0, 180, 180))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(90, 0, 0))
        {
            if(tetromino.transform.position.z > 2f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 0, 0))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(270, 0, 0))
        {
            if(tetromino.transform.position.z > 5f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
    }

    /// <summary>
    /// Fix the OTetromino(Clone)'s x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void OTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(0, 180, 180))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(90, 0, 0))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 0, 0))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(270, 0, 0))
        {
            if(tetromino.transform.position.z > 5f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
    }

    /// <summary>
    /// Fix the STetromino(Clone)'s x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void STetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(0, 180, 180))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
        
        if(objectRotation == new Vector3(90, 0, 0))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 0, 0))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(270, 0, 0))
        {
            if(tetromino.transform.position.z > 5f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
    }

    /// <summary>
    /// Fix the TTetromino(Clone)'s x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void TTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(0, 180, 180))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(90, 0, 0))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 0, 0))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(270, 0, 0))
        {
            if(tetromino.transform.position.z > 5f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
    }

    /// <summary>
    /// Fix the ZTetromino(Clone)'s x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="objectRotation"> The object's inspector rotation represented by Vector3. </param>
    /// <param name="tetromino"> The object that must be adjusted. </param>
    public static void ZTetromino(Vector3 objectRotation, GameObject tetromino)
    {
        if(objectRotation == new Vector3(0, 180, 0))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(90, 180, 0))
        {
            if(tetromino.transform.position.z > 5f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(0, 0, 180))
        {
            if(tetromino.transform.position.z > 4f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }

        if(objectRotation == new Vector3(270, 180, 0))
        {
            if(tetromino.transform.position.z > 3f)
            {
                tetromino.transform.position -= Vector3.forward;
            }
        }
    }

}