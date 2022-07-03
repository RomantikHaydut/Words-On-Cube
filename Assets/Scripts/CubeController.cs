using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector2 firstMousePos;
    Vector2 activeMousePos;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        TurnTheCube();
    }

    void TurnTheCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Here we get the first mouse position.
            firstMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
            Debug.Log(firstMousePos);

        }
        else if (Input.GetMouseButton(0))
        {
            // Here we are turning the cube but it turns wrong :(
            activeMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
            Vector3 rotateWay = new Vector3(activeMousePos.x - firstMousePos.x, activeMousePos.y - firstMousePos.y);
            transform.Rotate(-rotateWay * 90f * Time.deltaTime);
        }
    }
}
