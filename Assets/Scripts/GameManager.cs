using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TMPro.TMP_Text highScoreText;
    public TMPro.TMP_Text scoreText;
    public GameObject getReady;
    public GameObject gameOver;
    public GameObject playButton;
    private int score = 0;

    void Awake()
    {
        Application.targetFrameRate = 60;
        UpdateHighScore();
        ClearScore();
        Pause();
    }

    public void Play()
    {
        ResetScore();
        DestroyAllPipes();

        getReady.SetActive(false);
        gameOver.SetActive(false);
        playButton.SetActive(false);
        
        player.enabled = true;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        UpdateHighScore();

        Pause();
    }

    private void ClearScore()
    {
        scoreText.text = "";    
    }
    private void ResetScore() 
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore() 
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    private void DestroyAllPipes() {
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i=0; i<pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    private void UpdateHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("highScore", 0);
        if (score > highScore) {
            PlayerPrefs.SetFloat("highScore", score);
            highScore = score;
        }
        highScoreText.text = "Max Score: " + highScore.ToString();
    }
}
