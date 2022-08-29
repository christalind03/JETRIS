using UnityEngine;

interface ISoftbody
{
    void SetVertices();

    void InitRayDetectors();

    void GenerateCubeOne();
    void GenerateCubeTwo();
    void GenerateCubeThree();
    void GenerateCubeFour();
    
    void EnableGravity();
}