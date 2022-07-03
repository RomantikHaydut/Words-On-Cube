using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector2 firstMousePos;
    Vector2 activeMousePos;
    Vector3 rotateWay;
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
            rotateWay = Vector3.zero;
            firstMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
            Debug.Log("First Pos : "+firstMousePos);

        }
        else if (Input.GetMouseButton(0))
        {
            // Here we are turning the cube but it turns wrong :(
            activeMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
            if (Mathf.Abs(activeMousePos.x - firstMousePos.x) >Mathf.Abs(activeMousePos.y - firstMousePos.y))
            {
                 rotateWay = new Vector3(0, activeMousePos.x - firstMousePos.x, 0);
                transform.Rotate(-rotateWay * 270f * Time.deltaTime);

            }
            else if (Mathf.Abs(activeMousePos.y - firstMousePos.y) > Mathf.Abs(activeMousePos.x - firstMousePos.x))
            {
                 rotateWay = new Vector3(firstMousePos.y - activeMousePos.y,0 , 0);
                transform.Rotate(-rotateWay * 270f * Time.deltaTime);
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Here we get the first mouse position again
          //  firstMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
            Debug.Log("activepos : "+activeMousePos);
        }
    }
}
