using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text scoreBlock = GameObject.Find("ScoreBlock").GetComponent<TMP_Text>();
        if (scoreBlock != null)
        {
            scoreBlock.text = "Score: " + PlayerPrefs.GetInt("PrevScore") + "\nHigh score: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
