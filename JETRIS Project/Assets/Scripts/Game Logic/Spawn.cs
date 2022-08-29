using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static GameObject _newTetromino;
    
    public static Vector3 _tetrominoPosition;
    public static Quaternion _tetrominoRotation;

    private static Vector3 PLAYABLE_SCALE = new Vector3(0.5f, 0.5f, 0.5f);
    private static Vector3 QUEUED_SCALE = new Vector3(-0.5f, -0.5f, -0.5f);

    /// <summary>
    /// Displays an object in the "Next" queue to the user.
    /// The object size is scaled down to half.
    /// </summary>
    /// <param name="tetrominoValue"> The object type to be displayed. </param>
    /// <returns> The displayed object. </returns>
    public static GameObject NextQueueTetromino(int tetrominoValue)
    {
        switch(tetrominoValue)
        {
            // Spawns ITetromino(Clone)
            case 1:
                _tetrominoPosition = new Vector3(0f, 8f, -8.5f);
                _tetrominoRotation = Quaternion.identity;
                _newTetromino = Instantiate(Resources.Load("Tetrominoes/ITetromino", typeof(GameObject)), _tetrominoPosition, _tetrominoRotation) as GameObject;
                break;

            // Spawns JTetromino(Clone)
            case 2:
                _tetrominoPosition = new Vector3(0.75f, 8.5f, -7.75f);
                _tetrominoRotation = Quaternion.Euler(90f, 180f, 0f);
                _newTetromino = Instantiate(Resources.Load("Tetrominoes/JTetromino", typeof(GameObject)), _tetrominoPosition, _tetrominoRotation) as GameObject;
                break;

            // Spawns LTetromino(Clone)
            case 3:
                _tetrominoPosition = new Vector3(0f, 8.5f, -9.25f);
                _tetrominoRotation = Quaternion.Euler(90f, 0f, 0f);
                _newTetromino = Instantiate(Resources.Load("Tetrominoes/LTetromino", typeof(GameObject)), _tetrominoPosition, _tetrominoRotation) as GameObject;
                break;

            // Spawns OTetromino(Clone)
            case 4:
                _tetrominoPosition = new Vector3(0f, 8f, -8.5f);
                _tetrominoRotation = Quaternion.identity;
                _newTetromino = Instantiate(Resources.Load("Tetrominoes/OTetromino", typeof(GameObject)), _tetrominoPosition, _tetrominoRotation) as GameObject;
                break;
            
            // Spawns STetromino(Clone)
            case 5:
                _tetrominoPosition = new Vector3(0f, 8f, -8.25f);
                _tetrominoRotation = Quaternion.identity;
                _newTetromino = Instantiate(Resources.Load("Tetrominoes/STetromino", typeof(GameObject)), _tetrominoPosition, _tetrominoRotation) as GameObject;
                break;
            
            // Spawns TTetromino(Clone)
            case 6:
                _tetrominoPosition = new Vector3(0f, 8f, -8.25f);
                _tetrominoRotation = Quaternion.identity;
                _newTetromino = Instantiate(Resources.Load("Tetrominoes/TTetromino", typeof(GameObject)), _tetrominoPosition, _tetrominoRotation) as GameObject;
                break;

            // Spawns ZTetromino(Clone)
            case 7:
                _tetrominoPosition = new Vector3(0.75f, 8f, -8.75f);
                _tetrominoRotation = Quaternion.Euler(0f, 180f, 0f);
                _newTetromino = Instantiate(Resources.Load("Tetrominoes/ZTetromino", typeof(GameObject)), _tetrominoPosition, _tetrominoRotation) as GameObject;
                break;
        }

        _newTetromino.AddComponent<IdleObjectCollisionManager>();

        _newTetromino.transform.localScale += QUEUED_SCALE;

        return _newTetromino;
    }

    /// <summary>
    /// Displays an object in the "Hold" queue to the user.
    /// The object size is scaled down to half.
    /// </summary>
    /// <param name="Tetromino"> The object type to be displayed </param>
    /// <returns> The displayed object. </returns>
    public static GameObject HoldQueueTetromino(GameObject Tetromino)
    {
        switch(Tetromino.name)
        {
            case "ITetromino(Clone)":
                _tetrominoPosition = new Vector3(0f, 17f, 8.5f);
                _tetrominoRotation = Quaternion.identity;
                break;
            
            case "JTetromino(Clone)":
                _tetrominoPosition = new Vector3(0.75f, 17.5f, 9.25f);
                _tetrominoRotation = Quaternion.Euler(90f, 180f, 0f);
                break;
            
            case "LTetromino(Clone)":
                _tetrominoPosition = new Vector3(0f, 17.5f, 7.75f);
                _tetrominoRotation = Quaternion.identity;
                _tetrominoRotation = Quaternion.Euler(90f, 0f, 0f);
                break;
            
            case "OTetromino(Clone)":
                _tetrominoPosition = new Vector3(0f, 17f, 8.5f);
                _tetrominoRotation = Quaternion.identity;
                break;
            
            case "STetromino(Clone)":
                _tetrominoPosition = new Vector3(0f, 17f, 8.75f);
                _tetrominoRotation = Quaternion.identity;
                break;
            
            case "TTetromino(Clone)":
                _tetrominoPosition = new Vector3(0f, 17f, 8.75f);
                _tetrominoRotation = Quaternion.identity;
                break;
            
            case "ZTetromino(Clone)":
                _tetrominoPosition = new Vector3(0.75f, 17f, 8.25f);
                _tetrominoRotation = Quaternion.Euler(0f, 180f, 0f);
                break;
        }
 
        Tetromino.transform.position = _tetrominoPosition;
        Tetromino.transform.rotation = _tetrominoRotation;
        Tetromino.transform.localScale += QUEUED_SCALE;

        return Tetromino;
    }

    /// <summary>
    /// Displays the playable object to the user.
    /// The object size is scaled up to its normal size.
    /// </summary>
    /// <param name="Tetromino"> The object to be displayed as playable. </param>
    public static void MakePlayable(GameObject Tetromino)
    {
        Tetromino.transform.position = new Vector3(0f, 21f, 0f);

        if(IsMirror(Tetromino))
            Tetromino.transform.position += Vector3.right;

        if(IsHook(Tetromino))
            Tetromino.transform.position += Vector3.up;

        // To grab gameobject for movement
        Tetromino.transform.localScale += PLAYABLE_SCALE;
        UserInput._instance._tetromino = Tetromino;
    }

    /// <summary>
    /// Checks whether or not the object is a mirrored version of another object.
    /// Currently, the only mirrored objects are the skew and hook Tetrominoes.
    /// These objects are the S and Z Tetrominoes and the J and L Tetrominoes, respectively.
    /// </summary>
    /// <param name="Tetromino"> The object to check. </param>
    /// <returns> True if the object is a mirror object (Z Tetromino or J Tetromino); otherwise, false. </returns>
    private static bool IsMirror(GameObject Tetromino)
    {
        if(Tetromino.name == "JTetromino(Clone)" || Tetromino.name == "ZTetromino(Clone)")
        {
            return true;
        }

        return false;
    }
    
    /// <summary>
    /// Checks whether or not the object is a hook Tetromino.
    /// Hook Tetrominoes are the J and L Tetrominoes, sort of representing a hook due to its bent shape.
    /// </summary>
    /// <param name="Tetromino"> The object to check. </param>
    /// <returns> True if the object is a hook Tetromino (LJTetromino or L Tetromino); otherwise false. </returns>
    private static bool IsHook(GameObject Tetromino)
    {
        if(Tetromino.name == "JTetromino(Clone)" || Tetromino.name == "LTetromino(Clone)")
        {
            return true;
        }

        return false;
    }
}