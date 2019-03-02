using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hightScoreText;
    public TextMeshProUGUI lastScoreText;
    public SpawnRocks rockSpawner;

    private int score = 0;
    private int scoreLevelChange = 20;
    // Start is called before the first frame update
    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = score.ToString();
        }
        if (hightScoreText != null)
        {
            hightScoreText.text = PlayerPrefsManager.GetHighscore().ToString();
        }
        if (lastScoreText != null)
        {
            lastScoreText.text = PlayerPrefsManager.GetLastscore().ToString();
        }

        SpawnRocks.rocksSpawned = 0;
    }

    public void IncrementScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        PlayerPrefsManager.SetLastscore(score);
        if(score > PlayerPrefsManager.GetHighscore())
        {
            PlayerPrefsManager.SetHighscore(score);
        }

            if (score >= scoreLevelChange && SpawnRocks.rocksSpawned < rockSpawner.rocks.Length)
            {
                scoreLevelChange += scoreLevelChange;
                rockSpawner.Spawn();
            }
    }
}
