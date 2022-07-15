using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int level;

    public static int score;

    public static bool isGameContinue;

    public static bool canGoNextLevel;

    private void Awake()
    {
        // Here we make this class singleton.
        if (Instance == null)
        {
            Instance = this;
            level = 1;
            score = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(Instance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            level++;
            NextLevel();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AddScore(int addingScore)
    {
        score += addingScore*(int)FindObjectOfType<CanvasManager>().time/60;
    }
}
