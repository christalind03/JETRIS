using UnityEngine;
using System.Collections.Generic;

public class LineShiftingManager : MonoBehaviour
{
    private List<GameObject> _objectsInLine = new List<GameObject>();

    private static int ROW_SIZE = 20;
    private static int COLUMN_SIZE = 10;

    private static Vector3 STARTING_RAYCAST_POSITION = new Vector3(-0.5f, 0.5f, 4.5f);

    /// <summary>
    /// Shift all the lines above the given row number down by one unit.
    /// </summary>
    /// <param name="row"> The row number that has been cleared. </param>
    public void ShiftLinesDown(int row)
    {
        // Since the array of raycasts go from 0 (top of the game board) to 20 (bottom of the game board) we have to subtract by one to in order to start shifting lines.
        // Without this, the topmost line would never shift down.
        int offset = -1;
        row += offset;

        for(int rowIteration = row; rowIteration > 0; rowIteration--)
        {
            DetectLines(rowIteration);
        }

        ShiftObjectsDown();
        _objectsInLine.Clear();
    }

    /// <summary>
    /// Scan and detect all the objects within the given row and stores them in the class list.
    /// </summary>
    /// <param name="row"> The row number to be scanned. </param>
    private void DetectLines(int row)
    {
        // Since the array of raycasts goes from 0 (top of the board) to 20 (bottom of the board), we subtract the total row size by its row number to get the row's y coordinate.
        Ray laserPoint = new Ray(STARTING_RAYCAST_POSITION + new Vector3(0, ROW_SIZE - row, 0), transform.right);
        RaycastHit hit;

        for(int column = 0; column < COLUMN_SIZE; column++)
        {
            if(Physics.Raycast(laserPoint, out hit, 1) && !IsInList(_objectsInLine, hit.collider.transform.gameObject))
            {
                // After mesh slicing, mesh colliders are automatically set to be convex.
                // We want the collider to be concave so there are no gaps when placing another object on top of this one.
                hit.transform.GetComponent<MeshCollider>().convex = false;

                _objectsInLine.Add(hit.collider.transform.gameObject);
            }

            laserPoint.origin += Vector3.back;
        }
    }

    /// <summary>
    /// Check to see if an object is already within the given list.
    /// </summary>
    /// <param name="iterator"> The list to iterate through. </param>
    /// <param name="gameObjectToFind"> The object to find. </param>
    /// <returns> True if the object is already in the list; otherwise, false. </returns>
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
    /// Shift all the objects down within the class list down by one unit.
    /// </summary>
    private void ShiftObjectsDown()
    {
        foreach(GameObject fragment in _objectsInLine)
        {
            fragment.transform.position += Vector3.down;
        }
    }
}