using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class LineDelay : MonoBehaviour
{
    /// <summary>
    /// Calculate the object's distance between itself and the object below it depending on the object name.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <returns> The object's distance between itself and the object below it. </returns>
    public static float Calculate(GameObject tetromino)
    {
        Vector3 objectGlobalPosition = GetPointOfOrigin(tetromino);

        switch(tetromino.name)
        {
            case "ITetromino(Clone)":
                return FindMinRestingHeightITetromino(tetromino, objectGlobalPosition);

            case "JTetromino(Clone)":
                return FindMinRestingHeightJTetromino(tetromino, objectGlobalPosition);

            case "LTetromino(Clone)":
                return FindMinRestingHeightLTetromino(tetromino, objectGlobalPosition);

            case "OTetromino(Clone)":
                return FindMinRestingHeightOTetromino(tetromino, objectGlobalPosition);

            case "STetromino(Clone)":
                return FindMinRestingHeightSTetromino(tetromino, objectGlobalPosition);

            case "TTetromino(Clone)":
                return FindMinRestingHeightTTetromino(tetromino, objectGlobalPosition);

            case "ZTetromino(Clone)":
                return FindMinRestingHeightZTetromino(tetromino, objectGlobalPosition);
        }

        return objectGlobalPosition.y;
    }

    /// <summary>
    /// Get the object's point of origin based off of the vertex most closely related to it.
    /// This function is needed due to mesh slicing -- which mesh colliders are involved but cannot cooperate with softbody physics.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <returns> The vertex's Vector3 position most closely related to the object's origin. </returns>
    private static Vector3 GetPointOfOrigin(GameObject tetromino)
    {
        GameObject objectLocalPosition = null;

        if(tetromino.name == "ITetromino(Clone)" || tetromino.name == "OTetromino(Clone)" || tetromino.name == "TTetromino(Clone)")
        {
            objectLocalPosition = tetromino.transform.GetChild(0).GetChild(14).gameObject;
        } else if (tetromino.name == "JTetromino(Clone)" || tetromino.name == "ZTetromino(Clone)")
        {
            objectLocalPosition = tetromino.transform.GetChild(0).GetChild(17).gameObject;
        } else
        {
            objectLocalPosition = tetromino.transform.GetChild(0).GetChild(16).gameObject;
        }

        Vector3 objectGlobalPosition = tetromino.transform.position;
        objectGlobalPosition.y = (float)Math.Round(objectLocalPosition.transform.position.y);

        return objectGlobalPosition;
    }

    /// <summary>
    /// Calculate the ITetromino(Clone)'s distance between itself and the object below it depending on its rotation.
    /// This is done by checking each unit of the object and retrieving the minimum distance obtained.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <param name="objectGlobalPosition"> The vertex's Vector3 position most closely related to the object's original position. </param>
    /// <returns> The ITetromino(Clone)'s maximum distance between itself and the object below it. </returns>
    private static float FindMinRestingHeightITetromino(GameObject tetromino, Vector3 objectGlobalPosition)
    {
        List<float> detectedLandingHeights = new List<float>();

        if(tetromino.transform.localEulerAngles == new Vector3(0, 0, 0))
        {
                detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 1.5f)));
                detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 0.5f)));
                detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -0.5f)));
                detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(270, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 180, 180))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(90, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, 0.5f)));
        }

        return MathF.Ceiling(detectedLandingHeights.AsQueryable().Min());
    }

    /// <summary>
    /// Calculate the JTetromino(Clone)'s distance between itself and the object below it depending on its rotation.
    /// This is done by checking each unit of the object and retrieving the minimum distance obtained.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <param name="objectGlobalPosition"> The vertex's Vector3 position most closely related to the object's original position. </param>
    /// <returns> The JTetromino(Clone)'s maximum distance between itself and the object below it. </returns>
    private static float FindMinRestingHeightJTetromino(GameObject tetromino, Vector3 objectGlobalPosition)
    {
        List<float> detectedLandingHeights = new List<float>();

        if(tetromino.transform.localEulerAngles == new Vector3(90, 180, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, -1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, -2.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 0, 180))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -3f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(270, 180, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 0f, 2.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 0f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, 0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 180, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 0f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 0f, -0.5f)));
        }

        return MathF.Ceiling(detectedLandingHeights.AsQueryable().Min());
    }

    /// <summary>
    /// Calculate the LTetromino(Clone)'s distance between itself and the object below it depending on its rotation.
    /// This is done by checking each unit of the object and retrieving the minimum distance obtained.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <param name="objectGlobalPosition"> The vertex's Vector3 position most closely related to the object's original position. </param>
    /// <returns> The LTetromino(Clone)'s maximum distance between itself and the object below it. </returns>
    private static float FindMinRestingHeightLTetromino(GameObject tetromino, Vector3 objectGlobalPosition)
    {
        List<float> detectedLandingHeights = new List<float>();

        if(tetromino.transform.localEulerAngles == new Vector3(90, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 2.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(270, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -2.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 180, 180))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -3f, -0.5f)));
        }

        return MathF.Ceiling(detectedLandingHeights.AsQueryable().Min());
    }

    /// <summary>
    /// Calculate the OTetromino(Clone)'s distance between itself and the object below it depending on its rotation.
    /// This is done by checking each unit of the object and retrieving the minimum distance obtained.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <param name="objectGlobalPosition"> The vertex's Vector3 position most closely related to the object's original position. </param>
    /// <returns> The OTetromino(Clone)'s maximum distance between itself and the object below it. </returns>
    private static float FindMinRestingHeightOTetromino(GameObject tetromino, Vector3 objectGlobalPosition)
    {
        List<float> detectedLandingHeights = new List<float>();

        if(tetromino.transform.localEulerAngles == new Vector3(0, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(270, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 180, 180))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(90, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 0.5f)));
        }

        return MathF.Ceiling(detectedLandingHeights.AsQueryable().Min());
    }

    /// <summary>
    /// Calculate the STetromino(Clone)'s distance between itself and the object below it depending on its rotation.
    /// This is done by checking each unit of the object and retrieving the minimum distance obtained.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <param name="objectGlobalPosition"> The vertex's Vector3 position most closely related to the object's original position. </param>
    /// <returns> The STetromino(Clone)'s maximum distance between itself and the object below it. </returns>
    private static float FindMinRestingHeightSTetromino(GameObject tetromino, Vector3 objectGlobalPosition)
    {
        List<float> detectedLandingHeights = new List<float>();

        if(tetromino.transform.localEulerAngles == new Vector3(0, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 1f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(270, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 180, 180))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(90, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 0.5f)));
        }
        
        return MathF.Ceiling(detectedLandingHeights.AsQueryable().Min());
    }

    /// <summary>
    /// Calculate the TTetromino(Clone)'s distance between itself and the object below it depending on its rotation.
    /// This is done by checking each unit of the object and retrieving the minimum distance obtained.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <param name="objectGlobalPosition"> The vertex's Vector3 position most closely related to the object's original position. </param>
    /// <returns> The TTetromino(Clone)'s maximum distance between itself and the object below it. </returns>
    private static float FindMinRestingHeightTTetromino(GameObject tetromino, Vector3 objectGlobalPosition)
    {
        List<float> detectedLandingHeights = new List<float>();

        if(tetromino.transform.localEulerAngles == new Vector3(0, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(270, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 180, 180))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -2f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(90, 0, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, 0f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(0.5f, -1f, 0.5f)));
        }

        return MathF.Ceiling(detectedLandingHeights.AsQueryable().Min());
    }

    /// <summary>
    /// Calculate the ZTetromino(Clone)'s distance between itself and the object below it depending on its rotation.
    /// This is done by checking each unit of the object and retrieving the minimum distance obtained.
    /// </summary>
    /// <param name="tetromino"> The object to calculate. </param>
    /// <param name="objectGlobalPosition"> The vertex's Vector3 position most closely related to the object's original position. </param>
    /// <returns> The ZTetromino(Clone)'s maximum distance between itself and the object below it. </returns>
    private static float FindMinRestingHeightZTetromino(GameObject tetromino, Vector3 objectGlobalPosition)
    {
        List<float> detectedLandingHeights = new List<float>();

        if(tetromino.transform.localEulerAngles == new Vector3(0, 180, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 1f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 0f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 0f, -0.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(90, 180, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, 0f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(0, 0, 180))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, 0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -2f, -0.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -2f, -1.5f)));
        }

        if(tetromino.transform.localEulerAngles == new Vector3(270, 180, 0))
        {
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -2f, 1.5f)));
            detectedLandingHeights.Add(CheckHeightBelow(objectGlobalPosition + new Vector3(-0.5f, -1f, 0.5f)));
        }

        return MathF.Ceiling(detectedLandingHeights.AsQueryable().Min());
    }

    /// <summary>
    /// Calculate the object's distance between itself and the object below it at one point.
    /// </summary>
    /// <param name="originPoint"> The point at which the raycast ray will originate from. </param>
    /// <returns> The object's distance between itself and the object below it at one point. </returns>
    private static float CheckHeightBelow(Vector3 originPoint)
    {
        List<float> detectedLandingHeights = new List<float>();

        Ray laserPoint = new Ray(originPoint, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(laserPoint, out hit))
        {
            return hit.distance;
        }
        
        return originPoint.y;
    }
}