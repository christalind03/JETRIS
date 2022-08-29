using UnityEngine;

public class FloatingObjectAnimation : MonoBehaviour
{
    /// <summary>
    /// Rotates the object while bobbing up and down every frame.
    /// </summary>
    void Update()
    {
        float rotationSpeedX = 0f;
        float rotationSpeedY = 0f;
        float rotationSpeedZ = 15 * Time.deltaTime;

        float objectPositionX = transform.position.x;
        float objectPositionY = (Mathf.Sin(Time.time) * 1.5f);
        float objectPositionZ = transform.position.z;

        transform.Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ, Space.Self);
        transform.position = new Vector3(objectPositionX, objectPositionY, objectPositionZ);
    }
}