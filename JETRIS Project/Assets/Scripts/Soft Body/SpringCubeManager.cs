using UnityEngine;

public class SpringCubeManager : MonoBehaviour
{
    /// <summary>
    /// Generate all springs within a 2D environment.
    /// </summary>
    /// <param name="topLeftVertex"> The top left vertex of the cube's face. </param>
    /// <param name="topRightVertex"> The top right vertex of the cube's face. </param>
    /// <param name="bottomLeftVertex"> The bottom left vertex of the cube's face. </param>
    /// <param name="bottomRightVertex"> The bottom right vertex of the cube's face. </param>
    public static void GenerateFace(ref GameObject topLeftVertex, ref GameObject topRightVertex, ref GameObject bottomLeftVertex, ref GameObject bottomRightVertex)
    {
        SoftbodyPhysics.AddSpring(ref topLeftVertex, ref topRightVertex);
        SoftbodyPhysics.AddSpring(ref topLeftVertex, ref bottomLeftVertex);
        SoftbodyPhysics.AddSpring(ref topLeftVertex, ref bottomRightVertex);

        SoftbodyPhysics.AddSpring(ref topRightVertex, ref bottomLeftVertex);
        SoftbodyPhysics.AddSpring(ref topRightVertex, ref bottomRightVertex);

        SoftbodyPhysics.AddSpring(ref bottomLeftVertex, ref topRightVertex);
        SoftbodyPhysics.AddSpring(ref bottomLeftVertex, ref bottomRightVertex);

        SoftbodyPhysics.AddSpring(ref bottomRightVertex, ref topLeftVertex);
    }

    /// <summary>
    /// Generate all springs within a 3D environment.
    /// </summary>
    /// <param name="rayDetector"> The center of the spring cube. </param>
    /// <param name="frontTopLeftVertex"> The front top left vertex of the spring cube. </param>
    /// <param name="frontTopRightVertex"> The front top right vertex of the spring cube. </param>
    /// <param name="frontBottomLeftVertex"> The front bottom left vertex of the spring cube. </param>
    /// <param name="frontBottomRightVertex"> The front bottom right vertex of the spring cube. </param>
    /// <param name="backTopLeftVertex"> The back top left vertex of the spring cube. </param>
    /// <param name="backTopRightVertex"> The back top right vertex of the spring cube. </param>
    /// <param name="backBottomLeftVertex"> The back bottom left vertex of the spring cube. </param>
    /// <param name="backBottomRightVertex"> The back bottom right vertex of the spring cube. </param>
    public static void ConnectVertices(ref GameObject rayDetector, ref GameObject frontTopLeftVertex, ref GameObject frontTopRightVertex, ref GameObject frontBottomLeftVertex, ref GameObject frontBottomRightVertex, ref GameObject backTopLeftVertex, ref GameObject backTopRightVertex, ref GameObject backBottomLeftVertex, ref GameObject backBottomRightVertex)
    {
        // Generates all springs within a 3D environment
        SoftbodyPhysics.AddSpring(ref frontTopLeftVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref frontTopLeftVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref backBottomRightVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref backBottomRightVertex, ref rayDetector);

        SoftbodyPhysics.AddSpring(ref frontTopRightVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref frontTopRightVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref backBottomLeftVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref backBottomLeftVertex, ref rayDetector);

        SoftbodyPhysics.AddSpring(ref frontBottomLeftVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref frontBottomLeftVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref backTopRightVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref backTopRightVertex, ref rayDetector);

        SoftbodyPhysics.AddSpring(ref frontBottomRightVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref frontBottomRightVertex, ref rayDetector);
        SoftbodyPhysics.AddSpring(ref backTopLeftVertex, ref rayDetector); 
        SoftbodyPhysics.AddSpring(ref backTopLeftVertex, ref rayDetector); 
    }

    /// <summary>
    /// Find the midpoint between two points in a 3D environment.
    /// </summary>
    /// <param name="vertexOne"> The first point. </param>
    /// <param name="vertexTwo"> The second point. </param>
    /// <returns> The Vector3 position of the midpoint. </returns>
    public static Vector3 FindMidpoint(GameObject vertexOne, GameObject vertexTwo)
    {
        float PosX = (vertexOne.transform.position.x + vertexTwo.transform.position.x) / 2;
        float PosY = (vertexOne.transform.position.y + vertexTwo.transform.position.y) / 2;
        float PosZ = (vertexOne.transform.position.z + vertexTwo.transform.position.z) / 2;

        return new Vector3(PosX, PosY, PosZ);
    }
}
