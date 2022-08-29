using UnityEngine;

public class IdleVertexCollisionManager : MonoBehaviour
{
    /// <summary>
    /// Tell the root game object that a child object has collided with another object.
    /// </summary>
    void OnCollisionEnter()
    {
        transform.root.GetComponent<IdleObjectCollisionManager>().CollisionDetected(this);
    }
}
