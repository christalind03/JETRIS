using UnityEngine;

public class HoldQueue : MonoBehaviour
{
    private GameObject _currentTetrominoOnHold = null;
    private GameObject _previousTetrominoOnHold = null;

    /// <summary>
    /// Moves the current object outside of the hold queue.
    /// Replaces the object that was on hold with a new one.
    /// </summary>
    /// <param name="tetromino"> The game object to be put on hold. </param>
    /// <returns> The object that was previously being held. </returns>
    public GameObject UpdateHold(GameObject tetromino)
    {
        _previousTetrominoOnHold = _currentTetrominoOnHold;
        SetHold(tetromino);

        Spawn.MakePlayable(_previousTetrominoOnHold);

        return _previousTetrominoOnHold;
    }

    /// <summary>
    /// Put an object on hold for future use.
    /// </summary>
    /// <param name="tetromino"> The game object to be put on hold. </param>
    public void SetHold(GameObject tetromino)
    {
        _currentTetrominoOnHold = Spawn.HoldQueueTetromino(tetromino);
    }


    /// <summary>
    /// Check if there is an object on hold.
    /// </summary>
    /// <returns> True if the current object on hold is null; otherwise false. </returns>
    public bool IsEmpty()
    {
        return _currentTetrominoOnHold == null;
    }
}
