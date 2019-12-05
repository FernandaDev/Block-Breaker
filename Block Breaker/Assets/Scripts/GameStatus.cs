using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField][Range(0.1f,3f)] float gameSpeed = 1f;
    [SerializeField] int scorePerBlock = 50;
    [SerializeField] int currentScore;
    public int CurrentScore { get => currentScore;
        private set {
            currentScore = value;
            UpdateScoreText();
        }
    }

    [SerializeField] TextMeshProUGUI scoreText = null;


    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        CurrentScore += scorePerBlock;
    }

    void UpdateScoreText()
    {
        scoreText.text = CurrentScore.ToString();
    }

    public void RestartLevelStatus()
    {
        Destroy(gameObject);
    }

}
