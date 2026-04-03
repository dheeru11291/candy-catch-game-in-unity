using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public static GameManeger Instance;
    int score = 0;
    bool gameOver=false;
    public Text scoreText;
    int lives =5;
    public Image[] livesHeart;
    public GameObject gameOverPannel;

    AudioManger audioManager;
   



    public void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManger>();
        Instance = this;
    }
    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            audioManager.PlaySFX(audioManager.eatCandy);

        }
        //print(score);
    }
    public void DecrementLife()
    {
        if (lives > 0)
        {
            lives--;
            Destroy(livesHeart[lives]);
            audioManager.PlaySFX(audioManager.lossLives);
            //print(lives);
        }
        else if (lives <= 0)
        {
            audioManager.PlaySFX(audioManager.gameOverSound);
            gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        CandySpawner.Instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPannel.SetActive(true);
        print("game over");
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
