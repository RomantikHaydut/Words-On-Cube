using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cube;
    void Start()
    {
        transform.LookAt(cube.transform);
    }

    
    void LateUpdate()
    {
        
    }
}
