using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInput : MonoBehaviour
{
    public static UserInput _instance;
    public GameObject _tetromino;
    public Vector3 _rotationPoint;
    
    private HoldQueue _holdQueue;
    private NextQueue _nextQueue;

    private float _dropSpeed;
    private float _timer = 0f;
    private bool _isHoldAvailable = true;
    
    /// <summary>
    /// Start and setup the game before the first frame update.
    /// </summary>
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Countdown");
        
        StartCoroutine(SetupGame());

        _instance = this;
    }

    /// <summary>
    /// Sets up the game after the countdown finishes.
    /// </summary>
    private IEnumerator SetupGame()
    {
        // Allows the NextQueue script to run during countdown before assigning class variables
        yield return new WaitForSeconds(3f);

        _holdQueue = GetComponent<HoldQueue>();
        _nextQueue = GetComponent<NextQueue>();

        _tetromino = _nextQueue._playableTetromino;

        FindObjectOfType<AudioManager>().Play("Theme Music");
    }

    void Update()
    {
        if(Countdown._instance._countDownDone)
        {
            IdleDrop();
            IdleRelease();

            HoldTetromino();
            MoveLeft();
            MoveRight();
            Rotate();
            SoftDrop();
            HardDrop();
        }

        _dropSpeed = LevelManager._dropSpeed;
    }
    
    /// <summary>
    /// Moves the current object the user is controlling down by one unit.
    /// </summary>
    private void IdleDrop()
    {
        if(_timer >= _dropSpeed)
        {
            _tetromino.transform.position += new Vector3(0, -1, 0);
            _timer = 0f;
        }
        else
        {
            _timer += 1 * Time.deltaTime;
        }
    }

    /// <summary>
    /// Drops the current object the user is controlling if it collides with another object or reaches the game floor position.
    /// </summary>
    private void IdleRelease()
    {
        if(_tetromino.GetComponent<IdleObjectCollisionManager>()._isCollisionDetected == true || _tetromino.transform.position.y == 0)
        {
            // Quick and dirty code to prevent object clipping
            if(_tetromino.transform.position.y == 0)
            {
                CheckBounds.GameFloor(_tetromino);
            } else
            {
                _tetromino.transform.position += Vector3.up;
            }

            DropTetromino.Release(_tetromino);
            
            _nextQueue.UpdateQueue();
            _tetromino = _nextQueue._playableTetromino;

            _isHoldAvailable = true;
        }
    }

    /// <summary>
    /// Allows the user to hold an object for later use by pressing the 'C' key.
    /// If an object is already being held, the two objects will swap positions.
    /// </summary>
    private void HoldTetromino()
    {
        if(Input.GetKeyDown(KeyCode.C) && _isHoldAvailable == true)
        {
            if(_holdQueue.IsEmpty())
            {
                _holdQueue.SetHold(_tetromino);
                
                _nextQueue.UpdateQueue();
                _tetromino = _nextQueue._playableTetromino;
            } else
            {
                _tetromino = _holdQueue.UpdateHold(_tetromino);
            }
            
            _isHoldAvailable = false;
        }
    }

    /// <summary>
    /// Allows the user to move the object one unit to the left by pressing the left arrow key.
    /// If the object is out of playable bounds, it will fix itself to be in bounds.
    /// </summary>
    private void MoveLeft()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _tetromino.transform.position += Vector3.forward;
        }

        CheckBounds.Left(_tetromino);
    }

    /// <summary>
    /// Allows the user to move the object one unit to the right by pressing the right arrow key.
    /// If the object is out of playable bounds, it will fix itself to be in bounds.
    /// </summary>
    private void MoveRight()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _tetromino.transform.position += Vector3.back;
        }

        CheckBounds.Right(_tetromino);
    }

    /// <summary>
    /// Allows the user to rotate the object clockwise in 90 degree intervals by pressing the up arrow key.
    /// If the object is out of playable bounds, it will fix itself to be in bounds.
    /// </summary>
    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _tetromino.transform.RotateAround(_tetromino.transform.TransformPoint(_rotationPoint), new Vector3(1f, 0f, 0f), -90f);
        }

        CheckBounds.Left(_tetromino);
        CheckBounds.Right(_tetromino);
    }

    /// <summary>
    /// Allows the user to speed up the dropping process by pressing the down arrow key.
    /// </summary>
    private void SoftDrop()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _tetromino.transform.position += Vector3.down;
        }
    }

    /// <summary>
    /// Drops the current object the user is controlling.
    /// </summary>
    private void HardDrop()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DropTetromino.Release(_tetromino);

            _nextQueue.UpdateQueue();
            _tetromino = _nextQueue._playableTetromino;

            _isHoldAvailable = true;
        }
    }
}