using UnityEngine;

public class IdleObjectCollisionManager : MonoBehaviour
{
    public bool _isCollisionDetected = false;

    private GameObject _vertexA1;
    private GameObject _vertexA2;
    private GameObject _vertexB1;
    private GameObject _vertexB2; 
    private GameObject _vertexC1;
    private GameObject _vertexC2; 
    private GameObject _vertexD1;
    private GameObject _vertexD2; 
    private GameObject _vertexE1;
    private GameObject _vertexE2; 
    private GameObject _vertexF1;
    private GameObject _vertexF2; 
    private GameObject _vertexG1;
    private GameObject _vertexG2; 
    private GameObject _vertexH1;
    private GameObject _vertexH2;
    private GameObject _vertexI1;
    private GameObject _vertexI2;
    private GameObject _vertexJ1;
    private GameObject _vertexJ2;

    /// <summary>
    /// Set all the necessary components for the vertices when the script is active.
    /// </summary>
    void Start()
    {
        SetVertices();
        SetColliders();
        SetRigidbodies();
        SetCollisionDetectors();
    }

    /// <summary>
    /// Set all the vertices from the object in which the current script is attached to to the class variables.
    /// </summary>
    private void SetVertices()
    {
        _vertexA1 = transform.GetChild(0).GetChild(0).gameObject;
        _vertexA2 = transform.GetChild(0).GetChild(1).gameObject;
        _vertexB1 = transform.GetChild(0).GetChild(2).gameObject;
        _vertexB2 = transform.GetChild(0).GetChild(3).gameObject;
        _vertexC1 = transform.GetChild(0).GetChild(4).gameObject;
        _vertexC2 = transform.GetChild(0).GetChild(5).gameObject;
        _vertexD1 = transform.GetChild(0).GetChild(6).gameObject;
        _vertexD2 = transform.GetChild(0).GetChild(7).gameObject;
        _vertexE1 = transform.GetChild(0).GetChild(8).gameObject;
        _vertexE2 = transform.GetChild(0).GetChild(9).gameObject;
        _vertexF1 = transform.GetChild(0).GetChild(10).gameObject;
        _vertexF2 = transform.GetChild(0).GetChild(11).gameObject;
        _vertexG1 = transform.GetChild(0).GetChild(12).gameObject;
        _vertexG2 = transform.GetChild(0).GetChild(13).gameObject;
        _vertexH1 = transform.GetChild(0).GetChild(14).gameObject;
        _vertexH2 = transform.GetChild(0).GetChild(15).gameObject;
        _vertexI1 = transform.GetChild(0).GetChild(16).gameObject;
        _vertexI2 = transform.GetChild(0).GetChild(17).gameObject;

        if(!IsOTetromino())
        {
         _vertexJ1 = transform.GetChild(0).GetChild(18).gameObject;
         _vertexJ2 = transform.GetChild(0).GetChild(19).gameObject;
        }
    }

    /// <summary>
    /// Add box colliders to all the object's vertices.
    /// </summary>
    private void SetColliders()
    {
        SoftbodyPhysics.AddBoxCollider(ref _vertexA1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexA2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexB1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexB2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexC1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexC2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexD1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexD2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexE1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexE2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexF1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexF2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexG1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexG2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexH1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexH2);
        SoftbodyPhysics.AddBoxCollider(ref _vertexI1);
        SoftbodyPhysics.AddBoxCollider(ref _vertexI2);
        
        if(!IsOTetromino())
        {
            SoftbodyPhysics.AddBoxCollider(ref _vertexJ1);
            SoftbodyPhysics.AddBoxCollider(ref _vertexJ2);
        }
    }

    /// <summary>
    /// Add rigidbodies to all the object's vertices.
    /// </summary>
    private void SetRigidbodies()
    {
        SoftbodyPhysics.AddRigidbody(ref _vertexA1);
        SoftbodyPhysics.AddRigidbody(ref _vertexA2);
        SoftbodyPhysics.AddRigidbody(ref _vertexB1);
        SoftbodyPhysics.AddRigidbody(ref _vertexB2);
        SoftbodyPhysics.AddRigidbody(ref _vertexC1);
        SoftbodyPhysics.AddRigidbody(ref _vertexC2);
        SoftbodyPhysics.AddRigidbody(ref _vertexD1);
        SoftbodyPhysics.AddRigidbody(ref _vertexD2);
        SoftbodyPhysics.AddRigidbody(ref _vertexE1);
        SoftbodyPhysics.AddRigidbody(ref _vertexE2);
        SoftbodyPhysics.AddRigidbody(ref _vertexF1);
        SoftbodyPhysics.AddRigidbody(ref _vertexF2);
        SoftbodyPhysics.AddRigidbody(ref _vertexG1);
        SoftbodyPhysics.AddRigidbody(ref _vertexG2);
        SoftbodyPhysics.AddRigidbody(ref _vertexH1);
        SoftbodyPhysics.AddRigidbody(ref _vertexH2);
        SoftbodyPhysics.AddRigidbody(ref _vertexI1);
        SoftbodyPhysics.AddRigidbody(ref _vertexI2);
        
        if(!IsOTetromino())
        {
            SoftbodyPhysics.AddRigidbody(ref _vertexJ1);
            SoftbodyPhysics.AddRigidbody(ref _vertexJ2);
        }
    }

    /// <summary>
    /// Add collision detectors to all the object's vertices.
    /// </summary>
    private void SetCollisionDetectors()
    {
        _vertexA1.AddComponent<IdleVertexCollisionManager>();
        _vertexA2.AddComponent<IdleVertexCollisionManager>();
        _vertexB1.AddComponent<IdleVertexCollisionManager>();
        _vertexB2.AddComponent<IdleVertexCollisionManager>();
        _vertexC1.AddComponent<IdleVertexCollisionManager>();
        _vertexC2.AddComponent<IdleVertexCollisionManager>();
        _vertexD1.AddComponent<IdleVertexCollisionManager>();
        _vertexD2.AddComponent<IdleVertexCollisionManager>();
        _vertexE1.AddComponent<IdleVertexCollisionManager>();
        _vertexE2.AddComponent<IdleVertexCollisionManager>();
        _vertexF1.AddComponent<IdleVertexCollisionManager>();
        _vertexF2.AddComponent<IdleVertexCollisionManager>();
        _vertexG1.AddComponent<IdleVertexCollisionManager>();
        _vertexG2.AddComponent<IdleVertexCollisionManager>();
        _vertexH1.AddComponent<IdleVertexCollisionManager>();
        _vertexH2.AddComponent<IdleVertexCollisionManager>();
        _vertexI1.AddComponent<IdleVertexCollisionManager>();
        _vertexI2.AddComponent<IdleVertexCollisionManager>();

        if(!IsOTetromino())
        {
         _vertexJ1.AddComponent<IdleVertexCollisionManager>();
         _vertexJ2.AddComponent<IdleVertexCollisionManager>();
        }
    }
    
    /// <summary>
    /// Check to see if any of the vertices detected a collision.
    /// If a collision is detected, set the _isCollisionDetected class variable to true; otherwise it will remain false.
    /// </summary>
    public void CollisionDetected(IdleVertexCollisionManager _vertex)
    {
        _isCollisionDetected = true;
    }

    /// <summary>
    /// Clear all the collision detectors from the object's vertices.
    /// </summary>
    public void ClearVertexCollisionManagers()
    {
        Destroy(_vertexA1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexA2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexB1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexB2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexC1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexC2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexD1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexD2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexE1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexE2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexF1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexF2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexG1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexG2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexH1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexH2.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexI1.GetComponent<IdleVertexCollisionManager>());
        Destroy(_vertexI2.GetComponent<IdleVertexCollisionManager>());

        if(!IsOTetromino())
        {
            Destroy(_vertexJ1.GetComponent<IdleVertexCollisionManager>());
            Destroy(_vertexJ2.GetComponent<IdleVertexCollisionManager>());
        }
    }
    
    /// <summary>
    /// Check to see if the current object the script is attached to is an OTetromino(Clone).
    /// </summary>
    /// <returns> If the current object the script is attached to is an OTetromino(Clone), return true; otherwise false. </returns>
    private bool IsOTetromino()
    {
        return transform.name == "OTetromino(Clone)";
    }
}
