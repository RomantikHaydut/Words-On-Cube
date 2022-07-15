using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterControl : MonoBehaviour
{
    private bool triggiring;
    private bool selected;
    private static bool canSelect;
    CanvasManager canvasManager;
    Vector3 goalPoint;
    Vector3 direction;
    TextMeshProUGUI letterText;
    public int letterIndex;
    public static int correctLetterIndex;
    public static int lastLetterIndex;
    private int level;

    void Start()
    {
        EventInStart();
        SortLetters();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && triggiring && !selected && canSelect && correctLetterIndex == letterIndex)
        {
            // here move the letter which is selected
            StartCoroutine(SelectLetter());
            correctLetterIndex++;
            selected = true;
            canSelect = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && triggiring && !selected && canSelect && correctLetterIndex != letterIndex)
        {
            StartCoroutine(canvasManager.WrongSelect());
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
            if (distanceFromGoal >= 0.2f)
            {
                transform.position += direction * Time.deltaTime;

            }
            else if ((timer <= 2 && timer >= 0) && distanceFromGoal < 0.2f)
            {
                transform.Rotate(Vector3.up * 180 * Time.deltaTime);
                timer -= Time.deltaTime;
            }
            else if (timer < 0 && timer >= -1f)
            {
                renderer.material.color = Color.red;
                timer -= Time.deltaTime;
            }
            else if (timer < -1f)
            {
                letterText.gameObject.SetActive(true);
                letterText.color = Color.red;
                yield return new WaitForSeconds(0.2f);
                if (lastLetterIndex == letterIndex)
                {
                    canvasManager.GameWon();
                }

                GameManager.Instance.AddScore(10);
                canSelect = true;
                Destroy(gameObject);
                yield break;
            }

        }
    }


    void EventInStart()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
        canSelect = true;
        selected = false;
        goalPoint = new Vector3(0, 3, -2);
        GameObject[] tagSiblings = GameObject.FindGameObjectsWithTag(gameObject.tag);

        for (int i = 0; i < tagSiblings.Length; i++)
        {
            if (tagSiblings[i].gameObject.GetComponent<CanvasRenderer>() && tagSiblings[i].gameObject != gameObject)
            {
                letterText = tagSiblings[i].GetComponent<TextMeshProUGUI>();
                letterText.gameObject.SetActive(false);
            }
        }
    }

    void SortLetters()
    {
        level = GameManager.level;
        correctLetterIndex = 1;
        if (level == 1)
        {
            if (gameObject.CompareTag("H"))
            {
                letterIndex = 1;
            }
            else if (gameObject.CompareTag("E"))
            {
                letterIndex = 2;
            }
            else if (gameObject.CompareTag("R"))
            {
                letterIndex = 3;
            }
            else if (gameObject.CompareTag("O"))
            {
                letterIndex = 4;
                lastLetterIndex = 4;
                canvasManager.EventInStart();
            }
        }
        else if (level == 2)
        {
            if (gameObject.CompareTag("G"))
            {
                letterIndex = 1;
            }
            else if (gameObject.CompareTag("A"))
            {
                letterIndex = 2;
            }
            else if (gameObject.CompareTag("M"))
            {
                letterIndex = 3;

            }
            else if (gameObject.CompareTag("E"))
            {
                letterIndex = 4;
                lastLetterIndex = 4;
                canvasManager.EventInStart();
            }
        }
    }

    /*  void EventsInSameLetters(int wantedIndex)
      {
          GameObject[] letters = GameObject.FindGameObjectsWithTag(gameObject.tag);
          for (int i = 0; i < letters.Length; i++)
          {
              if (letters[i] != gameObject && letters[i].GetComponent<LetterControl>())
              {
                  letters[i].GetComponent<LetterControl>().letterIndex = wantedIndex;
              }
          }
      }
    */

}
