using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterControl : MonoBehaviour
{
    private bool triggiring;
    private bool selected;
    Vector3 goalPoint;
    Vector3 direction;
    void Start()
    {
        selected = false;
        goalPoint = new Vector3(0, 2, -2);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& triggiring && !selected)
        {
            // here move the letter which is selected
            StartCoroutine(SelectLetter());
            selected = true;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Selecter"))
        {
            triggiring = true;
        }
    }
     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Selecter"))
        {
            triggiring = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Selecter"))
        {
            triggiring = false;
        }
    }

    IEnumerator SelectLetter()
    {
        float timer = 2;
        transform.SetParent(null);
        MeshRenderer renderer = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        direction = new Vector3(goalPoint.x - transform.position.x, goalPoint.y - transform.position.y, goalPoint.z - transform.position.z).normalized;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            float distanceFromGoal = Vector3.Distance(goalPoint, transform.position);
            if (distanceFromGoal>=0.2f)
            {
                transform.position += direction * Time.deltaTime;

            }
            else if((timer<=2 && timer>=0) && distanceFromGoal<0.2f)
            {
                transform.Rotate(Vector3.up * 90 * Time.deltaTime);
                timer -= Time.deltaTime;
            }
            else if (timer<0 && timer>=-1f)
            {
                renderer.material.color = Color.red;
            }

        }
    }
}
