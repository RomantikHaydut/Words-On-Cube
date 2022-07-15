using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    TextMeshProUGUI timerText;

    TextMeshProUGUI winText;

    TextMeshProUGUI wrongSelectText;

    public float time;

    GameObject cube;

    GameObject winPanel;
    private void Awake()
    {
        cube = GameObject.Find("Cube").gameObject;
        winPanel = GameObject.Find("Win Panel").gameObject;
        wrongSelectText = GameObject.Find("Wrong Select Text").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
        time = 60;
        timerText = GameObject.Find("Time Text").GetComponent<TextMeshProUGUI>();
        winText = GameObject.Find("Win Text").GetComponent<TextMeshProUGUI>();
        winPanel.SetActive(false);
        wrongSelectText.gameObject.SetActive(false);
        Time.timeScale = 1;
        GameManager.canGoNextLevel = false;
    }

    
    void Update()
    {
        CountTime();
    }

    void CountTime()
    {
        if (GameManager.isGameContinue)
        {
            time -= Time.deltaTime;
        }
        timerText.text = "Seconds Left : " + (int)time;
    }

    public void EventInStart()
    {
        GameManager.isGameContinue = false;
        cube.SetActive(false);
    }
    public void StartGame(GameObject button)
    {
        GameManager.isGameContinue = true;
        cube.SetActive(true);
        Destroy(button);
    }

    public void GameWon()
    {
        winPanel.SetActive(true);
        winText.text = "You Win Your Score is : " + GameManager.score+ " Press 'N' For Next Level";
        GameManager.isGameContinue = false;
        Time.timeScale = 0;
        GameManager.canGoNextLevel = true;
    }

    public IEnumerator WrongSelect()
    {
        time -= 10;
        wrongSelectText.gameObject.SetActive(true);
        while (true)
        {
            wrongSelectText.CrossFadeColor(Color.red, 4f, true, true);
            yield return new WaitForSeconds(4f);
            wrongSelectText.gameObject.SetActive(false);
            yield break;
        }
    }
}
