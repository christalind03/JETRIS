using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public int _numSliced = 0;
    private int _maxSlices = 0;
    private string _tetrominoName = "";
    private Vector3 _rotation;

    /// <summary>
    /// Retrieve the object's name, object rotation, and the maximum amount of slices when the script is applied to an object.
    /// </summary>
    void Start()
    {
        GetTetrominoName();
        GetObjectRotation();
        Calculate_maxSlices();
    }

    /// <summary>
    /// Retrieve the object's name.
    /// </summary>
    private void GetTetrominoName()
    {
        _tetrominoName = this.gameObject.name;
    }

    /// <summary>
    /// Retrieve the object's Vector3 rotation.
    /// </summary>
    private void GetObjectRotation()
    {
        _rotation = this.transform.localEulerAngles;
    }

    /// <summary>
    /// Retrieve the object's maximum amount of slices depending on its rotation.
    /// </summary>
    private void Calculate_maxSlices()
    {
        switch(_tetrominoName)
        {
            case "ITetromino(Clone)":
                if(_rotation == new Vector3(0, 0, 0) || _rotation == new Vector3(0, 180, 180))
                {
                    _maxSlices = 1;
                }
                else
                {
                    _maxSlices = 4;
                }
                
                break;

            case "JTetromino(Clone)":
                if(_rotation == new Vector3(90, 180, 0) || _rotation == new Vector3(270, 180, 0))
                {
                    _maxSlices = 2;
                }
                else
                {
                    _maxSlices = 3;
                }

                break;

            case "LTetromino(Clone)":
                if(_rotation == new Vector3(90, 0, 0) || _rotation == new Vector3(270, 0, 0))
                {
                    _maxSlices = 2;
                }
                else
                {
                    _maxSlices = 3;
                }

                break;

            // No need to calculate the rotation since the OTetromino is the same on all sides
            case "OTetromino(Clone)":
                _maxSlices = 2;
                break;

            case "STetromino(Clone)":
            case "TTetromino(Clone)":
                if(_rotation == new Vector3(0, 0, 0) || _rotation == new Vector3(0, 180, 180))
                {
                    _maxSlices = 2;
                }
                else
                {
                    _maxSlices = 3;
                }

                break;

            case "ZTetromino(Clone)":
                if(_rotation == new Vector3(0, 180, 0) || _rotation == new Vector3(0, 0, 180))
                {
                    _maxSlices = 2;
                }
                else
                {
                    _maxSlices = 3;
                }
                
                break;
        }
    }

    /// <summary>
    /// Check every frame if the object has met its maximum amount of slices.
    /// If it does, destroy the current game object.
    /// </summary>
    void Update()
    {
        if(_numSliced == _maxSlices)
        {
            Destroy(this.gameObject);
        }
    }
}