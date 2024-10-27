using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TimeSpan = System.TimeSpan;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelParams
{
    public Vector2Int valueRange;
    public float travelTime;
    public int scoreRequired;
    public float betweenTime;
    public Color sliderColor = new Color(40, 225, 240);
}

public class BrainGame : MonoBehaviour
{
    private static BrainGame instance;

    private static int score;

    public GameObject cratePrefab;
    public static TMP_Text scoreUI;
    public static Slider scoreSlider;
    public static Image scoreSliderFill;
    public static TMP_Text levelUI;
    public static TMP_Text timerUI;

    public int currentLevel = 0;

    public float timer = 180f;

    
    public List<LevelParams> levels = new List<LevelParams>();

    private LevelParams level
    {
        get { return levels[currentLevel]; }
    }

    public Vector2 crateXRange;
    public float startHeight;


    private void Awake()
    {
        scoreUI = GameObject.Find("Score").GetComponent<TMP_Text>();
        scoreSlider = GameObject.Find("ScoreSlider").GetComponent<Slider>();
        scoreSliderFill = GameObject.Find("ScoreSliderFill").GetComponent<Image>();
        levelUI = GameObject.Find("Level").GetComponent<TMP_Text>();
        timerUI = GameObject.Find("Time").GetComponent<TMP_Text>();
        currentLevel = 0;

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreSliderFill.color = instance.level.sliderColor;
        Invoke("SpawnCrate", 10f);
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timerUI.text = "0:00";
            // end game
            PlayerPrefs.SetInt("PrevScore", score);
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            SceneManager.LoadScene("EndScene");
        } else
        {
            timerUI.text = TimeSpan.FromSeconds(timer).ToString("m\\:ss");
        }
    }

    void SpawnCrate()
    {
        if (timer > 0)
        {
            var crate = Instantiate(cratePrefab);

            crate.transform.position = new Vector3(Random.Range(crateXRange.x, crateXRange.y), startHeight, 0);
            crate.GetComponent<Crate>().landingPosition = new Vector3(Random.Range(crateXRange.x, crateXRange.y), 0.35f, 0);
            crate.GetComponent<Crate>().value = Random.Range(level.valueRange.x, level.valueRange.y);
            crate.GetComponent<Crate>().travelTime = level.travelTime;

            Invoke("SpawnCrate", level.betweenTime);
        }
    }

    public static void Score(int amount)
    {
        score += amount;

        if (score > instance.level.scoreRequired && instance.currentLevel < instance.levels.Count - 1)
        {
            score = 0;
            instance.currentLevel++;
            levelUI.text = "Level " + (instance.currentLevel + 1).ToString();
            
        }

        scoreUI.text = "Score: " + score;
        scoreSlider.value = (float)(score) / instance.level.scoreRequired;
        scoreSliderFill.color = instance.level.sliderColor;
    }
}
