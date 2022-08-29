using System;
using UnityEngine;
using System.Collections.Generic;

public class LinePreparingManager : MonoBehaviour
{
    private Vector3 _objectGlobalPosition;

    /// <summary>
    /// Prepare the given object for mesh slicing.
    /// Mesh slicing is needed in order to clear the line. 
    /// </summary>
    /// <param name="tetromino"> The object to prepare for mesh slicing. </param>
    public void PrepareObjects(GameObject tetromino)
    {
        GetPointOfOrigin(tetromino);
        SetPointOfOrigin(tetromino);

        MakeRigid(tetromino);
        RemoveRayDetectors(tetromino);
        AddSlicableComponents(tetromino);
    }

    /// <summary>
    /// Find the vertex most closely related to the object's global position.
    /// If the vertex's y coordinate is a decimal value, round it to the nearest whole number.
    /// </summary>
    /// <param name="tetromino"> The object's point of origin to find. </param>
    private void GetPointOfOrigin(GameObject tetromino)
    {
        GameObject ObjectLocalPosition = null;

        if(tetromino.name == "ITetromino(Clone)" || tetromino.name == "OTetromino(Clone)" || tetromino.name == "TTetromino(Clone)")
        {
            ObjectLocalPosition = tetromino.transform.GetChild(0).GetChild(14).gameObject;
        } else if (tetromino.name == "JTetromino(Clone)" || tetromino.name == "ZTetromino(Clone)")
        {
            ObjectLocalPosition = tetromino.transform.GetChild(0).GetChild(17).gameObject;
        } else
        {
            ObjectLocalPosition = tetromino.transform.GetChild(0).GetChild(16).gameObject;
        }

        _objectGlobalPosition = tetromino.transform.position;
        _objectGlobalPosition.y = (float)Math.Round(ObjectLocalPosition.transform.position.y);
    }

    /// <summary>
    /// Set the object's global position to the vertex that was most closely related to it.
    /// </summary>
    /// <param name="tetromino"> The object to set a new position for. </param>
    private void SetPointOfOrigin(GameObject tetromino)
    {
        tetromino.transform.position = _objectGlobalPosition;
    }

    private void RemoveRayDetectors(GameObject tetromino)
    {
        foreach(Transform childObject in tetromino.transform)
        {
            if(childObject.gameObject.name == "RayCollider(Clone)")
            {
                GameObject.Destroy(childObject.gameObject);
            }
        }
    }

    /// <summary>
    /// Remove all of the components from the object's bones to make it rigid.
    /// Destroy all the colliders and springs first, then rigidbodies.
    /// </summary>
    /// <param name="tetromino"> The object to remove softbody physics from. </param>
    private void MakeRigid(GameObject tetromino)
    {
        Transform armature = tetromino.transform.GetChild(0);

        foreach(Transform vertex in armature)
        {
            foreach(Component vertexComponent in vertex.gameObject.GetComponents<Component>())
            {
                if(!(vertexComponent is Transform) && !(vertexComponent is Rigidbody))
                {
                    Destroy(vertexComponent);
                }
            }

            Destroy(vertex.GetComponent<Rigidbody>());
        }
    }

    /// <summary>
    /// Add all the necessary components to the given object to make it slicable for mesh slicing.
    /// </summary>
    /// <param name="tetromino"> The object to set all the new components for. </param>
    private void AddSlicableComponents(GameObject tetromino)
    {
        tetromino.AddComponent<ObjectManager>();
        GameObject TetrominoRenderer = tetromino.transform.GetChild(1).gameObject;
        
        TetrominoRenderer.AddComponent<Slice>();
        TetrominoRenderer.AddComponent<MeshCollider>();
        Destroy(TetrominoRenderer.GetComponent<SkinnedMeshRenderer>());

        TetrominoRenderer.GetComponent<Slice>().sliceOptions = new SliceOptions();
        TetrominoRenderer.GetComponent<Slice>().sliceOptions.enableReslicing = true;

        switch(tetromino.name)
        {
            case "ITetromino(Clone)":
                TetrominoRenderer.GetComponent<MeshFilter>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/ITetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<MeshRenderer>().material = Instantiate(Resources.Load("Materials/I Tetromino", typeof(Material))) as Material;
                TetrominoRenderer.GetComponent<MeshCollider>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/ITetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<Slice>().sliceOptions.insideMaterial = Instantiate(Resources.Load("Materials/I Tetromino", typeof(Material))) as Material;
                break;

            case "JTetromino(Clone)":
                TetrominoRenderer.GetComponent<MeshFilter>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/JTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<MeshRenderer>().material = Instantiate(Resources.Load("Materials/J Tetromino", typeof(Material))) as Material;
                TetrominoRenderer.GetComponent<MeshCollider>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/JTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<Slice>().sliceOptions.insideMaterial = Instantiate(Resources.Load("Materials/J Tetromino", typeof(Material))) as Material;
                break;

            case "LTetromino(Clone)":
                TetrominoRenderer.GetComponent<MeshFilter>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/LTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<MeshRenderer>().material = Instantiate(Resources.Load("Materials/L Tetromino", typeof(Material))) as Material;
                TetrominoRenderer.GetComponent<MeshCollider>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/LTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<Slice>().sliceOptions.insideMaterial = Instantiate(Resources.Load("Materials/L Tetromino", typeof(Material))) as Material;
                break;

            case "OTetromino(Clone)":
                TetrominoRenderer.GetComponent<MeshFilter>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/OTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<MeshRenderer>().material = Instantiate(Resources.Load("Materials/O Tetromino", typeof(Material))) as Material;
                TetrominoRenderer.GetComponent<MeshCollider>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/OTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<Slice>().sliceOptions.insideMaterial = Instantiate(Resources.Load("Materials/O Tetromino", typeof(Material))) as Material;
                break;

            case "STetromino(Clone)":
                TetrominoRenderer.GetComponent<MeshFilter>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/STetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<MeshRenderer>().material = Instantiate(Resources.Load("Materials/S Tetromino", typeof(Material))) as Material;
                TetrominoRenderer.GetComponent<MeshCollider>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/STetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<Slice>().sliceOptions.insideMaterial = Instantiate(Resources.Load("Materials/S Tetromino", typeof(Material))) as Material;
                break;

            case "TTetromino(Clone)":
                TetrominoRenderer.GetComponent<MeshFilter>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/TTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<MeshRenderer>().material = Instantiate(Resources.Load("Materials/T Tetromino", typeof(Material))) as Material;
                TetrominoRenderer.GetComponent<MeshCollider>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/TTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<Slice>().sliceOptions.insideMaterial = Instantiate(Resources.Load("Materials/T Tetromino", typeof(Material))) as Material;
                break;

            case "ZTetromino(Clone)":
                TetrominoRenderer.GetComponent<MeshFilter>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/ZTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<MeshRenderer>().material = Instantiate(Resources.Load("Materials/Z Tetromino", typeof(Material))) as Material;
                TetrominoRenderer.GetComponent<MeshCollider>().sharedMesh = Instantiate(Resources.Load("Tetrominoes/ZTetromino", typeof(Mesh))) as Mesh;
                TetrominoRenderer.GetComponent<Slice>().sliceOptions.insideMaterial = Instantiate(Resources.Load("Materials/Z Tetromino", typeof(Material))) as Material;
                break;
        }

        // Since we are applying a mesh collider, we cannot have a non-kinematic and non-convex object.
        // Because we need the mesh collider to be concave, we set isKinematic to true.
        TetrominoRenderer.GetComponent<Rigidbody>().isKinematic = true;
        TetrominoRenderer.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        TetrominoRenderer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}