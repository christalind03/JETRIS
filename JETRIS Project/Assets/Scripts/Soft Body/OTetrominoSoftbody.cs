using UnityEngine;

public class OTetrominoSoftbody : MonoBehaviour, ISoftbody
{
    private GameObject VertexA1;
    private GameObject VertexA2;
    private GameObject VertexB1;
    private GameObject VertexB2; 
    private GameObject VertexC1;
    private GameObject VertexC2; 
    private GameObject VertexD1;
    private GameObject VertexD2; 
    private GameObject VertexE1;
    private GameObject VertexE2; 
    private GameObject VertexF1;
    private GameObject VertexF2; 
    private GameObject VertexG1;
    private GameObject VertexG2; 
    private GameObject VertexH1;
    private GameObject VertexH2;
    private GameObject VertexI1;
    private GameObject VertexI2;

    private GameObject RayDetector1;
    private GameObject RayDetector2;
    private GameObject RayDetector3;
    private GameObject RayDetector4;

    /// <summary>
    /// Set all the necessary components for the softbody when the script is active.
    /// </summary>
    void Start()
    {
        SetVertices();

        InitRayDetectors();

        GenerateCubeOne();
        GenerateCubeTwo();
        GenerateCubeThree();
        GenerateCubeFour();
        
        EnableGravity();
    }

    /// <summary>
    /// Set all the vertices from the object in which the current script is attached to to the class variables.
    /// </summary>
    public void SetVertices()
    {
        VertexA1 = transform.GetChild(0).GetChild(0).gameObject;
        VertexA2 = transform.GetChild(0).GetChild(1).gameObject;
        VertexB1 = transform.GetChild(0).GetChild(2).gameObject;
        VertexB2 = transform.GetChild(0).GetChild(3).gameObject;
        VertexC1 = transform.GetChild(0).GetChild(4).gameObject;
        VertexC2 = transform.GetChild(0).GetChild(5).gameObject;
        VertexD1 = transform.GetChild(0).GetChild(6).gameObject;
        VertexD2 = transform.GetChild(0).GetChild(7).gameObject;
        VertexE1 = transform.GetChild(0).GetChild(8).gameObject;
        VertexE2 = transform.GetChild(0).GetChild(9).gameObject;
        VertexF1 = transform.GetChild(0).GetChild(10).gameObject;
        VertexF2 = transform.GetChild(0).GetChild(11).gameObject;
        VertexG1 = transform.GetChild(0).GetChild(12).gameObject;
        VertexG2 = transform.GetChild(0).GetChild(13).gameObject;
        VertexH1 = transform.GetChild(0).GetChild(14).gameObject;
        VertexH2 = transform.GetChild(0).GetChild(15).gameObject;
        VertexI1 = transform.GetChild(0).GetChild(16).gameObject;
        VertexI2 = transform.GetChild(0).GetChild(17).gameObject;
    }

    public void InitRayDetectors()
    {
        RayDetector1 = Instantiate(Resources.Load("Colliders/RayCollider", typeof(GameObject))) as GameObject;
        RayDetector1.transform.parent = gameObject.transform;
        SoftbodyPhysics.AddRigidbody(ref RayDetector1);
        RayDetector1.transform.position = SpringCubeManager.FindMidpoint(VertexA1, VertexE2);
        
        RayDetector2 = Instantiate(Resources.Load("Colliders/RayCollider", typeof(GameObject))) as GameObject;
        RayDetector2.transform.parent = gameObject.transform;
        SoftbodyPhysics.AddRigidbody(ref RayDetector2);
        RayDetector2.transform.position = SpringCubeManager.FindMidpoint(VertexB1, VertexF2);

        RayDetector3 = Instantiate(Resources.Load("Colliders/RayCollider", typeof(GameObject))) as GameObject;
        RayDetector3.transform.parent = gameObject.transform;
        SoftbodyPhysics.AddRigidbody(ref RayDetector3);
        RayDetector3.transform.position = SpringCubeManager.FindMidpoint(VertexD1, VertexH2);

        RayDetector4 = Instantiate(Resources.Load("Colliders/RayCollider", typeof(GameObject))) as GameObject;
        RayDetector4.transform.parent = gameObject.transform;
        SoftbodyPhysics.AddRigidbody(ref RayDetector4);
        RayDetector4.transform.position = SpringCubeManager.FindMidpoint(VertexE1, VertexI2);
    }

    /// <summary>
    /// Create the first softbody cube.
    /// </summary>
    public void GenerateCubeOne()
    {
        // Generate Top Face
        SpringCubeManager.GenerateFace(ref VertexA2, ref VertexB2, ref VertexA1, ref VertexB1);
        // Generate Front Face
        SpringCubeManager.GenerateFace(ref VertexA1, ref VertexB1, ref VertexD1, ref VertexE1);
        // Generate Back Face
        SpringCubeManager.GenerateFace(ref VertexA2, ref VertexB2, ref VertexD2, ref VertexE2);
        // Generate Left Face
        SpringCubeManager.GenerateFace(ref VertexA1, ref VertexA2, ref VertexD1, ref VertexD2);

        SpringCubeManager.ConnectVertices(ref RayDetector1, ref VertexA1, ref VertexB1, ref VertexD1, ref VertexE1, ref VertexA2, ref VertexB2,ref VertexD2, ref VertexE2);
    }

    /// <summary>
    /// Create the second softbody cube.
    /// </summary>
    public void GenerateCubeTwo()
    {
        // Generate Top Face
        SpringCubeManager.GenerateFace(ref VertexB2, ref VertexC2, ref VertexB1, ref VertexC1);
        // Generate Bottom Face
        SpringCubeManager.GenerateFace(ref VertexE2, ref VertexF2, ref VertexE1, ref VertexF1);
        // Generate Front Face
        SpringCubeManager.GenerateFace(ref VertexB1, ref VertexC1, ref VertexE1, ref VertexF1);
        // Generate Back Face
        SpringCubeManager.GenerateFace(ref VertexB2, ref VertexC2, ref VertexE2, ref VertexF2);
        // Generate Left Face
        SpringCubeManager.GenerateFace(ref VertexB1, ref VertexB2, ref VertexE1, ref VertexE2);
        // Generate Right Face
        SpringCubeManager.GenerateFace(ref VertexC1, ref VertexC2, ref VertexF1, ref VertexF2);

        SpringCubeManager.ConnectVertices(ref RayDetector2, ref VertexB1, ref VertexC1, ref VertexE1, ref VertexF1, ref VertexB2, ref VertexC2, ref VertexE2, ref VertexF2);
    }

    /// <summary>
    /// Create the third softbody cube.
    /// </summary>
    public void GenerateCubeThree()
    {
        // Generate Top Face
        SpringCubeManager.GenerateFace(ref VertexD2, ref VertexE2, ref VertexD1, ref VertexE1);
        // Generate Bottom Face
        SpringCubeManager.GenerateFace(ref VertexG2, ref VertexH2, ref VertexG1, ref VertexH1);
        // Generate Front Face
        SpringCubeManager.GenerateFace(ref VertexD1, ref VertexE1, ref VertexG1, ref VertexH1);
        // Generate Back Face
        SpringCubeManager.GenerateFace(ref VertexD2, ref VertexE2, ref VertexG2, ref VertexH2);
        // Generate Left Face
        SpringCubeManager.GenerateFace(ref VertexD1, ref VertexD2, ref VertexG1, ref VertexG2);
        // Generate Right Face
        SpringCubeManager.GenerateFace(ref VertexE1, ref VertexE2, ref VertexH1, ref VertexH2);

        SpringCubeManager.ConnectVertices(ref RayDetector3, ref VertexD1, ref VertexE1, ref VertexG1, ref VertexH1, ref VertexD2, ref VertexE2, ref VertexG2, ref VertexH2);
    }

    /// <summary>
    /// Create the fourth softbody cube.
    /// </summary>
    public void GenerateCubeFour()
    {
        // Generate Bottom Face
        SpringCubeManager.GenerateFace(ref VertexH2, ref VertexI2, ref VertexH1, ref VertexI1);
        // Generate Front Face
        SpringCubeManager.GenerateFace(ref VertexE1, ref VertexF1, ref VertexH1, ref VertexI1);
        // Generate Back Face
        SpringCubeManager.GenerateFace(ref VertexE2, ref VertexF2, ref VertexH2, ref VertexI2);
        // Generate Right Face
        SpringCubeManager.GenerateFace(ref VertexF1, ref VertexF2, ref VertexI1, ref VertexI2);

        SpringCubeManager.ConnectVertices(ref RayDetector4, ref VertexE1, ref VertexF1, ref VertexH1, ref VertexI1, ref VertexE2, ref VertexF2, ref VertexH2, ref VertexI2);
    }

    /// <summary>
    /// Enable rigidbody gravity to all the object's vertices.
    /// </summary>
    public void EnableGravity()
    {
        SoftbodyPhysics.EnableGravity(ref VertexA1);
        SoftbodyPhysics.EnableGravity(ref VertexA2);
        SoftbodyPhysics.EnableGravity(ref VertexB1);
        SoftbodyPhysics.EnableGravity(ref VertexB2);
        SoftbodyPhysics.EnableGravity(ref VertexC1);
        SoftbodyPhysics.EnableGravity(ref VertexC2);
        SoftbodyPhysics.EnableGravity(ref VertexD1);
        SoftbodyPhysics.EnableGravity(ref VertexD2);
        SoftbodyPhysics.EnableGravity(ref VertexE1);
        SoftbodyPhysics.EnableGravity(ref VertexE2);
        SoftbodyPhysics.EnableGravity(ref VertexF1);
        SoftbodyPhysics.EnableGravity(ref VertexF2);
        SoftbodyPhysics.EnableGravity(ref VertexG1);
        SoftbodyPhysics.EnableGravity(ref VertexG2);
        SoftbodyPhysics.EnableGravity(ref VertexH1);
        SoftbodyPhysics.EnableGravity(ref VertexH2);
        SoftbodyPhysics.EnableGravity(ref VertexI1);
        SoftbodyPhysics.EnableGravity(ref VertexI2);
    }
}