using System;
using UnityEngine;

public class CheckBounds : MonoBehaviour
{
    /// <summary>
    /// Fix the object's y coordinate from an idle drop.
    /// </summary>
    /// <param name="tetromino">
    /// The object that must be adjusted.
    /// </param>
    public static void GameFloor(GameObject tetromino)
    {
        Vector3 objectRotation = tetromino.transform.localEulerAngles;
        
        switch(tetromino.name)
        {
            case "ITetromino(Clone)":
                {
                    AdjustGameFloorBounds.ITetromino(objectRotation, tetromino);
                }

                break;

            case "JTetromino(Clone)":
                {
                    AdjustGameFloorBounds.JTetromino(objectRotation, tetromino);
                }

                break;

            case "LTetromino(Clone)":
                {
                    AdjustGameFloorBounds.LTetromino(objectRotation, tetromino);
                }

                break;
            
            case "OTetromino(Clone)":
                {
                    AdjustGameFloorBounds.OTetromino(objectRotation, tetromino);
                }

                break;
            
            case "STetromino(Clone)":
                {
                    AdjustGameFloorBounds.STetromino(objectRotation, tetromino);
                }

                break;

            case "TTetromino(Clone)":
                {
                    AdjustGameFloorBounds.TTetromino(objectRotation, tetromino);
                }

                break;

            case "ZTetromino(Clone)":
                {
                    AdjustGameFloorBounds.ZTetromino(objectRotation, tetromino);
                }

                break;
        }
    }

    /// <summary>
    /// Fix the object's x coordinate from being out of the left bound.
    /// </summary>
    /// <param name="tetromino">
    /// The object that must be adjusted.
    /// </param>
    public static void Left(GameObject tetromino)
    {
        Vector3 objectRotation = tetromino.transform.localEulerAngles;

        switch(tetromino.name)
        {
            case "ITetromino(Clone)":
                {
                    AdjustLeftBounds.ITetromino(objectRotation, tetromino);
                }

                break;
            
            case "JTetromino(Clone)":
                {
                    AdjustLeftBounds.JTetromino(objectRotation, tetromino);
                }

                break;
            
            case "LTetromino(Clone)":
                {
                    AdjustLeftBounds.LTetromino(objectRotation, tetromino);
                }

                break;
            
            case "OTetromino(Clone)":
                {
                    AdjustLeftBounds.OTetromino(objectRotation, tetromino);
                }

                break;
            
            case "STetromino(Clone)":
                {
                    AdjustLeftBounds.STetromino(objectRotation, tetromino);
                }
                
                break;
            
            case "TTetromino(Clone)":
                {
                    AdjustLeftBounds.TTetromino(objectRotation, tetromino);
                }

                break;
            
            case "ZTetromino(Clone)":
                {
                    AdjustLeftBounds.ZTetromino(objectRotation, tetromino);
                }

                break;
        }
    }

    /// <summary>
    /// Fix the object's z coordinate from being out of the right bound.
    /// </summary>
    /// <param name="tetromino">
    /// The object that must be adjusted.
    /// </param>
    public static void Right(GameObject tetromino)
    {
        Vector3 objectRotation = tetromino.transform.localEulerAngles;
        
        switch(tetromino.name)
        {
            case "ITetromino(Clone)":
                {
                    AdjustRightBounds.ITetromino(objectRotation, tetromino);
                }
                
                break;
            
            case "JTetromino(Clone)":
                {
                    AdjustRightBounds.JTetromino(objectRotation, tetromino);
                }

                break;
            
            case "LTetromino(Clone)":
                {
                    AdjustRightBounds.LTetromino(objectRotation, tetromino);
                }

                break;
            
            case "OTetromino(Clone)":
                {
                    AdjustRightBounds.OTetromino(objectRotation, tetromino);
                }

                break;
            
            case "STetromino(Clone)":
                {
                    AdjustRightBounds.STetromino(objectRotation, tetromino);
                }

                break;
            
            case "TTetromino(Clone)":
                {
                    AdjustRightBounds.TTetromino(objectRotation, tetromino);
                }

                break;
            
            case "ZTetromino(Clone)":
                {
                    AdjustRightBounds.ZTetromino(objectRotation, tetromino);
                }
                break;
        }
    }
}