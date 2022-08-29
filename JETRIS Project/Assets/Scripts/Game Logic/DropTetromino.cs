using UnityEngine;
using System.Collections;

public class DropTetromino : MonoBehaviour
{
    /// <summary>
    /// Simulate the feeling of releasing the object from the player through a softbody physics script.
    /// After the softbody is applied, play a jelly collision sound effect.
    /// </summary>
    /// <param name="tetromino"> The game object to apply softbody effects on. </param>
    public static void Release(GameObject tetromino)
    {
        tetromino.GetComponent<IdleObjectCollisionManager>().ClearVertexCollisionManagers();

        RemoveTetrominoComponents(tetromino);
        ApplySoftbody(tetromino);

        FindObjectOfType<AudioManager>().Play("Collision Sound Effect");
    }

    /// <summary>
    /// Remove all of the object's current components.
    /// This is to ensure nothing disrupts the softbody physics when it is applied.
    /// </summary>
    /// <param name="tetromino"> The game object to remove components from. </param>
    private static void RemoveTetrominoComponents(GameObject tetromino)
    {
        foreach(var tetrominoComponent in tetromino.GetComponents<Component>())
        {
            if(!(tetrominoComponent is Transform))
            {
                Destroy(tetrominoComponent);
            }
        }
    }

    /// <summary>
    /// Apply the corresponding softbody physics script depending on the object's name.
    /// </summary>
    /// <param name="tetromino"> The game object to add the softbody physics to. </param>
    private static void ApplySoftbody(GameObject tetromino)
    {
        switch(tetromino.name)
        {
            case "ITetromino(Clone)":
                {
                    tetromino.AddComponent<ITetrominoSoftbody>();
                }

                break;

            case "JTetromino(Clone)":
                {
                    tetromino.AddComponent<HookTetrominoSoftbody>();
                }

                break;

            case "LTetromino(Clone)":
                {
                    tetromino.AddComponent<HookTetrominoSoftbody>();
                }

                break;

            case "OTetromino(Clone)":
                {
                    tetromino.AddComponent<OTetrominoSoftbody>();
                }

                break;
            
            case "STetromino(Clone)":
                {
                    tetromino.AddComponent<SkewTetrominoSoftbody>();
                }

                break;
            
            case "TTetromino(Clone)":
                {
                    tetromino.AddComponent<TTetrominoSoftbody>();
                }

                break;

            case "ZTetromino(Clone)":
                {
                    tetromino.AddComponent<SkewTetrominoSoftbody>();
                }

                break;
        }
    }
}