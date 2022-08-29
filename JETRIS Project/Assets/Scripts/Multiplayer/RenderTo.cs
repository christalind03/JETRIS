using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderTo : MonoBehaviour
{
    RenderTexture cameratexture;
    Camera gamecamera;
    public RawImage textureout;

    /// <summary>
    /// Render the game board to the user's screen from a different position.
    /// This allows for easier implementation for multiplayer purposes.
    /// </summary>
    void Start()
    {
        cameratexture = new RenderTexture(Screen.height, Screen.height, 32);
        gamecamera = gameObject.GetComponent<Camera>();
        gamecamera.aspect = 0.9f;
        gamecamera.targetTexture = cameratexture;
        textureout.texture = cameratexture;
    }
}
