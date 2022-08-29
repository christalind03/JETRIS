using System;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LineDetectionManager : MonoBehaviour
{
    private GameObject _tetrominoSpawner = null;
    private bool _isPreparing = false;
    private bool _isSlicing = false;
    private int _linesCleared = 0;
    private float _delay;

    private int ROW_SIZE = 20;
    private int COLUMN_SIZE = 10;

    private static Vector3 STARTING_RAYCAST_POSITION = new Vector3(-0.5f, 0.5f, 4.5f);

    /// <summary>
    /// Find and initialize the _tetrominoSpawner game object so we don't have to search for it every frame in the Update() function.
    /// </summary>
    void Start()
    {
        _tetrominoSpawner = GameObject.Find("Tetromino Spawner");
    }

    /// <summary>
    /// Check every frame to see if the game is over, if not check all the rows in the game board.
    /// </summary>
    void Update()
    {
        if(IsGameOver())
        {
            _tetrominoSpawner.SetActive(false);
            SceneManager.LoadScene("Game Over");
        }

        CheckRows();
    }

    /// <summary>
    /// Check to see if a game is over by using raycasting.
    /// If the raycast ray finds a collider within the spawn height, return a boolean value.
    /// </summary>
    /// <returns> True if there is an object with a collider within the spawn height; otherwise, false. </returns>
    private bool IsGameOver()
    {
        float spawnHeight = 22f;

        Ray laserPoint = new Ray(STARTING_RAYCAST_POSITION + new Vector3(0, spawnHeight, 0), transform.right);
        RaycastHit hit;

        for(int column = 0; column < COLUMN_SIZE; column++)
        {
            if(Physics.Raycast(laserPoint, out hit, 1))
            {
                return true;
            }

            laserPoint.origin += Vector3.back;
        }

        return false;
    }

    /// <summary>
    /// Check all the rows in the game board, solidifying objects along the way.
    /// If a row is filled, clear the line.
    /// </summary>
    private void CheckRows()
    {
        for(int row = 0; row < ROW_SIZE; row++)
        {
            SolidifyObjects(row + 1);

            if(IsRowFilled(row + 1) && _isSlicing == false)
            {
                StartCoroutine(ClearPieces(row + 1));
                StartCoroutine(ShiftDown(row + 1));
            }
        }
    }

    /// <summary>
    /// Check to see if the given row number contains any softbody objects using raycasting.
    /// If the raycast hits a softbody object, solidify it.
    /// </summary>
    /// <param name="row"> The row number to check. </param>
    private void SolidifyObjects(int row)
    {
        // Since the array of raycasts goes from 0 (top of the board) to 20 (bottom of the board), we subtract the total row size by its row number to get the row's y coordinate.
        Ray laserPoint = new Ray(STARTING_RAYCAST_POSITION + new Vector3(0, ROW_SIZE - row, (-STARTING_RAYCAST_POSITION.z * 2)), transform.right);
        RaycastHit hit;

        for(int column = COLUMN_SIZE; column > 0; column--)
        {
            if(Physics.Raycast(laserPoint, out hit, 1))
            {
                if(IsSoftbody(hit.collider.transform.root.gameObject) && _isPreparing == false)
                {
                    StartCoroutine(MakeSlicable(hit.collider.transform.root.gameObject));
                }
            }

            laserPoint.origin += Vector3.forward;
        }
    }

    /// <summary>
    /// Check to see if the given row number is full of objects using raycasting.
    /// If the raycast hits a softbody object, solidify it.
    /// </summary>
    /// <param name="row"> The row number to check. </param>
    /// <returns> True if there is an object with a collider within the spawn height; otherwise, false. </returns>
    private bool IsRowFilled(int row)
    {
        // Since the array of raycasts goes from 0 (top of the board) to 20 (bottom of the board), we subtract the total row size by its row number to get the row's y coordinate.
        Ray laserPoint = new Ray(STARTING_RAYCAST_POSITION + new Vector3(0, ROW_SIZE - row, 0), transform.right);
        RaycastHit hit;

        for(int column = 0; column < COLUMN_SIZE; column++)
        {
            if(!Physics.Raycast(laserPoint, out hit, 1))
            {
                return false;
            }

            if(IsSoftbody(hit.collider.transform.root.gameObject) && _isPreparing == false)
            {
                StartCoroutine(MakeSlicable(hit.collider.transform.root.gameObject));
            }

            laserPoint.origin += Vector3.back;
        }

        return true;
    }

    /// <summary>
    /// Check to see if the given object is a softbody.
    /// If it is, destroy the component that makes it a softbody.
    /// </summary>
    /// <param name="tetromino"> The object to check. </param>
    /// <returns> True if the object is a softbody; otherwise, false. </returns>
    private bool IsSoftbody(GameObject tetromino)
    {
        if(tetromino.GetComponent<ISoftbody>() != null)
        {
            Destroy(tetromino.GetComponent(typeof(ISoftbody)));
            return true;
        }

        return false;
    }

    /// <summary>
    /// Prepare the given object to be slicable.
    /// Boolean values are added before and after the delay to ensure that the coroutine only runs once.
    /// A delay is added to ensure there is enough time for the object to settle after bouncing.
    /// Without this delay, the object would be in the wrong position.
    /// </summary>
    /// <param name="tetromino"> The object to make slicable. </param>
    private IEnumerator MakeSlicable(GameObject tetromino)
    {   
        _isPreparing = true;
        _delay = 0.75f * LineDelay.Calculate(tetromino);

        yield return new WaitForSeconds(_delay);

        GetComponent<LinePreparingManager>().PrepareObjects(tetromino);

        _isPreparing = false;
    }

    /// <summary>
    /// Clear the objects within the given row.
    /// Boolean values are added before and after the delay to ensure that the coroutine only runs once.
    /// A delay is added to ensure there is enough time for the object to settle after bouncing.
    /// </summary>
    /// <param name="row"> The row to slice. </param>
    private IEnumerator ClearPieces(int row)
    {
        _isSlicing = true;

        yield return new WaitForSeconds(_delay);

        GetComponent<LineClearingManager>().ClearLines(row);
        _linesCleared++;

        _isSlicing = false;
    }

    /// <summary>
    /// Shift all the rows above the given row down by one unit.
    /// A delay is added to ensure there is enough time for the object to settle after bouncing.
    /// </summary>
    /// <param name="row"> The object to make slicable. </param>
    private IEnumerator ShiftDown(int row)
    {
        yield return new WaitForSeconds(_delay);
        GetComponent<LineShiftingManager>().ShiftLinesDown(row);
    }
}