using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NextQueue : MonoBehaviour
{
    public GameObject _playableTetromino;
    private GameObject _queuedTetromino1;
    private GameObject _queuedTetromino2;
    private GameObject _queuedTetromino3;
    private GameObject _queuedTetromino4;

    public List<int> _previousTetrominoes = new List<int>(12);
    private int _tetrominoType;

    /// <summary>
    /// Create and display the objects in the queue to the user before the first frame update.
    /// </summary>
    void Start()
    {
        InitQueue();
        InitTetrominoes();
    }

    /// <summary>
    /// Generate a pre-existing list of objects to the queue.
    /// </summary>
    private void InitQueue()
    {
        // Pre-generate random Tetromino pieces
        for(int index = 0; index < 12; index++)
        {
            GenerateTetromino();
            _previousTetrominoes.Add(_tetrominoType);
        }
    }

    /// <summary>
    /// Display the objects to the user on the screen.
    /// </summary>
    private void InitTetrominoes()
    {
        // Spawn current, playable Tetromino
        _playableTetromino = Spawn.NextQueueTetromino(_previousTetrominoes[7]);
        Spawn.MakePlayable(_playableTetromino);

        // Spawn queued Tetrominoes
        _queuedTetromino1 = Spawn.NextQueueTetromino(_previousTetrominoes[8]);
        _queuedTetromino1.transform.position += new Vector3(0f, 9f, 0f);

        _queuedTetromino2 = Spawn.NextQueueTetromino(_previousTetrominoes[9]);
        _queuedTetromino2.transform.position += new Vector3(0f, 6f, 0f);

        _queuedTetromino3 = Spawn.NextQueueTetromino(_previousTetrominoes[10]);
        _queuedTetromino3.transform.position += new Vector3(0f, 3f, 0f);

        _queuedTetromino4 = Spawn.NextQueueTetromino(_previousTetrominoes[11]);
    }

    /// <summary>
    /// Shift all the objects within the queue "up."
    /// </summary>
    public void UpdateQueue()
    {
        // Making current Tetromino piece playable
        _playableTetromino = _queuedTetromino1;
        Spawn.MakePlayable(_playableTetromino);

        // Moving Tetrominoes in the queue upwards
        _queuedTetromino1 = _queuedTetromino2;
        _queuedTetromino1.transform.position += new Vector3(0f, 3f, 0f);

        _queuedTetromino2 = _queuedTetromino3;
        _queuedTetromino2.transform.position += new Vector3(0f, 3f, 0f);

        _queuedTetromino3 = _queuedTetromino4;
        _queuedTetromino4.transform.position += new Vector3(0f, 3f, 0f);

        // Spawning new Tetromino in queue
        GenerateTetromino();
        _previousTetrominoes.RemoveAt(0);
        _previousTetrominoes.Add(_tetrominoType);
        
        _queuedTetromino4 = Spawn.NextQueueTetromino(_tetrominoType);
    }

    /// <summary>
    /// Create a new piece in the queue.
    /// This algorithm ensures that each piece is generated equally.
    /// </summary>
    private void GenerateTetromino()
    {
        _tetrominoType = Random.Range(1, 8);

        while(NumOccurence(_previousTetrominoes, _tetrominoType) >= 2)
        {
            _tetrominoType = Random.Range(1, 8);
        }
    }

    /// <summary>
    /// Check how many times a given element appears in the given list.
    /// </summary>
    /// <param name="iterable"> The list to iterate through. </param>
    /// <param name="elementToFind"> The element to find within the list. </param>
    /// <returns> The number of times the element has occured within the list. </returns>
    private int NumOccurence(List<int> iterable, int elementToFind)
    {
        int numOccurence = 0;

        foreach(int element in iterable)
        {
            if(element == elementToFind)
            {
                numOccurence++;
            }
        }

        return numOccurence;
    }
}