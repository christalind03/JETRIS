using UnityEngine;
using System.Collections.Generic;

public class LineClearingManager : MonoBehaviour
{
    private static int ROW_SIZE = 20;
    private static int COLUMN_SIZE = 10;

    private static Vector3 STARTING_RAYCAST_POSITION = new Vector3(-0.5f, 0.5f, 4.5f);

    /// <summary>
    /// Play collision and line cleared sound effects after cutting the line.
    /// Clear the line depending on its given row number.
    /// </summary>
    /// <param name="row"> The row to be cleared. </param>
    public void ClearLines(int row)
    {
        List<GameObject> objectsInLine = DetectObjectsInLine(row);

        CutLine(row, objectsInLine);
        FindObjectOfType<AudioManager>().Play("Collision Sound Effect");
        FindObjectOfType<AudioManager>().Play("Line Cleared Sound Effect");
        ClearLine(row, objectsInLine);
        UpdateTimesSliced(objectsInLine);

        LevelManager._totalLinesCleared++;
    }

    /// <summary>
    /// Scan the objects in a given row using raycasting.
    /// Store the scanned objects in a list.
    /// </summary>
    /// <param name="row"> The row to be scanned. </param>
    /// <returns> A list of all the objects within a row. </returns>
    private List<GameObject> DetectObjectsInLine(int row)
    {
        List<GameObject> objectsInLine = new List<GameObject>();

        Ray laserPoint = new Ray(STARTING_RAYCAST_POSITION + new Vector3(0, ROW_SIZE - row, 0), transform.right);
        RaycastHit hit;

        for(int column = 0; column < COLUMN_SIZE; column++)
        {   
            if(Physics.Raycast(laserPoint, out hit, 1) && !IsInList(objectsInLine, hit.collider.transform.gameObject))
            {
                objectsInLine.Add(hit.collider.transform.gameObject);
            }

            laserPoint.origin += Vector3.back;
        }

        return objectsInLine;
    }

    /// <summary>
    /// Check to see if an object already exists in a list.
    /// </summary>
    /// <param name="iterator"> The list to run through. </param>
    /// <param name="gameObjectToFind"> The object to find within the list. </param>
    /// <returns> True if the object is inside the list; otherwise, false. </returns>
    private bool IsInList(List<GameObject> iterator, GameObject gameObjectToFind)
    {
        foreach(GameObject gameObject in iterator)
        {
            if(gameObject == gameObjectToFind)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Cut the top and bottom parts of the objects in the given row.
    /// </summary>
    /// <param name="row"> The row number. </param>
    /// <param name="objectsInLine"> The objects to be cut. </param>
    private void CutLine(int row, List<GameObject> objectsInLine)
    {
        switch(row)
        {
            case 1:
                CutLine(objectsInLine, 20.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 18.999f);
                break;

            case 2:
                CutLine(objectsInLine, 19.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 17.999f);
                break;

            case 3:
                CutLine(objectsInLine, 18.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 16.999f);
                break;

            case 4:
                CutLine(objectsInLine, 17.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 15.999f);
                break;

            case 5:
                CutLine(objectsInLine, 16.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 14.999f);
                break;

            case 6:
                CutLine(objectsInLine, 15.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 13.999f);
                break;

            case 7:
                CutLine(objectsInLine, 14.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 12.999f);
                break;

            case 8:
                CutLine(objectsInLine, 13.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 11.999f);
                break;

            case 9:
                CutLine(objectsInLine, 12.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 10.999f);
                break;

            case 10:
                CutLine(objectsInLine, 11.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 9.999f);
                break;

            case 11:
                CutLine(objectsInLine, 10.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 8.999f);
                break;

            case 12:
                CutLine(objectsInLine, 9.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 7.999f);
                break;

            case 13:
                CutLine(objectsInLine, 8.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 6.999f);
                break;

            case 14:
                CutLine(objectsInLine, 7.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 5.999f);
                break;

            case 15:
                CutLine(objectsInLine, 6.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 4.999f);
                break;

            case 16:
                CutLine(objectsInLine, 5.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 3.999f);
                break;

            case 17:
                CutLine(objectsInLine, 4.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 2.999f);
                break;

            case 18:
                CutLine(objectsInLine, 3.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 1.999f);
                break;

            case 19:
                CutLine(objectsInLine, 2.001f);
                objectsInLine = DetectObjectsInLine(row);
                CutLine(objectsInLine, 0.999f);
                break;

            case 20:
                CutLine(objectsInLine, 1.001f);
                break;
        }
    }

    /// <summary>
    /// Use mesh slicing to cut the objects into smaller fragments.
    /// </summary>
    /// <param name="objectsInLine"> The objects to be cut. </param>
    /// <param name="heightToCut"> The height at which to cut objects. </param>
    private void CutLine(List<GameObject> objectsInLine, float heightToCut)
    {
        foreach(GameObject Object in objectsInLine)
        {
            var slicer = Object.GetComponent<Slice>();
            var sliceNormal = Vector3.up;
            var sliceOrigin = new Vector3(Object.transform.position.x, heightToCut, Object.transform.position.z); 

            slicer.ComputeSlice(sliceNormal, sliceOrigin);
        }
    }

    /// <summary>
    /// Delete and destroy the objects within the given row and list.
    /// After the line is cleared, update the score count.
    /// </summary>
    /// <param name="row"> The row number. </param>
    /// <param name="objectsInLine"> The objects to destroy. </param>
    private void ClearLine(int row, List<GameObject> objectsInLine)
    {
        Ray laserPoint = new Ray(STARTING_RAYCAST_POSITION + new Vector3(0, ROW_SIZE - row, 0), transform.right);
        RaycastHit hit;

        for(int column = 0; column < COLUMN_SIZE; column++)
        {
            if(Physics.Raycast(laserPoint, out hit, 1))
            {
                Destroy(hit.collider.transform.gameObject);
            }

            laserPoint.origin += Vector3.back;
        }
        
        ScoreManager._instance.AddPoint();
    }

    /// <summary>
    /// Update the number of times an object has been sliced.
    /// </summary>
    /// <param name="objectsInLine"> The objects to update. </param>
    private void UpdateTimesSliced(List<GameObject> objectsInLine)
    {
        foreach(GameObject fragment in objectsInLine)
        {
            fragment.transform.root.GetComponent<ObjectManager>()._numSliced++;
        }
    }
}