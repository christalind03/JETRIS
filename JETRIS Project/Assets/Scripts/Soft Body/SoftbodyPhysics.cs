using UnityEngine;
using UnityEditor;

public class SoftbodyPhysics : MonoBehaviour
{
    private static float VertexSize = 0.00125f;
    private static float Spring = 75f;
    private static float Damper = 0.01f;

    /// <summary>
    /// Add a box collider to the given object.
    /// </summary>
    /// <param name="userObject"> The object to apply a box collider to. </param>
    public static void AddBoxCollider(ref GameObject userObject)
    {
        BoxCollider objectBoxCollider = userObject.AddComponent<BoxCollider>();
        objectBoxCollider.size = new Vector3(VertexSize, VertexSize, VertexSize);
    }

    /// <summary>
    /// Add a rigidbody to the given object with no gravity.
    /// The lack of gravity is important for the idle drop "animation" where the object is supposed to be static.
    /// </summary>
    /// <param name="userObject"> The object to apply a rigidbody to. </param>
    public static void AddRigidbody(ref GameObject userObject)
    {
        Rigidbody objectRigidbody = userObject.AddComponent<Rigidbody>();
        objectRigidbody.useGravity = false;
        objectRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        objectRigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    /// <summary>
    /// Add a spring joint in between two given objects.
    /// </summary>
    /// <param name="userObjectOne"> The first point to attach the spring joint to. </param>
    /// <param name="userObjectTwo"> The second point to attach the spring joint to. </param>
    public static void AddSpring(ref GameObject userObjectOne, ref GameObject userObjectTwo)
    {
        SpringJoint objectSpring = userObjectOne.AddComponent<SpringJoint>();
        objectSpring.connectedBody = userObjectTwo.GetComponent<Rigidbody>();
        objectSpring.spring = Spring;
        objectSpring.damper = Damper;
    }

    /// <summary>
    /// Enable to the given object's rigidbody.
    /// </summary>
    /// <param name="userObject"> The object that needs the rigidbody enabled. </param>
    public static void EnableGravity(ref GameObject userObject)
    {
        userObject.GetComponent<Rigidbody>().useGravity = true;
    }
}